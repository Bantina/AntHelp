using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QX_Frame.Helper_DG_Framework_4_6;
using QX_Frame.Base.DB;
using QX_Frame.Base.Entities;
using QX_Frame.Base.Options;

namespace QX_Frame.Base
{
    public class QX_Frame_User_Service
    {
        /// <summary>
        /// IsExist_Auth
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns></returns>
        public Boolean IsExist(string loginId)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(loginId, t => { return EF_QX_Frame_DG.IsExist<tb_userAccount>(au => au.loginId.Trim().Equals(t.Trim())); }, "QX_Frame_User_Service IsExist_Auth");
        }

        /// <summary>
        /// IsRegister_Auth
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="pwd">password not proclaimed in writing -- server encrypt</param>
        /// <param name="uid">out uid use to insert info into user info table in other database</param>
        /// <returns></returns>
        public Boolean IsRegister(string loginId, string pwd, out Guid uid)
        {
            try
            {
                Guid commonGuid = Guid.NewGuid();

                tb_userAccount userAccount = new Entities.tb_userAccount();

                userAccount.uid = commonGuid;
                userAccount.loginId = loginId;
                userAccount.pwd = Encrypt_Helper_DG.MD5_Encrypt(pwd);

                tb_token token = new Entities.tb_token();
                token.uid = commonGuid;

                tb_userInfo userInfo = new tb_userInfo();
                userInfo.uid = commonGuid;

                tb_userLimit userLimit = new tb_userLimit();
                userLimit.uid = commonGuid;

                tb_userStatus userStatus = new tb_userStatus();
                userStatus.uid = commonGuid;

                // add the user related tables
                EF_QX_Frame_DG.IsAdd(token);
                EF_QX_Frame_DG.IsAdd(userInfo);
                EF_QX_Frame_DG.IsAdd(userLimit);
                EF_QX_Frame_DG.IsAdd(userStatus);
                // end add the user related tables

                uid = userAccount.uid; //the out arg.

                return EF_QX_Frame_DG.IsAdd<tb_userAccount>(userAccount);
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "QX_Frame_User_Service IsRegister_Auth");  //log
                uid = default(Guid);
                return default(Boolean);
            }
        }

        /// <summary>
        /// check if login info is correct
        /// </summary>
        /// <param name="loginIdEmailPhone">Decrypt loginIdEmailPhone</param>
        /// <param name="timeStamp">Decrypt timeStamp</param>
        /// <param name="MD5_string">Decrypt MD5(MD5(loginId+MD5(password)+timestamp)+loginId)</param>
        /// <param name="token">out token</param>
        /// <param name="errorMsg">errorMsg</param>
        /// <returns></returns>
        public Boolean IsLogin(string loginIdEmailPhone, DateTime timeStamp, string MD5_string, out string token, out string errorMsg)
        {
            try
            {
                tb_userAccount tbuserAccount = EF_QX_Frame_DG.selectSingle<tb_userAccount>(a => a.loginId.Trim() == loginIdEmailPhone.Trim() || a.email == loginIdEmailPhone.Trim() || a.phone == loginIdEmailPhone.Trim());
                if (tbuserAccount != null)
                {
                    tb_token tbToken = EF_QX_Frame_DG.selectSingle<tb_token>(t => t.uid == tbuserAccount.uid);    //select tb_token by tbuserAccount.uid
                    //if client timestamp<server timestamp regard as others filch request info and pretend to be client
                    if (timeStamp <= tbToken.timeStamp)
                    {
                        token = default(string);
                        errorMsg = "request time error";
                        return false;
                    }

                    //MD5(MD5(loginId+MD5(password)+timestamp)+loginId)
                    string MD5_string_loginId = Encrypt_Helper_DG.MD5_Encrypt(Encrypt_Helper_DG.MD5_Encrypt(tbuserAccount.loginId.Trim() + tbuserAccount.pwd.Trim() + timeStamp.ToString()) + tbuserAccount.loginId.Trim());
                    //MD5(MD5(email+MD5(password)+timestamp)+email)
                    string MD5_string_email = Encrypt_Helper_DG.MD5_Encrypt(Encrypt_Helper_DG.MD5_Encrypt(tbuserAccount.email.Trim() + tbuserAccount.pwd.Trim() + timeStamp.ToString()) + tbuserAccount.email.Trim());
                    //MD5(MD5(phone+MD5(password)+timestamp)+phone)
                    string MD5_string_phone = Encrypt_Helper_DG.MD5_Encrypt(Encrypt_Helper_DG.MD5_Encrypt(tbuserAccount.phone.Trim() + tbuserAccount.pwd.Trim() + timeStamp.ToString()) + tbuserAccount.phone.Trim());

                    if (MD5_string.Trim().Equals(MD5_string_loginId)|| MD5_string.Trim().Equals(MD5_string_email)|| MD5_string.Trim().Equals(MD5_string_phone))
                    {
                        //create a md5 token to client
                        token = Encrypt_Helper_DG.MD5_Encrypt(loginIdEmailPhone + Guid.NewGuid().ToString());
                        //get time config
                        double Auth_Token_expireTime_days = Convert.ToDouble(Config_Helper_DG.AppSetting_Get("Auth_Token_expireTime_days").Trim());
                        double Auth_Token_expireTime_hours = Convert.ToDouble(Config_Helper_DG.AppSetting_Get("Auth_Token_expireTime_hours").Trim());
                        double Auth_Token_expireTime_minutes = Convert.ToDouble(Config_Helper_DG.AppSetting_Get("Auth_Token_expireTime_minutes").Trim());
                        DateTime timeExpireTime = DateTime.Now.AddDays(Auth_Token_expireTime_days).AddHours(Auth_Token_expireTime_hours).AddMinutes(Auth_Token_expireTime_minutes);
                        //update db token info 
                        tbToken.tokenExpiring = timeExpireTime;
                        tbToken.token = token;
                        EF_QX_Frame_DG.IsUpdate(tbToken);
                        errorMsg = "success";
                        return true;
                    }
                    else
                    {
                        //the pwd error
                        token = default(string);
                        errorMsg = "user or password error";
                        return false;
                    }
                }
                else
                {
                    //the user inexistence
                    token = default(string);
                    errorMsg = "the user inexistence";
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "QX_Frame_User_Service IsLogin");
                token = default(string);
                errorMsg = "execute error";
                return false;
            }
        }

        /// <summary>
        /// select_uid_ByToken
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public Guid select_uid_ByToken(string token)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(token, t => { return EF_QX_Frame_DG.selectSingle<tb_token>(au => au.token.Trim().Equals(t.Trim())).uid; }, "QX_Frame_User_Service select_tb_Auth_ByToken");
        }
    }
}

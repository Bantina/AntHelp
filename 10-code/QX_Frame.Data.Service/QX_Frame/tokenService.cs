//using QX_Frame.Helper_DG_Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using QX_Frame.Data.QueryObject;
//using QX_Frame.Data.Entities.QX_Frame;

//namespace QX_Frame.Data.Service.QX_Frame
//{
//    /*2016-11-13 02:21:25 author:qixiao*/
//    public class QX_Frame_Token_Service
//    {
//        /// <summary>
//        /// token validate
//        /// </summary>
//        /// <param name="token">token</param>
//        /// <param name="errorMsg">out errorMsg</param>
//        /// <returns></returns>
//        public Boolean IsTokenPass(string token, out string errorMsg)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(token))
//                {
//                    errorMsg = "token is not find , please login anew to get token"; //token is not exist in database
//                    return false;
//                }
                
//                tb_token tbToken = EF_QX_Frame_DG.selectSingle<tb_token>(a => a.token.Trim() == token.Trim());
//                if (tbToken != null)
//                {
//                    DateTime? tokenExpirTime = Convert.ToDateTime(tbToken.tokenExpiring);
//                    if (DateTime.Now <= tokenExpirTime)
//                    {
//                        double Auth_Token_expireTime_days = Convert.ToDouble(Config_Helper_DG.AppSetting_Get("Auth_Token_expireTime_days").Trim());
//                        double Auth_Token_expireTime_hours = Convert.ToDouble(Config_Helper_DG.AppSetting_Get("Auth_Token_expireTime_hours").Trim());
//                        double Auth_Token_expireTime_minutes = Convert.ToDouble(Config_Helper_DG.AppSetting_Get("Auth_Token_expireTime_minutes").Trim());
//                        DateTime timeExpire = DateTime.Now.AddDays(Auth_Token_expireTime_days).AddHours(Auth_Token_expireTime_hours).AddMinutes(Auth_Token_expireTime_minutes);
//                        //update db token info
//                        tbToken.tokenExpiring = timeExpire;
//                        EF_QX_Frame_DG.IsUpdate(tbToken);
//                        errorMsg = "success";   //token valid success
//                        return true;
//                    }
//                    else
//                    {
//                        errorMsg = "token expired , please login anew to get token"; //token time expired
//                        return false;
//                    }
//                }
//                else
//                {
//                    errorMsg = "token is not find , please login anew to get token"; //token is not exist in database
//                    return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                Log_Helper_DG.Log_Error(ex.ToString(), "QX_Frame_Auth_Service IsTokenPass");
//                errorMsg = "token validate error , please login anew to get token";
//                return false;
//            }
//        }
//    }
//}

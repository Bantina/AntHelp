using QX_Frame.Base;
using QX_Frame.Data.DTO;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.WebAPI.Filters_DG;
using System;
using System.Net;
using System.Web.Http;
//using the static class  support in .NET FrameWork 4.6.*
using static QX_Frame.Helper_DG_Framework.ProcessFlow_Helper_DG;

namespace QX_Frame.WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost, Route("Account/Login")]
        public IHttpActionResult PostLogin(dynamic query)
            => Json<dynamic>(channel_Exception_Throw(
                () =>
                {
                    if (query != null)
                    {
                        //test part

                        DateTime timeNow = DateTime.Now;
                        string loginidTest = "qixiao";
                        string passwordTest = "123";
                        string timeStampTest = timeNow.ToString();
                        string str = loginidTest + "," + timeStampTest + "," + Encrypt_Helper_DG.MD5_Encrypt(Encrypt_Helper_DG.MD5_Encrypt(loginidTest + Encrypt_Helper_DG.MD5_Encrypt(passwordTest) + timeStampTest) + loginidTest);
                        Encrypt_Helper_DG.RSA_Keys rsaKey = Encrypt_Helper_DG.RSA_GetKeys();
                        string encryptTest = Encrypt_Helper_DG.RSA_Encrypt(str, rsaKey.publicKey);

                        query.loginInfo = encryptTest;
                        //end test part  after change the rsa to cache get

                        string token, errorMsg;

                        string loginInfos = query.loginInfo.ToString();

                        string[] loginInfoArray = Encrypt_Helper_DG.RSA_Decrypt(loginInfos, rsaKey.privateKey).ToString().Split(',');

                        string loginId = loginInfoArray[0];
                        DateTime timeStamp = Convert.ToDateTime(loginInfoArray[1]);
                        string MD5_string = loginInfoArray[2];

                        //check the login info and return token and errorMsg
                        if (new QX_Frame_User_Service().IsLogin(loginId, timeStamp, MD5_string, out token, out errorMsg))
                            return Return_Helper_DG.Object_TF_Msg_Data_Count(true, errorMsg, new { token = token }, 1);
                        else
                            return Return_Helper_DG.Object_TF_Msg_Code(false, errorMsg);
                    }
                    else
                    {
                        return Return_Helper_DG.Object_TF_Msg_Code(false, "arguments error or empty");
                    }
                }
                ));
        /// <summary>
        /// User Register
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IHttpActionResult PostRegister(dynamic query)
            => Json<dynamic>(channel_Exception_Throw(
                () =>
                {
                    if (query != null)
                    {
                        Guid uid = default(Guid);
                        Boolean IsRegisterSuccess = true;
                        if (new QX_Frame_User_Service().IsExist(query.loginId.ToString()))
                            return Return_Helper_DG.Object_TF_Msg_Code(false, "the user is already existed");

                        IsRegisterSuccess = IsRegisterSuccess & new QX_Frame_User_Service().IsRegister(query.loginId.ToString(), query.pwd.ToString(), out uid);

                        //there insert the other BLL about register user info (use & sign with IsRegisterSuccess)

                        //...

                        //end there

                        if (IsRegisterSuccess)
                            return Return_Helper_DG.Object_TF_Msg_Code_Uri(true, "register success , please login via the uri", HttpStatusCode.Redirect, "Account/Login");//redirect to login
                        else
                            return Return_Helper_DG.Object_TF_Msg_Code(false, "register faild , please try agin");
                    }
                    else
                    {
                        return Return_Helper_DG.Object_TF_Msg_Code(false, "arguments error or empty");
                    }
                }
            ));

        [AuthByQuery_Filter]
        public IHttpActionResult GetUser(dynamic query)
            => Json<dynamic>(channel_Exception_Throw(
                () =>
                {
                    if (query != null)
                    {
                        //UserViewModel userViewModel = new UserViewModel();

                        // query from BLL convert to DTO

                        //...
                        int a = Convert.ToInt32(query.content);

                        // end query

                        return Return_Helper_DG.Object_TF_Msg_Data_Count_Code(true, "success", default(UserViewModel));  //should be change after
                    }
                    else
                    {
                        return Return_Helper_DG.Object_TF_Msg_Code(false, "arguments error or empty");
                    }
                }
            ));

        //post delete
    }
}

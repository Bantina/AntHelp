using QX_Frame.Helper_DG;
using QX_Frame.WebAPI.Controllers;

namespace QX_Frame.WebAPI.Filters
{
    /**
     * author:qixiao
     * create:2017-4-11 10:36:12
     * */
    public class RequestValidation_DG
    {
        /// <summary>
        /// Request Validate
        /// </summary>
        /// <param name="random">random</param>
        /// <param name="timeStamp">timeStamp(long)</param>
        /// <param name="secretKey">secretKey</param>
        /// <param name="sign">sign</param>
        /// <param name="signCaculateValue">Md5_sign caculate value</param>
        /// <returns></returns>
        public static bool Validate(int appKey,int random, long timeStamp,string sign, string A_AValue_B_BValue_JointedArguments)
        {
            //sign validate sign=MD5[random+timestamp+a+a.value+b+b.value+c+c.value+secretkey]
            string encryptString = Encrypt_Helper_DG.MD5_Encrypt($"{random}{timeStamp}{A_AValue_B_BValue_JointedArguments}{AuthenticationController.GetAuthenticationByAppKey(appKey).secretkey}");
            if (!sign.Equals(encryptString))
            {
                throw new Exception_DG("the request has been tampered", 3010);
            }
            return true;
        }
    }
}
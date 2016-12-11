using QX_Frame.Helper_DG_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /*2016-11-13 23:58:18 author:qixiao*/
    public class SecretKeyController : ApiController
    {
        [HttpGet, Route("qx_frame/public_key")]
        public IHttpActionResult GetPublicKey()
            => Json<dynamic>(ProcessFlow_Helper_DG.channel_Exception_Throw(
                () =>
                {
                    object publicKey = Cache_Helper_DG.Cache_Get("RSA_publicKey");        //get RSA_publicKey from Cache
                    if (publicKey != null)
                        return Return_Helper_DG.Object_TF_Msg_Data_Count(true, "publicKey", publicKey, 1);  //if Cache exist key do not create renew

                    Encrypt_Helper_DG.RSA_Keys RSA_Keys = Encrypt_Helper_DG.RSA_GetKeys();
                    Cache_Helper_DG.Cache_Add("RSA_privateKey", RSA_Keys.privateKey, null, DateTime.Now.AddDays(7));  //save RSA_privateKey into Cache save time of 7 days
                    Cache_Helper_DG.Cache_Add("RSA_publicKey", RSA_Keys.publicKey, null, DateTime.Now.AddDays(7));    //savc RSA_publicKey into Cache save time of 7 days
                    object publicKey2 = Cache_Helper_DG.Cache_Get("RSA_publicKey");
                    return Return_Helper_DG.Object_TF_Msg_Data_Count(true, "publicKey", RSA_Keys.publicKey, 1);  //return publicKey the client cookie`s save time must <=7
                }));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Security;
using System.IO;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    /*2016-11-11 17:21:08 author:qixiao*/
    public abstract class Encrypt_Helper_DG
    {
        #region MD5 Encrypt
        /// <summary>
        /// Encypt via MD5
        /// </summary>
        /// <param name="str">encrypt content</param>
        /// <param name="MD5_length">the value length</param>
        /// <returns>Md5 value</returns>
        public static string MD5_Encrypt(string str, int MD5_length = 32)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
               () =>
               {
                   if (MD5_length == 16)
                   {
                       return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
                   }
                   else if (MD5_length == 32)
                   {
                       return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
                   }
                   else
                   {
                       Log_Helper_DG.Log("MD5 length is error please input the 16 or 32 bit !");
                       return null;
                   }
               }, "Encrypt_Helper_DG MD5_Encrypt");
        }

        #endregion

        #region RSA Encrypt
        /// <summary>
        /// RSA的容器 可以解密的源字符串长度为 DWKEYSIZE/8-11 
        /// </summary>
        private const int DWKEYSIZE = 1024;
        /// <summary>
        /// the class of RSA_Keys put publicKey and privateKey
        /// </summary>
        public struct RSA_Keys
        {
            public string publicKey { get; set; }
            public string privateKey { get; set; }
        }
        /// <summary>
        /// RSA_GetKeys
        /// </summary>
        /// <returns>Dictionary<string,string> public_key or private_key</string></returns>
        public static RSA_Keys RSA_GetKeys()
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
            () =>
            {
                var rsaProvider = new RSACryptoServiceProvider(DWKEYSIZE);
                RSAParameters parameter = rsaProvider.ExportParameters(true);
                return new RSA_Keys()
                {
                    publicKey = rsaProvider.ToXmlString(false),//BytesToHexString(parameter.Exponent) + "," + BytesToHexString(parameter.Modulus),
                    privateKey = rsaProvider.ToXmlString(true)
                };
            }, "Encrypt_Helper_DG RSA_Decrypt");
        }

        /// <summary>
        /// RSA_Encrypt
        /// </summary>
        /// <param name="content">Data</param>
        /// <param name="privateKey">privateKey</param>
        /// <returns></returns>
        public static string RSA_Encrypt(string content, string publicKey)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
            () =>
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(content), false));
                }
            }, "Encrypt_Helper_DG RSA_Encrypt");
        }

        /// <summary>
        /// RSA Decrypt method
        /// </summary>
        /// <param name="encryptedContent">encryptData</param>
        /// <param name="privateKey">privateKey</param>
        /// <returns></returns>
        public static string RSA_Decrypt(string encryptedContent, string privateKey)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
            () =>
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(encryptedContent), false));
                }
            }, "Encrypt_Helper_DG RSA_Decryp");
        }

        /// <summary>
        /// Get RSA HashDescription
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSA_GetHashDescription(string content)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
            () =>
            {
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                return Convert.ToBase64String(MD5.ComputeHash(Encoding.UTF8.GetBytes(content)));
            }, "Encrypt_Helper_DG RSA_GetHashDescription");
        }

        #region RSA Signature
        /// <summary>
        /// RSA_Signature
        /// </summary>
        /// <param name="privateKey">privateKey</param>
        /// <param name="hashContent">hashContent</param>
        /// <returns></returns>
        public static string RSA_Signature(string privateKey, string hashContent)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
            () =>
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(privateKey);
                    RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
                    RSAFormatter.SetHashAlgorithm("MD5");//set signature arithmetic
                    return Convert.ToBase64String(RSAFormatter.CreateSignature(Convert.FromBase64String(hashContent)));
                }
            }, "Encrypt_Helper_DG RSA_Signature");
        }

        /// <summary>
        /// RSA_SignatureVerify
        /// </summary>
        /// <param name="publicKey">publicKey</param>
        /// <param name="RSA_HashDescription_String">RSA_HashDescription_String</param>
        /// <param name="RSA_Signature_String">RSA_Signature_String</param>
        /// <returns></returns>
        public static bool RSA_SignatureVerify(string publicKey, string RSA_HashDescription_String, string RSA_Signature_String)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
            () =>
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(publicKey);
                    RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
                    RSADeformatter.SetHashAlgorithm("MD5");
                    byte[] HashDescription_String = Convert.FromBase64String(RSA_HashDescription_String);
                    byte[] Signature_String = Convert.FromBase64String(RSA_Signature_String);
                    return RSADeformatter.VerifySignature(HashDescription_String, Signature_String) == true ? true : false;
                }
            }, "Encrypt_Helper_DG RSA_SignatureVerify");
        }

        #endregion

        #endregion END RSA Encrypt
    }
}
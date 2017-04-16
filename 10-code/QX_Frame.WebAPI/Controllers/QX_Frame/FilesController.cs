using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using QX_Frame.WebAPI.config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /**
     * author:qixiao
     * create:2017-4-11 15:36:57
     * */
    public class FilesController : ApiController
    {
        //GET : api/Files/id
        public string Get(string id)
        {
            try
            {
                string imageName = id;
                string root = "Files/";
                var path = Path.Combine(root, imageName);
                var bytes = File.ReadAllBytes(path);
                var base64 = Convert.ToBase64String(bytes);
                return "data:image/jpeg;base64," + base64;
            }
            catch (Exception)
            {
                return DefaultImageStream.errorImageStream;
            }
        }
        //POST : api/Files
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new Exception_DG("unsupported media type", 2005);
            }
            string root = "Files"; //HttpContext.Current.Server.MapPath($"~/Files/{folderName}/");//指定要将文件存入的服务器物理位置  

            IO_Helper_DG.CreateDirectoryIfNotExist(root + "/temp");

            var provider = new MultipartFormDataStreamProvider(root + "/temp");

            // Read the form data.  
            await Request.Content.ReadAsMultipartAsync(provider);

            List<string> fileNameList = new List<string>();
            string AppDomain = Config_Helper_DG.AppSetting_Get("AppDomain");

            // This illustrates how to get the file names.
            foreach (MultipartFileData file in provider.FileData)
            {
                //new folder
                string newRoot = root;

                IO_Helper_DG.CreateDirectoryIfNotExist(newRoot);

                if (File.Exists(file.LocalFileName))
                {
                    //new fileName
                    string fileName = file.Headers.ContentDisposition.FileName.Substring(1, file.Headers.ContentDisposition.FileName.Length - 2);
                    string newFileName = Guid.NewGuid() + "." + fileName.Split('.')[1];
                    string newFullFileName = newRoot + "/" + newFileName;
                    File.Move(file.LocalFileName, newFullFileName);
                    fileNameList.Add(newFileName);
                    Trace.WriteLine("1 file copied , filePath=" + newFullFileName);
                }
            }

            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("file upload success", fileNameList, fileNameList.Count));
        }
    }
}

using QX_Frame.App.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /*
     * author:qixiao
     * time:2017-2-27 10:32:57
     **/
    public class Test1Controller : WebApiControllerBase
    {
        //access http://localhost:3999/api/Test1  get method
        //public IHttpActionResult GetTest()
        //{
        //    return Json(new { IsSuccess = true, Msg = "this is get method" });
        //}
        public IHttpActionResult Get([FromBody]dynamic query)
        {
            return Json(new { IsSuccess = true, name = query.name });
        }
        /// <summary>  
        /// 根据学生编号得到学生信息  
        /// </summary>  
        /// <param name="Id">学生编号</param>  
        /// <returns></returns>  
        public IHttpActionResult Get(string id, [FromBody]dynamic query)
        {
            return Json(new { IsSuccess = true,id=id, name = query.name });

        }

        //access http://localhost:3999/api/Test1  post method
        public IHttpActionResult PostTest(dynamic queryData)
        {
            return Json(new { IsSuccess = true, Msg = "this is post method",Data=queryData });
        }

        //access http://localhost:3999/api/Test1  put method
        public IHttpActionResult PutTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is put method" });
        }

        //access http://localhost:3999/api/Test1  delete method
        public IHttpActionResult DeleteTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is delete method" });
        }
    }
}

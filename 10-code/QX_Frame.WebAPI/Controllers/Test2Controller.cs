using QX_Frame.App.Web;
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
    public class Test2Controller : WebApiControllerBase
    {
        //define routers named just to you !

        //access http://localhost:3999/User/Get1  get or post method
        [Route("User/Get1")]
        public IHttpActionResult GetTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is get method" });
        }
        //access http://localhost:3999/User/Post1  get or post method
        [Route("User/Post1")]
        public IHttpActionResult PostTest(dynamic queryData)
        {
            return Json(new { IsSuccess = true, Msg = "this is post method", Data = queryData });
        }
        //access http://localhost:3999/User/Put1  get or post method
        [Route("User/Put1")]
        public IHttpActionResult PutTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is put method" });
        }
        //access http://localhost:3999/User/Delete1  get or post method
        [Route("User/Delete1")]
        public IHttpActionResult DeleteTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is delete method" });
        }

    }
}

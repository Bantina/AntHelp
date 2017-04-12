using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-04 22:32:55
    /// </summary>

    /// <summary>
    ///class UsersController
    /// </summary>
    public class UsersController : WebApiControllerBase
    {
        //address:http://localhost:3999/api/Users Get Method
        public IHttpActionResult Get(dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
        //address:http://localhost:3999/api/Users Post Method
        public IHttpActionResult Post()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
        //address:http://localhost:3999/api/Users Put Method
        public IHttpActionResult Put()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
        //address:http://localhost:3999/api/Users Delete Method
        public IHttpActionResult Delete()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
    }
}

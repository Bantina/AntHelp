using QX_Frame.App.Web;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using QX_Frame.Helper_DG.Extends;
using QX_Frame.WebAPI.Filters;
using System.Collections.Generic;
using System.Web.Http;
namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-13 20:52:15
    /// </summary>

    /// <summary>
    ///class UserRoleAttributeController
    /// </summary>
    [LimitsAttribute_DG(RoleLevel = 1)]//administrator least
    public class UserRoleAttributeController : WebApiControllerBase
    {
        // GET: api/UserRoleAttribute
        public IHttpActionResult Get(int pageIndex, int pageSize, bool isDesc)
        {
            using (var fact = Wcf<UserRoleAttributeService>())
            {
                var channel = fact.CreateChannel();
                int count;
                List<tb_UserRoleAttribute> userRoleAttributeList = channel.QueryAllPaging<tb_UserRoleAttribute, int>(new tb_UserRoleAttributeQueryObject { PageIndex = pageIndex, PageSize = pageSize, IsDESC = isDesc }, t => t.roleLevel).Cast<List<tb_UserRoleAttribute>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("user role attribute list", userRoleAttributeList, count));
            }
        }

        // GET: api/UserRoleAttribute/id
        public IHttpActionResult Get(string id)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // POST: api/UserRoleAttribute
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // PUT: api/UserRoleAttribute
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // DELETE: api/UserRoleAttribute
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
    }
}

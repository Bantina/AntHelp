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
    /// time:2017-04-13 21:13:39
    /// </summary>

    /// <summary>
    ///class UserStatusAttributeController
    /// </summary>
    [LimitsAttribute_DG(RoleLevel = 1)]//administrator least
    public class UserStatusAttributeController:WebApiControllerBase
	{
        // GET: api/UserStatusAttribute
        public IHttpActionResult Get(int pageIndex, int pageSize, bool isDesc)
        {
            using (var fact = Wcf<UserStatusAttributeService>())
            {
                var channel = fact.CreateChannel();
                int count;
                List<tb_UserStatusAttribute> userStatusAttributeList = channel.QueryAllPaging<tb_UserStatusAttribute, int>(new tb_UserStatusAttributeQueryObject { PageIndex = pageIndex, PageSize = pageSize, IsDESC = isDesc }, t => t.statusLevel).Cast<List<tb_UserStatusAttribute>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("user Status attribute list", userStatusAttributeList, count));
            }
        }


        // GET: api/UserStatusAttribute/id
        public IHttpActionResult Get(string id)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// POST: api/UserStatusAttribute
		public IHttpActionResult Post([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// PUT: api/UserStatusAttribute
		public IHttpActionResult Put([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// DELETE: api/UserStatusAttribute
		public IHttpActionResult Delete([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}
	}
}

using QX_Frame.App.Web;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-10 11:08:30
	/// </summary>

	/// <summary>
	///class LoginController
	/// </summary>
	public class LoginController:WebApiControllerBase
	{
		// GET: api/Login
		public IHttpActionResult Get([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// GET: api/Login/5
		public IHttpActionResult Get(string id, [FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// POST: api/Login
		public IHttpActionResult Post([FromBody]dynamic query)
		{
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            string loginId = query.loginId ?? throw new Exception_DG("loginId must be provide", 1002);
            int random = query.random ?? throw new Exception_DG("random must be provide", 1006);
            long timeStamp = query.timeStamp ?? throw new Exception_DG("timeStamp must be provide", 1007);

            throw new Exception_DG("The interface is not available", 9999);
		}

		// PUT: api/Login
		public IHttpActionResult Put([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}

		// DELETE: api/Login
		public IHttpActionResult Delete([FromBody]dynamic query)
		{
			throw new Exception_DG("The interface is not available", 9999);
		}
	}
}

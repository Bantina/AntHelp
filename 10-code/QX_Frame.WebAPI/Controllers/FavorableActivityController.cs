using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.Options;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using QX_Frame.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
	/// <summary>
	/// copyright qixiao code builder ->
	/// version:4.2.0
	/// author:qixiao(柒小)
	/// time:2017-04-14 17:42:20
	/// </summary>

	/// <summary>
	///class FavorableActivityController
	/// </summary>
	public class FavorableActivityController:WebApiControllerBase
	{
		// GET: api/FavorableActivity
		public IHttpActionResult Get(string actTitle, int pageIndex, int pageSize, bool isDesc)
		{
            tb_FavorableActivityQueryObject queryObject = new tb_FavorableActivityQueryObject();

            queryObject.actTitle = actTitle;
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = isDesc;

            using (var fact = Wcf<FavorableActivityService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_FavorableActivity> resultList = channel.QueryAllPaging<tb_FavorableActivity, DateTime>(queryObject, t => t.actPublishTime).Cast<List<tb_FavorableActivity>>(out count);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get complain list query by messagePushStatus", resultList, count));
            }
        }

        // GET: api/FavorableActivity/id
        public IHttpActionResult Get(string id)
		{
            using (var fact = Wcf<FavorableActivityService>())
            {
                Guid uid = Guid.Parse(id);
                var channel = fact.CreateChannel();

                tb_FavorableActivity favorableActivity = channel.QuerySingle(new tb_FavorableActivityQueryObject { QueryCondition = t => t.actUid == uid }).Cast<tb_FavorableActivity>();
                if (favorableActivity == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get FavorableActivity by id=actuid",favorableActivity,1));
            }
        }

        // POST: api/FavorableActivity
        public IHttpActionResult Post([FromBody]dynamic query)
		{
            using (var fact=Wcf<FavorableActivityService>())
            {
                var channel = fact.CreateChannel();

                tb_FavorableActivity favorableActivity = new tb_FavorableActivity();
                favorableActivity.actUid = Guid.NewGuid();
                favorableActivity.actTitle = query.actTitle;
                favorableActivity.actDescription = query.actDescription;
                favorableActivity.actStartTime = Convert.ToDateTime( query.actStartTime);
                favorableActivity.actEndTime = Convert.ToDateTime(query.actEndTime);
                favorableActivity.actPublishTime = DateTime.Now;
                favorableActivity.actPublisher = query.actPublisher;

                channel.Add(favorableActivity);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("add succeed"));
        }

        // PUT: api/FavorableActivity
        public IHttpActionResult Put([FromBody]dynamic query)
		{
            using (var fact = Wcf<FavorableActivityService>())
            {
                Guid uid = Guid.Parse(query.actUid);
                var channel = fact.CreateChannel();

                tb_FavorableActivity favorableActivity = channel.QuerySingle(new tb_FavorableActivityQueryObject { QueryCondition = t => t.actUid == uid }).Cast<tb_FavorableActivity>();
                if (favorableActivity == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }

                favorableActivity.actTitle = query.actTitle;
                favorableActivity.actDescription = query.actDescription;
                favorableActivity.actStartTime = Convert.ToDateTime(query.actStartTime);
                favorableActivity.actEndTime = Convert.ToDateTime(query.actEndTime);
                favorableActivity.actPublishTime = DateTime.Now;
                favorableActivity.actPublisher = query.actPublisher;

                channel.Update(favorableActivity);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update succeed"));
		}

		// DELETE: api/FavorableActivity
		public IHttpActionResult Delete([FromBody]dynamic query)
		{
            using (var fact = Wcf<FavorableActivityService>())
            {
                Guid uid = Guid.Parse(query.actUid);
                var channel = fact.CreateChannel();

                tb_FavorableActivity favorableActivity = channel.QuerySingle(new tb_FavorableActivityQueryObject { QueryCondition = t => t.actUid == uid }).Cast<tb_FavorableActivity>();
                if (favorableActivity == null)
                {
                    throw new Exception_DG("no result found by this query condition", 3021);
                }

                channel.Delete(favorableActivity);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update succeed"));
        }
	}
}

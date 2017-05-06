using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using System;
using System.Collections.Generic;
using System.Web.Http;
namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-14 18:53:53
    /// </summary>

    /// <summary>
    ///class CommentReplyController
    /// </summary>
    public class CommentReplyController : WebApiControllerBase
    {
        // GET: api/CommentReply
        public IHttpActionResult Get(Guid articleUid, int pageIndex, int pageSize, bool isDesc)
        {

            tb_CommentReplyQueryObject queryObject = new tb_CommentReplyQueryObject();

            queryObject.articleIdOrCommentId = articleUid;//fuzzy query
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = true;

            using (var fact = Wcf<CommentReplyService>())
            {
                var channel = fact.CreateChannel();
                int count;
                List<tb_CommentReply> commentReplyList = channel.QueryAllPaging<tb_CommentReply, DateTime>(queryObject, t => t.commentTime).Cast<List<tb_CommentReply>>(out count);

                List<CommentReplyViewModel> commentReplyViewModelList = new List<CommentReplyViewModel>();

                foreach (var item in commentReplyList)
                {
                    CommentReplyViewModel commentReplyViewModel = new CommentReplyViewModel();
                    commentReplyViewModel.commentUid = item.commentUid;
                    commentReplyViewModel.articleIdOrCommentId = item.articleIdOrCommentId;
                    commentReplyViewModel.commentUserLoginId = item.commentUserLoginId;
                    commentReplyViewModel.commentContent = item.commentContent;
                    commentReplyViewModel.commentTime = item.commentTime.ToDateTimeString_24HourType();

                    List<tb_CommentReply> replyList = channel.QueryAll(new tb_CommentReplyQueryObject { QueryCondition = t => t.articleIdOrCommentId == item.commentUid }).Cast<List<tb_CommentReply>>();
                    List<CommentReplyViewModel> replyViewModelList = new List<CommentReplyViewModel>();
                    foreach (var item2 in replyList)
                    {
                        CommentReplyViewModel replyViewModel = new CommentReplyViewModel();
                        replyViewModel.commentUid = item2.commentUid;
                        replyViewModel.articleIdOrCommentId = item2.articleIdOrCommentId;
                        replyViewModel.commentUserLoginId = item2.commentUserLoginId;
                        replyViewModel.commentContent = item2.commentContent;
                        replyViewModel.commentTime = item2.commentTime.ToDateTimeString_24HourType();
                        replyViewModel.commentReplyList = null;

                        replyViewModelList.Add(replyViewModel);
                    }

                    commentReplyViewModel.commentReplyList = replyViewModelList;

                    commentReplyViewModelList.Add(commentReplyViewModel);
                }

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get comment reply list by articleUid", commentReplyViewModelList, count));
            }
        }

        // GET: api/CommentReply/id
        public IHttpActionResult Get(string id)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // POST: api/CommentReply
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            using (var fact = Wcf<CommentReplyService>())
            {
                var channel = fact.CreateChannel();
                tb_CommentReply commentReply = new tb_CommentReply();
                commentReply.commentUid = Guid.NewGuid();
                Guid articleIdOrCommentId = query.articleIdOrCommentId;
                commentReply.articleIdOrCommentId = articleIdOrCommentId;
                commentReply.commentUserLoginId = query.commentUserLoginId;
                commentReply.commentContent = query.commentContent;
                commentReply.commentTime = DateTime.Now;
                channel.Add(commentReply);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("add succeed"));
            }
        }

        // PUT: api/CommentReply
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // DELETE: api/CommentReply
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            Guid commentUid = Guid.Parse(query.commentUid);
            using (var fact = Wcf<CommentReplyService>())
            {
                var channel = fact.CreateChannel();
                tb_CommentReply commentReply = channel.QuerySingle(new tb_CommentReplyQueryObject { QueryCondition = t => t.commentUid == commentUid }).Cast<tb_CommentReply>();
                channel.Delete(commentReply);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete succeed"));
            }
        }
    }
}

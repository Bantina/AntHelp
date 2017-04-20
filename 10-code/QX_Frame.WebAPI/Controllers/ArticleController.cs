using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
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
    /// time:2017-04-12 11:05:17
    /// </summary>

    /// <summary>
    ///class ArticleController
    /// </summary>

    [LimitsAttribute_DG(RoleLevel = 0)]
    public class ArticleController : WebApiControllerBase
    {
        // GET: api/Article articleCategoryId=0 query all
        public IHttpActionResult Get(string articleTitle,int articleCategoryId, int pageIndex, int pageSize, bool isDesc)
        {
            tb_ArticleQueryObject queryObject = new tb_ArticleQueryObject();

            queryObject.ArticleCategoryId = articleCategoryId;
            queryObject.articleTitle = articleTitle;//fuzzy query
            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = isDesc;

            using (var fact = Wcf<ArticleService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_Article> articleList = channel.QueryAllPaging<tb_Article, string>(queryObject, t => t.articleTitle).Cast<List<tb_Article>>(out count);
                List<ArticleViewModel> articleViewModelList = new List<ArticleViewModel>();
                foreach (var item in articleList)
                {
                    ArticleViewModel articleViewModel = new ArticleViewModel();
                    articleViewModel.articleUid = item.articleUid;
                    articleViewModel.articleTitle = item.articleTitle;
                    articleViewModel.articleContent = item.articleContent;
                    articleViewModel.publisherUid = item.publisherUid;
                    articleViewModel.publisherInfo = UserController.GetUserAccountInfoByUid(item.publisherUid);
                    articleViewModel.publishTime = item.publishTime.ToDateTimeString_24HourType();
                    articleViewModel.clickCount = item.clickCount;
                    articleViewModel.praiseCount = item.praiseCount;
                    articleViewModel.ArticleCategoryId = item.ArticleCategoryId;
                    articleViewModel.articleCategory = item.tb_ArticleCategory;
                    articleViewModel.imagesUrls = item.imagesUrls;
                    articleViewModelList.Add(articleViewModel);
                }

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get Article fuzzy query by articleTitle", articleViewModelList, count));
            }
        }

        // GET: api/Article/5
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception_DG("id must be provide", 1012);
            }

            Guid articleUid = Guid.Parse(id);

            using (var fact = Wcf<ArticleService>())
            {
                var channel = fact.CreateChannel();
                tb_Article article = channel.QuerySingle(new tb_ArticleQueryObject { QueryCondition = t => t.articleUid == articleUid }).Cast<tb_Article>();
                if (article == null)
                {
                    throw new Exception_DG("no article found by articleUid", 3013);
                }
                ArticleViewModel articleViewModel = new ArticleViewModel();
                articleViewModel.articleUid = article.articleUid;
                articleViewModel.articleTitle = article.articleTitle;
                articleViewModel.articleContent = article.articleContent;
                articleViewModel.publisherUid = article.publisherUid;
                articleViewModel.publisherInfo = UserController.GetUserAccountInfoByUid(article.publisherUid);
                articleViewModel.publishTime = article.publishTime.ToDateTimeString_24HourType();
                articleViewModel.clickCount = article.clickCount;
                articleViewModel.praiseCount = article.praiseCount;
                articleViewModel.ArticleCategoryId = article.ArticleCategoryId;
                articleViewModel.articleCategory = article.tb_ArticleCategory;
                articleViewModel.imagesUrls = article.imagesUrls;
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get Article by articleUid", articleViewModel, 1));
            }
        }
        // POST: api/Article
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            tb_Article article = tb_Article.Build();
            article.articleUid = Guid.NewGuid();
            article.articleTitle = query.articleTitle;
            article.articleContent = query.articleContent;
            article.ArticleCategoryId = query.ArticleCategoryId;
            string loginId = query.publisherLoginId;
            using (var fact2 = Wcf<UserAccountService>())
            {
                var channel2 = fact2.CreateChannel();
                article.publisherUid = channel2.GetUserAccountByLoginId(loginId).uid;
            }
            article.ArticleCategoryId = query.ArticleCategoryId;
            article.imagesUrls = query.imagesUrls;

            using (var fact2 = Wcf<ArticleService>())
            {
                var channel2 = fact2.CreateChannel();
                bool isAdd = channel2.Add(article);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("article publish succeed", article, 1));
            }
        }

        // PUT: api/Article/id  1 = update info ,2 = add clickCount , 3 = add praiseCount
        public IHttpActionResult Put(int id, [FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            Guid articleUid = query.articleUid;

            using (var fact = Wcf<ArticleService>())
            {
                var channel = fact.CreateChannel();
                tb_Article article = channel.QuerySingle(new tb_ArticleQueryObject { QueryCondition = t => t.articleUid == articleUid }).Cast<tb_Article>();
                if (article == null)
                {
                    throw new Exception_DG("no article found by articleUid", 3013);
                }
                if (id == 1)
                {
                    article.articleTitle = query.articleTitle;
                    article.articleContent = query.articleContent;
                    article.ArticleCategoryId = query.ArticleCategoryId;
                    article.publishTime = DateTime.Now;
                    article.imagesUrls = query.imagesUrls;
                }
                else if (id == 2)
                {
                    article.clickCount++;
                }
                else if (id == 3)
                {
                    article.praiseCount++;
                }
                else
                {
                    throw new Exception_DG("the error id provid", 3015);
                }

                if (!channel.Update(article))
                {
                    throw new Exception_DG("update article faild", 3014);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update article succeed", article, 1));
            }
        }

        // DELETE: api/Article
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }
            Guid articleUid = query.articleUid;
            using (var fact = Wcf<ArticleService>())
            {
                var channel = fact.CreateChannel();
                tb_Article article = channel.QuerySingle(new tb_ArticleQueryObject { QueryCondition = t => t.articleUid == articleUid }).Cast<tb_Article>();
                if (article == null)
                {
                    throw new Exception_DG("no article found by articleUid", 3013);
                }
                if (!channel.Delete(article))
                {
                    throw new Exception_DG("delete faild", 3005);
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete article succeed", article, 1));
            }
        }
    }
}

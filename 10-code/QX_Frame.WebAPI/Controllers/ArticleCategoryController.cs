using QX_Frame.App.WebApi;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using QX_Frame.Helper_DG.Extends;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-18 13:40:28
    /// </summary>

    /// <summary>
    ///class ArticleCategoryController
    /// </summary>
    public class ArticleCategoryController : WebApiControllerBase
    {
        // GET: api/ArticleCategory
        public IHttpActionResult Get(int pageIndex, int pageSize, bool isDesc)
        {
            tb_ArticleCategoryQueryObject queryObject = new tb_ArticleCategoryQueryObject();

            queryObject.PageIndex = pageIndex;
            queryObject.PageSize = pageSize;
            queryObject.IsDESC = isDesc;

            using (var fact = Wcf<ArticleCategoryService>())
            {
                int count = 0;
                var channel = fact.CreateChannel();
                List<tb_ArticleCategory> articleCategoryList = channel.QueryAllPaging<tb_ArticleCategory, int>(queryObject, t => t.CategoryId).Cast<List<tb_ArticleCategory>>(out count);

                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get articleCategoryList", articleCategoryList, count));
            }
        }

        // GET: api/ArticleCategory/id
        public IHttpActionResult Get(string id)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // POST: api/ArticleCategory
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            tb_ArticleCategory articleCategory = tb_ArticleCategory.Build();
            articleCategory.CategoryName = query.categoryName;
            using (var fact = Wcf<ArticleCategoryService>())
            {
                var channel = fact.CreateChannel();
                channel.Add(articleCategory);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("add succeed"));
        }

        // PUT: api/ArticleCategory
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            int categoryId = query.categoryId;
            string categoryName = query.categoryName;
            using (var fact = Wcf<ArticleCategoryService>())
            {
                var channel = fact.CreateChannel();
                tb_ArticleCategory articleCategory = channel.QuerySingle(new tb_ArticleCategoryQueryObject { QueryCondition = t => t.CategoryId == categoryId }).Cast<tb_ArticleCategory>();
                articleCategory.CategoryName = categoryName;
                channel.Update(articleCategory);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("update succeed"));
        }

        // DELETE: api/ArticleCategory
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            int categoryId = query.categoryId;
            using (var fact = Wcf<ArticleCategoryService>())
            {
                var channel = fact.CreateChannel();
                tb_ArticleCategory articleCategory = channel.QuerySingle(new tb_ArticleCategoryQueryObject { QueryCondition = t => t.CategoryId == categoryId }).Cast<tb_ArticleCategory>();
                channel.Delete(articleCategory);
            }
            return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("delete succeed"));
        }
    }
}

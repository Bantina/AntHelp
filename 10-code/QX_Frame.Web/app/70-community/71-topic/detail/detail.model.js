"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// 文章列表
class ArticleList {
    constructor(appKey, token, articleTitle, pageIndex, pageSize, isDesc) {
        this.appKey = appKey;
        this.token = token;
        this.articleTitle = articleTitle;
        this.pageIndex = pageIndex;
        this.pageSize = pageSize;
        this.isDesc = isDesc;
    }
}
exports.ArticleList = ArticleList;
// 文章
class Article {
}
exports.Article = Article;
// 用户
class UserInfoModel {
}
exports.UserInfoModel = UserInfoModel;
//# sourceMappingURL=detail.model.js.map
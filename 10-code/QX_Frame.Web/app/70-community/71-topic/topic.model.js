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
class Article {
}
exports.Article = Article;
//# sourceMappingURL=topic.model.js.map
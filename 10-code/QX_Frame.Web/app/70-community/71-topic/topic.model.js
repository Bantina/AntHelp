"use strict";
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
//# sourceMappingURL=topic.model.js.map
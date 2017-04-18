// 文章列表
export class ArticleList {
    constructor(
        public appKey: number,
        public token: string,
        public articleTitle: string,
        public pageIndex: number,
        public pageSize: number,
        public isDesc: boolean
    ) { }
}

export class Article
{
   public articleUid: string;
   public articleTitle: string;
   public articleContent: string;
   public publisherUid: string;
   public publishTime: string;
   public clickCount: number;
   public praiseCount: number;
   public ArticleCategoryId: string;
   public imagesUrls: string;
}
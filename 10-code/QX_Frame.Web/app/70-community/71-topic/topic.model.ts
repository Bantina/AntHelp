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
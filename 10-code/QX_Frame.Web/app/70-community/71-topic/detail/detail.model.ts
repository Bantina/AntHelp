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
// 文章
export class Article {
    public articleUid: string;
    public articleTitle: string;
    public articleContent: string;
    public loginId: string;
    public nickName: string;
    public publishTime: string;
    public clickCount: number;
    public praiseCount: number;
    public ArticleCategoryId: string;
    public articleCategoryName: string;
    public imagesNameList: string;
}
// 用户
export class UserInfoModel {
    public email: string;
    public appKey: number;
    public token: string;
    public loginId: string;
    public nickName: string;
    public phone: string;
    public headImageUrl: string;
    public age: number;
    public sexId: number;
    public birthday: string;
    public bloodTypeId: number;
    public position: string;
    public school: string;
    public location: string;
    public company: string;
    public constellation: string;
    public chineseZodiac: string;
    public personalizedSignature: string;
    public personalizedDescription: string;
}
// 回复
export class CommentReply {
    public commentUid: string;
    public articleIdOrCommentId: number;
    public commentUserLoginId: string;
    public commentContent: string;
    public commentTime: string;
}
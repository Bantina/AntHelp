//发布分类；
export class KindModel {
    constructor(
        public loginId: string,
        public email: string,
        public pwd: string,
        public emailHtmlRoute: string
    ) { }
}

export class PublishAidModel {
    constructor(
        public loginId: string,
        public kinds: string,
        public imges: string,
        public description: string,
        public price: number,
        public address: string,
        public phone: number
    ) { }
}


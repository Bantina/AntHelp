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

export class Order {
    public orderUid: string;
    public publisherUid: string;
    public publishTime: string;
    public orderDescription: string;
    public orderCategoryId: string;
    public receiverUid: string;
    public receiveTime: string;
    public orderStatusId: string;
    public orderValue: string;
    public allowVoucher: string;
    public voucherMax: string;
    public evaluateUid: string;
    public address: string;
    public phone: string;
    public imageUrls: string;
    public imageDatas: string[];
}

export class UserInfoModel {
        public email: string;
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
        public registerTime: string;

        public statusId: number;
        public statusName: string;
        public statusDescription: string;
        public roleId: number;
        public roleName: string;
        public roleDescription: string;
}

export class MyorderModel {
    public orderUid: number;
    public publisherUid: number;
    public publisherInfo: string;
    public publishTime: string;
    public orderDescription: string;
    public orderCategoryId: string;
    public orderCategory: string;
    public receiverUid: number;
    public receiverInfo: string;
    public receiveTime: string;
    public orderStatusId: string;
    public orderStatus: string;
    public orderValue: string;
    public allowVoucher: string;
    public voucherMax: string;
    public evaluateUid: number;
    public orderEvaluate: string;
    public address: string;
    public phone: string;
    public imageUrls: string;

    //add
    public firstImg: string;
}



export class UserInfoModel {
    constructor(
        public email: string,
        public appKey: number,
        public token: string,
        public loginId: string,
        public nickName: string,
        public phone: string,
        public headImageUrl: string,
        public age: number,
        public sexId: number,
        public birthday: string,
        public bloodTypeId: number,
        public position: string,
        public school: string,
        public location: string,
        public company: string,
        public constellation: string,
        public chineseZodiac: string,
        public personalizedSignature: string,
        public personalizedDescription: string
    ) { }
}



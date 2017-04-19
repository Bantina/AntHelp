using System;

namespace QX_Frame.Data.DTO
{
    [Serializable]
    public class UserAccountInfoViewModel
    {
        public Guid uid { get; set; }
        // 
        public String loginId { get; set; }
        // 
        public String nickName { get; set; }
        // 
        public String email { get; set; }
        // 
        public String phone { get; set; }
        // 
        public String headImageUrl { get; set; }
        // 
        public Int32 age { get; set; }

        public int sexId { get; set; }
        // 
        public string sexName { get; set; }
        // 
        public string birthday { get; set; }

        public int bloodTypeId { get; set; }
        // 
        public string bloodTypeName { get; set; }
        // 
        public String position { get; set; }
        // 
        public String school { get; set; }
        // 
        public String location { get; set; }
        // 
        public String company { get; set; }
        // 星座
        public String constellation { get; set; }
        // 生肖
        public String chineseZodiac { get; set; }
        // 个性签名
        public String personalizedSignature { get; set; }
        // 个人说明
        public String personalizedDescription { get; set; }

        public string registerTime { get; set; }

        public int statusId { get; set; }

        public string statusName { get; set; }

        public string statusDescription { get; set; }

        public int roleId { get; set; }

        public string roleName { get; set; }

        public string roleDescription { get; set; }
    }
}

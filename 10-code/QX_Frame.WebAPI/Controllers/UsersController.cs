using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Helper_DG_Framework.Extends;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-04-04 22:32:55
    /// </summary>

    /// <summary>
    ///class UsersController
    /// </summary>
    public class UsersController : WebApiControllerBase
    {
        //address:http://localhost:3999/api/Users Get Method
        public IHttpActionResult Get(dynamic query)
        {
            if (query == null)
            {
                throw new Exception_DG("arguments must be provide", 1001);
            }

            tb_UserAccountInfoQueryObject queryObject = new tb_UserAccountInfoQueryObject();

            queryObject.loginId = query.loginId;

            if (query.pageIndex == null || query.pageSize == null || query.isDesc == null)
            {
                throw new Exception_DG("pageIndex,pageSize,isDesc must be provide", 1008);
            }
            queryObject.PageIndex = Convert.ToInt32(query.pageIndex);
            queryObject.PageSize = Convert.ToInt32(query.pageSize);
            queryObject.IsDESC = Convert.ToBoolean(query.isDesc);

            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();

                int count;
                List<tb_UserAccountInfo> userAccountInfoList = channel.QueryAllPaging<tb_UserAccountInfo, string>(queryObject, t => t.loginId).Cast<List<tb_UserAccountInfo>>(out count);
                List<UserAccountInfoViewModel> userAccountInfoViewModelList = new List<UserAccountInfoViewModel>();
                foreach (var item in userAccountInfoList)
                {
                    userAccountInfoViewModelList.Add(
                        new UserAccountInfoViewModel
                        {
                            uid = item.uid,
                            loginId = item.loginId,
                            nickName = item.nickName,
                            email = item.email,
                            phone = item.phone,
                            headImageUrl = item.headImageUrl,
                            age = item.age,
                            sexName = item.tb_Sex.sexName.Trim(),
                            birthday = item.birthday,
                            bloodTypeName = item.tb_BloodType.bloodTypeName.Trim(),
                            position = item.position,
                            school = item.school,
                            location = item.location,
                            company = item.company,
                            constellation = item.constellation,
                            chineseZodiac = item.chineseZodiac,
                            personalizedSignature = item.personalizedSignature,
                            personalizedDescription = item.personalizedDescription,
                            registerTime = item.registerTime
                        });
                }
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get user info must paging by pageindex=num,pagesize=num,isdesc=1/0", userAccountInfoViewModelList, count));
            }
        }
        //address:http://localhost:3999/api/Users Post Method
        public IHttpActionResult Post()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
        //address:http://localhost:3999/api/Users Put Method
        public IHttpActionResult Put()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
        //address:http://localhost:3999/api/Users Delete Method
        public IHttpActionResult Delete()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
    }
}

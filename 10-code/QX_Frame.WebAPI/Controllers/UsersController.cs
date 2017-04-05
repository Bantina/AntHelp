using QX_Frame.App.Web;
using QX_Frame.Data.DTO;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            using (var fact = Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                //tb_UserAccountInfo instance add properties...
                tb_UserAccountInfo userAccountInfoQuery = tb_UserAccountInfo.Build();

                if (query != null)
                {
                    userAccountInfoQuery.loginId = query.loginid;
                }

                Expression<Func<tb_UserAccountInfo, bool>> func = t => true;

                if (!string.IsNullOrEmpty(userAccountInfoQuery.loginId))
                {
                    func = func.And(t => t.loginId.Contains(userAccountInfoQuery.loginId));
                }

                //queryObject
                tb_UserAccountInfoQueryObject queryObject = new tb_UserAccountInfoQueryObject();
                queryObject.QueryCondition = func;

                if (query != null)
                {
                    queryObject.PageIndex = Convert.ToInt32(query.pageindex);
                    queryObject.PageSize = Convert.ToInt32(query.pagesize);
                    string isdesc = query.isdesc;
                    if (isdesc.Equals("1"))
                    {
                        queryObject.IsDESC = true;
                    }
                    else if (isdesc.Equals("0"))
                    {
                        queryObject.IsDESC = false;
                    }
                }
                if (queryObject.PageIndex <= 0 || queryObject.PageIndex <= 0)
                {
                    queryObject.PageIndex = 1;
                    queryObject.PageSize = 10;
                }
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
                            personalizedDescription = item.personalizedDescription
                        });
                }
                return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("get user info must paging by pageindex=num,pagesize=num,isdesc=1/0", userAccountInfoViewModelList, count));
            }
        }
        //address:http://localhost:3999/api/Users Post Method
        public IHttpActionResult Post()
        {
            return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("put"));
        }
        //address:http://localhost:3999/api/Users Put Method
        public IHttpActionResult Put()
        {
            return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("put"));
        }
        //address:http://localhost:3999/api/Users Delete Method
        public IHttpActionResult Delete()
        {
            return Json(Return_Helper_DG.Success_Desc_Data_DCount_HttpCode("delete"));
        }
    }
}

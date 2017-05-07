using QX_Frame.App.WebApi;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using QX_Frame.Helper_DG;
using QX_Frame.Helper_DG.Extends;
using QX_Frame.WebAPI.Filters;
using System;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    /// <summary>
    /// copyright qixiao code builder ->
    /// version:4.2.0
    /// author:qixiao(柒小)
    /// time:2017-05-07 17:01:13
    /// </summary>

    /// <summary>
    ///class UserMoneyController
    /// </summary>
    public class UserMoneyController:WebApiControllerBase
    {
        // GET: api/UserMoney
        //[LimitsAttribute_DG(RoleLevel = 0)]//administrator
        public IHttpActionResult Get()
        {
            throw new Exception_DG("The interface is not available", 9999);
        }

        // GET: api/UserMoney/id id=loginId
        public IHttpActionResult Get(string id)
        {
            Guid uid = UserController.GetUserAccountInfoByLoginId(id).uid;
            using (var fact=Wcf<UserMoneyService>())
            {
                var channel = fact.CreateChannel();
                tb_UserMoney userMoney = channel.QuerySingle(new tb_UserMoneyQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserMoney>();
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("get userMoney by loginId", userMoney,1));
            }
        }

        // POST: api/UserMoney
        public IHttpActionResult Post([FromBody]dynamic query)
        {
            string loginId = query.loginId;
            int moneyAdd = query.money;
            Guid uid = UserController.GetUserAccountInfoByLoginId(loginId).uid;
            using (var fact = Wcf<UserMoneyService>())
            {
                var channel = fact.CreateChannel();
                tb_UserMoney userMoney = channel.QuerySingle(new tb_UserMoneyQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserMoney>();
                userMoney.money += moneyAdd;
                channel.Update(userMoney);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("add money by loginId,money", userMoney, 1));
            }
        }

        // PUT: api/UserMoney
        public IHttpActionResult Put([FromBody]dynamic query)
        {
            string loginId = query.loginId;
            int moneyAdd = query.money;
            Guid uid = UserController.GetUserAccountInfoByLoginId(loginId).uid;
            using (var fact = Wcf<UserMoneyService>())
            {
                var channel = fact.CreateChannel();
                tb_UserMoney userMoney = channel.QuerySingle(new tb_UserMoneyQueryObject { QueryCondition = t => t.uid == uid }).Cast<tb_UserMoney>();
                userMoney.money += moneyAdd;
                if (userMoney.money<0)
                {
                    throw new Exception_DG("no enough money", 3023);
                }
                channel.Update(userMoney);
                return Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("add money by loginId,money", userMoney, 1));
            }
        }

        // DELETE: api/UserMoney
        public IHttpActionResult Delete([FromBody]dynamic query)
        {
            throw new Exception_DG("The interface is not available", 9999);
        }
    }
}

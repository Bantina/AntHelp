using QX_Frame.App.WebApi;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;

namespace QX_Frame.WebAPI.config
{
    /**
     * author:qixiao 
     * time：2017-2-21 14:21:41
     **/
    //class registers
    public class ClassRegisters:WebApiControllerBase
    {
        public ClassRegisters()
        {
            //register region --
            WebApiControllerBase.Register(c => new AuthenticationService());
            WebApiControllerBase.Register(c => new BloodTypeService());
            WebApiControllerBase.Register(c => new SexService());
            WebApiControllerBase.Register(c => new UserAccountInfoService());
            WebApiControllerBase.Register(c => new UserAccountService());
            WebApiControllerBase.Register(c => new UserFunctionService());
            WebApiControllerBase.Register(c => new UserPasswordProtectionQuestionService());
            WebApiControllerBase.Register(c => new UserRoleAttributeService());
            WebApiControllerBase.Register(c => new UserRoleService());
            WebApiControllerBase.Register(c => new UserStatusAttributeService());
            WebApiControllerBase.Register(c => new UserStatusService());

            WebApiControllerBase.Register(c => new ArticleCategoryService());
            WebApiControllerBase.Register(c => new ArticleService());
            WebApiControllerBase.Register(c => new CommentReplyService());
            WebApiControllerBase.Register(c => new ComplainStatusService());
            WebApiControllerBase.Register(c => new FavorableActivityService());
            WebApiControllerBase.Register(c => new MessagePushCategoryService());
            WebApiControllerBase.Register(c => new MessagePushService());
            WebApiControllerBase.Register(c => new MessagePushStatusService());
            WebApiControllerBase.Register(c => new ComplainService());
            WebApiControllerBase.Register(c => new OrderEvaluateService());
            WebApiControllerBase.Register(c => new OrderService());
            WebApiControllerBase.Register(c => new OrderStatusService());
            WebApiControllerBase.Register(c => new RelationStatusService());
            WebApiControllerBase.Register(c => new SelfMessageService());
            WebApiControllerBase.Register(c => new UserRelationService());
            WebApiControllerBase.Register(c => new VoucherService());



            //end register region --
            WebApiControllerBase.RegisterComplex();
        }
    }
}
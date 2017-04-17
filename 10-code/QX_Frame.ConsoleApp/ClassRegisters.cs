using QX_Frame.App.Base;
using QX_Frame.Data.Service;
using QX_Frame.Data.Service.QX_Frame;

namespace QX_Frame.ConsoleApp
{
    /**
     * author:qixiao
     * time:2017-2-21 14:48:28
     **/ 
    public class ClassRegisters:AppBase
    {
        public ClassRegisters()
        {
            //register region --
            AppBase.Register(c => new AuthenticationService());
            AppBase.Register(c => new BloodTypeService());
            AppBase.Register(c => new SexService());
            AppBase.Register(c => new UserAccountInfoService());
            AppBase.Register(c => new UserAccountService());
            AppBase.Register(c => new UserFunctionService());
            AppBase.Register(c => new UserPasswordProtectionQuestionService());
            AppBase.Register(c => new UserRoleAttributeService());
            AppBase.Register(c => new UserRoleService());
            AppBase.Register(c => new UserStatusAttributeService());
            AppBase.Register(c => new UserStatusService());

            AppBase.Register(c => new ArticleCategoryService());
            AppBase.Register(c => new ArticleService());
            AppBase.Register(c => new CommentReplyService());
            AppBase.Register(c => new ComplainStatusService());
            AppBase.Register(c => new FavorableActivityService());
            AppBase.Register(c => new MessagePushCategoryService());
            AppBase.Register(c => new MessagePushService());
            AppBase.Register(c => new MessagePushStatusService());
            AppBase.Register(c => new ComplainService());
            AppBase.Register(c => new OrderEvaluateService());
            AppBase.Register(c => new OrderService());
            AppBase.Register(c => new OrderStatusService());
            AppBase.Register(c => new RelationStatusService());
            AppBase.Register(c => new SelfMessageService());
            AppBase.Register(c => new UserRelationService());
            AppBase.Register(c => new VoucherService());

            //end register region --
            AppBase.RegisterComplex();
        }
    }
}

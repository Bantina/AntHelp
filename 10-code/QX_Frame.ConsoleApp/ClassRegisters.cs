using QX_Frame.App.Base;
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



            //end register region --
            AppBase.RegisterComplex();
        }
    }
}

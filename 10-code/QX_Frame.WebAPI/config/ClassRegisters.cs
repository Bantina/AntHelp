using QX_Frame.App.Web;
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


            //end register region --
            WebApiControllerBase.RegisterComplex();
        }
    }
}
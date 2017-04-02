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
            WebApiControllerBase.Register(c => new UserAccountService());



            //end register region --
            WebApiControllerBase.RegisterComplex();
        }
    }
}
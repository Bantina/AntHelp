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
            AppBase.Register(c => new UserAccountService());



            //end register region --
            AppBase.RegisterComplex();
        }
    }
}

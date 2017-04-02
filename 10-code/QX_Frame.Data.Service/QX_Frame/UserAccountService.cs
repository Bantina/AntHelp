using QX_Frame.App.Base;
using QX_Frame.Data.Contract.QX_Frame;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.Service.QX_Frame
{
    public class UserAccountService : WcfService, IUserAccountService
    {
        private tb_userAccount _tb_userAccount;
        public UserAccountService()
        { }
        public UserAccountService(tb_userAccount tb_userAccount)
        {
            this._tb_userAccount = tb_userAccount;
        }
        public bool Add(tb_userAccount tb_userAccount)
        {
            return tb_userAccount.Add();
        }
        public bool Update(tb_userAccount tb_userAccount)
        {
            return tb_userAccount.Update();
        }
        public bool Delete(tb_userAccount tb_userAccount)
        {
            return tb_userAccount.Delete();
        }
    }
}

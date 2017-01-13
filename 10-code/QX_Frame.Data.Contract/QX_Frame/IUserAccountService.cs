using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.Contract.QX_Frame
{
    public interface IUserAccountService
    {
        bool Add();
        bool Update();
        bool Delete();
    }
}

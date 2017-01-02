using QX_Frame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.Contract
{
    public interface IExampleService
    {
        bool Add(example example);
        bool Update(example example);
        bool Delete(example example);
        example QuerySingle(Guid uid);
        List<example> QueryAll();
    }
}

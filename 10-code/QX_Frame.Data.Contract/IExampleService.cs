using QX_Frame.Data.Entities;
using System;
using System.Collections.Generic;

namespace QX_Frame.Data.Contract
{
    public interface IExampleService
    {
        bool Add();
        bool Update();
        bool Delete();
        Example QuerySingle(Guid uid);
        List<Example> QueryAll();
    }
}

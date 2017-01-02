using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.App.Base
{
    [Serializable]
    public class Entity<TEntity>
    {
        //New Entity Instance
        public static TEntity Build()
        {
            return Activator.CreateInstance<TEntity>();
        }
    }
}

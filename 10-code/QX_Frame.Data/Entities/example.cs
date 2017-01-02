using QX_Frame.App.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.Entities
{
    [Serializable]
    public class example:Entity<example>
    {
        public Guid uid { get; set; } = Guid.NewGuid();
        public int intValue { get; set; } = 0;
        public string stringValue { get; set; } = default(string);
    }
}

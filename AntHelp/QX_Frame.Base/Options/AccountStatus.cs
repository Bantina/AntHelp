using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Base.Options
{
    public enum AccountStatus:int
    {
        /// <summary>
        /// normal status (default)
        /// </summary>
        NORMAL=0,
        /// <summary>
        /// account stop
        /// </summary>
        STOP=1,
        /// <summary>
        /// account freeze
        /// </summary>
        FREEZE=2
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Base.Options
{
    /*2016-11-12 20:02:47 author：qixiao*/
    public enum AccountLimits:int
    {
        /// <summary>
        /// all ip can visit the application (default)
        /// </summary>
        ALL=0,
        /// <summary>
        /// the system administrator
        /// </summary>
        ROOT=1,
        /// <summary>
        /// application administrator
        /// </summary>
        ADMINISTRATOR = 2,
        /// <summary>
        /// general user
        /// </summary>
        USER=3
    }
}

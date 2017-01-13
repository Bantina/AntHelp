using QX_Frame.App.Base;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.QueryObject
{
    public class UserAccountQueryObject : WcfQueryObject<db_qx_frame, tb_userAccount>
    {
        public Guid uid { get; set; }
        public string loginId { get; set; }
        public string pwd { get; set; }
        protected override Expression<Func<TProxy, bool>> QueryFunc<TProxy>()
        {
            Expression<Func<TProxy, bool>> func = t => true;

            if (!string.IsNullOrEmpty(loginId))
            {
                func = func.And(t => t.loginId.Contains(loginId));
            }
            return func;
        }
        protected override Expression<Func<tb_userAccount, dynamic>> OrderBy
        {
            get
            {
                return t => t.loginId;
            }
        }
    }
}

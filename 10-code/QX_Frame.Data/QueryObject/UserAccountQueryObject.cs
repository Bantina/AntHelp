using QX_Frame.App.Base;
using QX_Frame.Data.Entities.QX_Frame;
using System;
using System.Linq.Expressions;

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
            if (!string.IsNullOrEmpty(pwd))
            {
                func = func.And(t => t.pwd == "123");
            }
            return func;
        }
    }
}

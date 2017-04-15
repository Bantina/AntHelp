using QX_Frame.App.Base;
using QX_Frame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.QueryObject
{
   public class tb_OrderCategoryQueryObject : WcfQueryObject<db_AntHelp, tb_OrderCategory>
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public override Expression<Func<tb_OrderCategory, bool>> QueryCondition { get { return base.QueryCondition; } set { base.QueryCondition = value; } }

        //query condition func // true default //if QueryCondition != null this will be override !!!
        protected override Expression<Func<tb_OrderCategory, bool>> QueryConditionFunc()
        {
            Expression<Func<tb_OrderCategory, bool>> func = t => true;

            if (!string.IsNullOrEmpty(""))
            {
                func = func.And(t => true);
            }

            return func;
        }

    }
}

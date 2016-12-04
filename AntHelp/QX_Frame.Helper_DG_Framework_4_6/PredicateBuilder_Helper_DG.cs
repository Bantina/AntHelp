using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    #region The lambda Extend

    public static class PredicateBuilder_Helper_DG
    {
        public static Expression<Func<T, bool>> True<T>() => f => true;

        public static Expression<Func<T, bool>> False<T>() => f => false;

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
            => Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>())), expr1.Parameters);

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
            => Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>())), expr1.Parameters);
    }

    #region The Example
    //Expression<Func<tb_User, bool>> func = u => u.Age == 11;
    //func=func.And<tb_User>(u => u.ClassId == 1);
    //the two condition is exist both useed at more condition select enviornment
    #endregion

    #endregion
}

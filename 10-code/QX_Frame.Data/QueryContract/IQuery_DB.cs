using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryContract
{
    public interface IQuery_DB<TEntity>
    {
        Boolean Add();
        Boolean Update();
        Boolean Delete();
        Boolean Exist(Expression<Func<TEntity, Boolean>> selectWhere);
        TEntity querySingle(Expression<Func<TEntity, Boolean>> selectWhere);
        List<TEntity> queryAll(Expression<Func<TEntity, Boolean>> selectWhere);
        List<TEntity> queryAllPaging<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> orderBy, Expression<Func<TEntity, Boolean>> selectWhere, Boolean isDESC = false);
    }
}

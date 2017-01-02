using QX_Frame.Data.QueryContract;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QX_Frame.Data.QueryObject
{
    public class Query_QX_Frame<TEntity> : IQuery_DB<TEntity> where TEntity:class 
    {
        IQuery_DB<TEntity> _queryDB;
        TEntity _entity;

        public Query_QX_Frame(IQuery_DB<TEntity> queryDB,TEntity entity)
        {
            _queryDB = queryDB;
            _entity = entity;
        }

        public Boolean Add() => EF_Helper_DG<db_qx_frame>.Add(_entity);
        public Boolean Update() => EF_Helper_DG<db_qx_frame>.Update(_entity);
        public Boolean Delete()=> EF_Helper_DG<db_qx_frame>.Delete(_entity);
        public Boolean Exist(Expression<Func<TEntity, Boolean>> selectWhere) => EF_Helper_DG<db_qx_frame>.Exist(selectWhere);
        public TEntity querySingle(Expression<Func<TEntity, Boolean>> selectWhere)  => EF_Helper_DG<db_qx_frame>.selectSingle(selectWhere);
        public List<TEntity> queryAll(Expression<Func<TEntity, Boolean>> selectWhere)  => EF_Helper_DG<db_qx_frame>.selectAll(selectWhere);
        public List<TEntity> queryAllPaging<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> orderBy, Expression<Func<TEntity, Boolean>> selectWhere, Boolean isDESC = false)  => EF_Helper_DG<db_qx_frame>.selectAllPaging(pageIndex, pageSize, orderBy, selectWhere, isDESC);
    }
}

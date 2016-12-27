using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Helper_DG_Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Data.QueryObject
{
    public class query_QX_Frame
    {
        public Boolean Add<T>(T t) where T : class => EF_Helper_DG<db_qx_frame>.Add<T>(t);
        public Boolean Update<T>(T t) where T : class => EF_Helper_DG<db_qx_frame>.Update<T>(t);
        public Boolean Delete<T>(T t) where T : class => EF_Helper_DG<db_qx_frame>.Delete<T>(t);
        public Boolean Exist<T>(Expression<Func<T, Boolean>> selectWhere) where T : class => EF_Helper_DG<db_qx_frame>.Exist<T>(selectWhere);
        public T querySingle<T>(Expression<Func<T, Boolean>> selectWhere) where T : class => EF_Helper_DG<db_qx_frame>.selectSingle(selectWhere);
        public List<T> queryAll<T>(Expression<Func<T, Boolean>> selectWhere) where T : class => EF_Helper_DG<db_qx_frame>.selectAll(selectWhere);
        public List<T> queryAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, Boolean isDESC = false) where T : class => EF_Helper_DG<db_qx_frame>.selectAllPaging(pageIndex, pageSize, orderBy, selectWhere, isDESC);
    }
}

using LinqKit; //AsExpandable() in linqkit.dll
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using QX_Frame.Helper_DG_Framework;

namespace QX_Frame.Helper_DG_Framework
{
    /*  time:   2016-10-30 15:26:05
        author: qixiao
    */
    /// <summary>
    /// EntityFramework CodeFirst Helper 
    /// </summary>
    /// <typeparam name="Db">DbContext</typeparam>
    public abstract class EF_Helper_DG<Db> where Db : DbContext
    {
        /*the singleton Db */
        private volatile static Db db = null;   //volatile find Db in memory not in cache

        #region The Singleton to new DBEntity_DG

        private static readonly object lockHelper = new object();
        static EF_Helper_DG()
        {
            if (db == null)
            {
                lock (lockHelper)
                {
                    if (db == null)
                        db = System.Activator.CreateInstance<Db>();
                }
            }
            //close the Validate of EF OnSaveEnabled
            db.Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion

        #region Add 

        public static Boolean Add<T>(T entity) where T : class
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Added;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), $"EF_Helper_DG Error");
                return false;
            }
        }
        public static Boolean Add<T>(T entity, out T outEntity) where T : class
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Added;
                outEntity = entity;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                outEntity = default(T);
                return false;
            }
        }
        public static Boolean Add<T>(List<T> entities) where T : class
        {
            try
            {
                db.Set<T>().AddRange(entities);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return false;
            }
        }

        #endregion

        #region Update

        public static Boolean Update<T>(T entity) where T : class
        {
            try
            {
                if (db.Entry<T>(entity).State == EntityState.Detached)
                {
                    db.Set<T>().Attach(entity);
                    db.Entry<T>(entity).State = EntityState.Modified;
                }
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return false;
            }
        }
        public static Boolean Update<T>(T entity, out T outEntity) where T : class
        {
            try
            {
                db.Set<T>().Attach(entity);
                db.Entry<T>(entity).State = EntityState.Modified;
                outEntity = entity;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                outEntity = default(T);
                return false;
            }
        }

        #endregion

        #region Delete

        public static Boolean Delete<T>(T entity) where T : class
        {
            try
            {
                db.Set<T>().Attach(entity);
                db.Entry<T>(entity).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return false;
            }
        }
        public static Boolean Delete<T>(List<T> entities) where T : class
        {
            try
            {
                db.Set<T>().RemoveRange(entities);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return false;
            }
        }
        public static Boolean Delete<T>(Expression<Func<T, bool>> deleteWhere) where T : class
        {
            try
            {
                List<T> entitys = db.Set<T>().AsExpandable().Where(deleteWhere).ToList();
                entitys.ForEach(m => db.Entry<T>(m).State = EntityState.Deleted);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return false;
            }
        }
        #endregion

        #region Select 

        public static Boolean Exist<T>(Expression<Func<T, Boolean>> selectWhere) where T : class
        {
            try
            {
                return db.Set<T>().AsExpandable().Where(selectWhere).ToList().FirstOrDefault<T>() == null ? false : true;
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(Boolean);
            }
        }
        public static T selectSingle<T>(Expression<Func<T, Boolean>> selectWhere) where T : class
        {
            try
            {
                return db.Set<T>().AsExpandable().Where(selectWhere).ToList().FirstOrDefault<T>();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(T);
            }
        }
        public static List<T> selectAll<T>() where T : class
        {
            try
            {
                return db.Set<T>().AsExpandable().ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T>(out int Count) where T : class
        {
            try
            {
                Count = db.Set<T>().AsExpandable().Count();
                return db.Set<T>().AsExpandable().ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                Count = 0;
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, Boolean isDESC = false) where T : class
        {
            try
            {
                if (isDESC)
                    return db.Set<T>().AsExpandable().OrderByDescending(orderBy).ToList();
                else
                    return db.Set<T>().AsExpandable().OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, out int Count, Boolean isDESC = false) where T : class
        {
            try
            {
                Count = db.Set<T>().AsExpandable().Count();
                if (isDESC)
                    return db.Set<T>().AsExpandable().OrderByDescending(orderBy).ToList();
                else
                    return db.Set<T>().AsExpandable().OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                Count = 0;
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T>(Expression<Func<T, Boolean>> selectWhere) where T : class
        {
            try
            {
                return db.Set<T>().AsExpandable().Where(selectWhere).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T>(Expression<Func<T, Boolean>> selectWhere, out int Count) where T : class
        {

            try
            {
                var list = db.Set<T>().AsExpandable().Where(selectWhere);
                Count = list.Count();
                return list.ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                Count = 0;
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, Boolean isDESC = false) where T : class
        {
            try
            {
                if (isDESC)
                    return db.Set<T>().AsExpandable().Where(selectWhere).OrderByDescending(orderBy).ToList();
                else
                    return db.Set<T>().AsExpandable().Where(selectWhere).OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(List<T>);
            }
        }
        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, out int Count, Boolean isDESC = false) where T : class
        {
            try
            {
                var list = db.Set<T>().AsExpandable().Where(selectWhere);
                Count = list.Count();
                if (isDESC)
                    return list.OrderByDescending(orderBy).ToList();
                else
                    return list.OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                Count = 0;
                return default(List<T>);
            }
        }

        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Boolean isDESC = false) where T : class
        {
            try
            {
                var list = db.Set<T>().AsExpandable();
                if (isDESC)
                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
                else
                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(List<T>);
            }
        }
        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, out int Count, Boolean isDESC = false) where T : class
        {
            try
            {
                var list = db.Set<T>().AsExpandable();
                Count = list.Count();
                if (isDESC)
                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
                else
                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                Count = 0;
                return default(List<T>);
            }
        }
        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, Boolean isDESC = false) where T : class
        {
            try
            {
                var list = db.Set<T>().AsExpandable().Where(selectWhere);
                if (isDESC)
                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
                else
                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                return default(List<T>);
            }
        }
        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, out int Count, Boolean isDESC = false) where T : class
        {
            try
            {
                var list = db.Set<T>().AsExpandable().Where(selectWhere);
                Count = list.Count();
                if (isDESC)
                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
                else
                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), "EF_Helper_DG Error");
                Count = 0;
                return default(List<T>);
            }
        }

        #endregion
    }
}

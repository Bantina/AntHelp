//using LinqKit; //AsExpandable() in linqkit.dll
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Data.Entity;
//using QX_Frame.Helper_DG_Framework;

//namespace QX_Frame.Base.DB
//{
//    /*  time:2016-10-30 15:26:05
//        author:qixiao
//          */


//    public abstract class EF_QX_Frame_DG
//    {
//        /*the singleton DBEntity_DG */
//        /// <summary>
//        /// The DBEntity_DG is must be named: DBEntity_DG
//        /// </summary>
//        private volatile static DB_QX_Frame db = null;

//        #region The Singleton to new DBEntity_DG 
//        private static readonly object lockHelper = new object();
//        static EF_QX_Frame_DG()
//        {
//            if (db == null)
//            {
//                lock (lockHelper)
//                {
//                    if (db == null)
//                        db = new DB_QX_Frame();
//                }
//            }
//            //close the Validate of EF OnSaveEnabled
//            db.Configuration.ValidateOnSaveEnabled = false;
//        }
//        #endregion

//        /// <summary>
//        /// Give the Error Log support
//        /// </summary>
//        /// <param name="logText"></param>
//        /// <param name="logTitle"></param>
//        /// <param name="isAppend"></param>
//        private static void Log_DG(string logText, string logTitle = "DBEntity_DG Error", Boolean isAppend = true)
//        {
//            try
//            {
//                string LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_Error/";
//                try
//                {
//                    LogLocation_DG = Config_Helper_DG.AppSetting_Get("Log_Location_Error_DG");
//                }
//                catch (Exception)
//                {
//                    LogLocation_DG = @"Log_QX_Frame/Log_QX_Frame_Error/";
//                }
//                if (!Directory.Exists(LogLocation_DG))
//                {
//                    Directory.CreateDirectory(LogLocation_DG);
//                }
//                using (StreamWriter log = new StreamWriter(LogLocation_DG + "Log_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".Log", isAppend))
//                {
//                    log.WriteLine();
//                    log.WriteLine(DateTime_Helper_DG.Get_DateTime_Now_24HourType() + "   -------" + logTitle + " Log !--------------------");
//                    log.WriteLine();
//                    log.WriteLine(logText);
//                }
//            }
//            catch (Exception)
//            {
//            }
//        }

//        #region Add 

//        public static Boolean IsAdd<T>(T entity) where T : class
//        {
//            try
//            {
//                db.Entry<T>(entity).State = EntityState.Added;
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return false;
//            }
//        }
//        public static Boolean IsAdd<T>(T entity, out T outEntity) where T : class
//        {
//            try
//            {
//                db.Entry<T>(entity).State = EntityState.Added;
//                outEntity = entity;
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                outEntity = default(T);
//                return false;
//            }
//        }
//        public static Boolean IsAdd<T>(List<T> entities) where T : class
//        {
//            try
//            {
//                db.Set<T>().AddRange(entities);
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return false;
//            }
//        }

//        #endregion

//        #region Update

//        public static Boolean IsUpdate<T>(T entity) where T : class
//        {
//            try
//            {
//                if (db.Entry<T>(entity).State == EntityState.Detached)
//                {
//                    db.Set<T>().Attach(entity);
//                    db.Entry<T>(entity).State = EntityState.Modified;
//                }
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return false;
//            }
//        }
//        public static Boolean IsUpdate<T>(T entity, out T outEntity) where T : class
//        {
//            try
//            {
//                db.Set<T>().Attach(entity);
//                db.Entry<T>(entity).State = EntityState.Modified;
//                outEntity = entity;
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                outEntity = default(T);
//                return false;
//            }
//        }

//        #endregion

//        #region Delete

//        public static Boolean IsDelete<T>(T entity) where T : class
//        {
//            try
//            {
//                db.Set<T>().Attach(entity);
//                db.Entry<T>(entity).State = EntityState.Deleted;
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return false;
//            }
//        }
//        public static Boolean IsDelete<T>(List<T> entities) where T : class
//        {
//            try
//            {
//                db.Set<T>().RemoveRange(entities);
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return false;
//            }
//        }
//        public static Boolean IsDelete<T>(Expression<Func<T, bool>> deleteWhere) where T : class
//        {
//            try
//            {
//                List<T> entitys = db.Set<T>().AsExpandable().Where(deleteWhere).ToList();
//                entitys.ForEach(m => db.Entry<T>(m).State = EntityState.Deleted);
//                return db.SaveChanges() > 0;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return false;
//            }
//        }
//        #endregion

//        #region Select 

//        public static Boolean IsExist<T>(Expression<Func<T, Boolean>> selectWhere) where T : class
//        {
//            try
//            {
//                return db.Set<T>().AsExpandable().Where(selectWhere).ToList().FirstOrDefault<T>() == null ? false : true;
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(Boolean);
//            }
//        }
//        public static T selectSingle<T>(Expression<Func<T, Boolean>> selectWhere) where T : class
//        {
//            try
//            {
//                return db.Set<T>().AsExpandable().Where(selectWhere).ToList().FirstOrDefault<T>();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(T);
//            }
//        }
//        public static List<T> selectAll<T>() where T : class
//        {
//            try
//            {
//                return db.Set<T>().AsExpandable().ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T>(out int Count) where T : class
//        {
//            try
//            {
//                Count = db.Set<T>().AsExpandable().Count();
//                return db.Set<T>().AsExpandable().ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                Count = 0;
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                if (isDESC)
//                    return db.Set<T>().AsExpandable().OrderByDescending(orderBy).ToList();
//                else
//                    return db.Set<T>().AsExpandable().OrderBy(orderBy).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, out int Count, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                Count = db.Set<T>().AsExpandable().Count();
//                if (isDESC)
//                    return db.Set<T>().AsExpandable().OrderByDescending(orderBy).ToList();
//                else
//                    return db.Set<T>().AsExpandable().OrderBy(orderBy).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                Count = 0;
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T>(Expression<Func<T, Boolean>> selectWhere) where T : class
//        {
//            try
//            {
//                return db.Set<T>().AsExpandable().Where(selectWhere).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T>(Expression<Func<T, Boolean>> selectWhere, out int Count) where T : class
//        {

//            try
//            {
//                var list = db.Set<T>().AsExpandable().Where(selectWhere);
//                Count = list.Count();
//                return list.ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                Count = 0;
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                if (isDESC)
//                    return db.Set<T>().AsExpandable().Where(selectWhere).OrderByDescending(orderBy).ToList();
//                else
//                    return db.Set<T>().AsExpandable().Where(selectWhere).OrderBy(orderBy).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAll<T, TKey>(Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, out int Count, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                var list = db.Set<T>().AsExpandable().Where(selectWhere);
//                Count = list.Count();
//                if (isDESC)
//                    return list.OrderByDescending(orderBy).ToList();
//                else
//                    return list.OrderBy(orderBy).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                Count = 0;
//                return default(List<T>);
//            }
//        }

//        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                var list = db.Set<T>().AsExpandable();
//                if (isDESC)
//                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//                else
//                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, out int Count, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                var list = db.Set<T>().AsExpandable();
//                Count = list.Count();
//                if (isDESC)
//                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//                else
//                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                Count = 0;
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                var list = db.Set<T>().AsExpandable().Where(selectWhere);
//                if (isDESC)
//                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//                else
//                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                return default(List<T>);
//            }
//        }
//        public static List<T> selectAllPaging<T, TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Expression<Func<T, Boolean>> selectWhere, out int Count, Boolean isDESC = false) where T : class
//        {
//            try
//            {
//                var list = db.Set<T>().AsExpandable().Where(selectWhere);
//                Count = list.Count();
//                if (isDESC)
//                    return list.OrderByDescending(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//                else
//                    return list.OrderBy(orderBy).Skip((pageIndex - 1 < 0 ? 0 : pageIndex - 1) * (pageSize < 0 ? 0 : pageSize)).Take(pageSize < 0 ? 0 : pageSize).ToList();
//            }
//            catch (Exception ex)
//            {
//                Log_DG(ex.ToString());
//                Count = 0;
//                return default(List<T>);
//            }
//        }

//        #endregion
//    }
//}

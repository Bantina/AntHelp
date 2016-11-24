using QX_Frame.Helper_DG_Framework_4_6.options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    /*2016-11-15 10:39:17 author:qixiao*/
    /// <summary>
    /// uniform process flow
    /// </summary>
    public abstract class ProcessFlow_Helper_DG
    {
        #region return E uniform process flow Exception_Ignore
        public static E channel_Exception_Ignore<E>(Func<E> methodExecute)
        {
            try { return methodExecute(); } catch (Exception) { return default(E); }
        }
        public static E channel_Exception_Ignore<T, E>(T t, Func<T, E> methodExecute)
        {
            try { return methodExecute(t); } catch (Exception) { return default(E); }
        }
        public static E channel_Exception_Ignore<T, E>(T t, Predicate<T> conditionExecute, Func<T, E> methodExecute)
        {
            try { return conditionExecute(t) == true ? methodExecute(t) : default(E); } catch (Exception) { return default(E); }
        }
        #endregion

        #region return E uniform process flow Exception_Log exceptionExecute
        public static E channel_Exception_Log<E>(Func<E> methodExecute, Func<E> exceptionExecute)
        {
            try
            {
                return methodExecute(); //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString());
                return exceptionExecute();
            }
        }
        public static E channel_Exception_Log<T, E>(T t, Func<T, E> methodExecute, Func<E> exceptionExecute)
        {
            try
            {
                return methodExecute(t);    //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString());
                return exceptionExecute();
            }
        }
        public static E channel_Exception_Log<T, E>(T t, Predicate<T> conditionExecute, Func<T, E> methodExecute, Func<E> exceptionExecute)
        {
            try
            {
                return conditionExecute(t) == true ? methodExecute(t) : exceptionExecute();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString());
                return exceptionExecute();
            }
        }
        #endregion

        #region return E uniform process flow Log + exceptionLogTitle
        public static E channel_Exception_Log<E>(Func<E> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(); //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return default(E);
            }
        }
        public static E channel_Exception_Log<T, E>(T t, Func<T, E> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(t);    //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return default(E);
            }
        }
        public static E channel_Exception_Log<T, E>(T t, Predicate<T> conditionExecute, Func<T, E> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return conditionExecute(t) == true ? methodExecute(t) : default(E);
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return default(E);
            }
        }
        #endregion

        #region return E uniform process flow Log + exceptionLogTitle exceptionExecute
        public static E channel_Exception_Log<E>(Func<E> methodExecute, Func<E> exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(); //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return exceptionExecute();
            }
        }
        public static E channel_Exception_Log<T, E>(T t, Func<T, E> methodExecute, Func<E> exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(t);    //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return exceptionExecute();
            }
        }
        public static E channel_Exception_Log<T, E>(T t, Predicate<T> conditionExecute, Func<T, E> methodExecute, Func<E> exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return conditionExecute(t) == true ? methodExecute(t) : exceptionExecute();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return exceptionExecute();
            }
        }
        #endregion


        #region return List<E> uniform process flow Exception_Ignore
        public static List<E> channel_Exception_Ignore<E>(Func<List<E>> methodExecute)
        {
            try { return methodExecute(); } catch (Exception) { return default(List<E>); }
        }
        public static List<E> channel_Exception_Ignore<T, E>(T t, Func<T, List<E>> methodExecute)
        {
            try { return methodExecute(t); } catch (Exception) { return default(List<E>); }
        }
        public static List<E> channel_Exception_Ignore<T, E>(T t, Predicate<T> conditionExecute, Func<T, List<E>> methodExecute)
        {
            try { return conditionExecute(t) == true ? methodExecute(t) : default(List<E>); } catch (Exception) { return default(List<E>); }
        }
        #endregion

        #region return List<E> uniform process flow Exception_Ignore exceptionExecute
        public static List<E> channel_Exception_Ignore<E>(Func<List<E>> methodExecute, Func<List<E>> exceptionExecute)
        {
            try
            {
                return methodExecute(); //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString());
                return exceptionExecute();
            }
        }
        public static List<E> channel_Exception_Ignore<T, E>(T t, Func<T, List<E>> methodExecute, Func<List<E>> exceptionExecute)
        {
            try
            {
                return methodExecute(t);    //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString());
                return exceptionExecute();
            }
        }
        public static List<E> channel_Exception_Ignore<T, E>(T t, Predicate<T> conditionExecute, Func<T, List<E>> methodExecute, Func<List<E>> exceptionExecute)
        {
            try
            {
                return conditionExecute(t) == true ? methodExecute(t) : exceptionExecute();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString());
                return exceptionExecute();
            }
        }
        #endregion

        #region return List<E> uniform process flow Log + exceptionLogTitle
        public static List<E> channel_Exception_Log<E>(Func<List<E>> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(); //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return default(List<E>);
            }
        }
        public static List<E> channel_Exception_Log<T, E>(T t, Func<T, List<E>> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(t);    //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return default(List<E>);
            }
        }
        public static List<E> channel_Exception_Log<T, E>(T t, Predicate<T> conditionExecute, Func<T, List<E>> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return conditionExecute(t) == true ? methodExecute(t) : default(List<E>);
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return default(List<E>);
            }
        }
        #endregion

        #region return List<E> uniform process flow Log + exceptionLogTitle exceptionExecute
        public static List<E> channel_Exception_Log<E>(Func<List<E>> methodExecute, Func<List<E>> exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(); //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return exceptionExecute();
            }
        }
        public static List<E> channel_Exception_Log<T, E>(T t, Func<T, List<E>> methodExecute, Func<List<E>> exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return methodExecute(t);    //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return exceptionExecute();
            }
        }
        public static List<E> channel_Exception_Log<T, E>(T t, Predicate<T> conditionExecute, Func<T, List<E>> methodExecute, Func<List<E>> exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                return conditionExecute(t) == true ? methodExecute(t) : exceptionExecute();
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                return exceptionExecute();
            }
        }
        #endregion


        #region no result channel process flow Exception_Ignore
        public static void channel_Exception_Ignore(Action methodExecute)
        {
            try { methodExecute(); } catch (Exception) { }
        }
        public static void channel_Exception_Ignore<T>(T t, Action<T> methodExecute)
        {
            try { methodExecute(t); } catch (Exception) { }
        }
        public static void channel_Exception_Ignore<T>(T t, Predicate<T> conditionExecute, Action<T> methodExecute)
        {
            try { if (conditionExecute(t)) methodExecute(t); } catch (Exception) { }
        }
        #endregion

        #region no result channel process flow Exception_Ignore exceptionExecute
        public static void channel_Exception_Ignore(Action methodExecute, Action exceptionExecute)
        {
            try { methodExecute(); } catch (Exception) { exceptionExecute(); }
        }
        public static void channel_Exception_Ignore<T>(T t, Action<T> methodExecute, Action exceptionExecute)
        {
            try { methodExecute(t); } catch (Exception) { }
        }
        public static void channel_Exception_Ignore<T>(T t, Predicate<T> conditionExecute, Action<T> methodExecute, Action exceptionExecute)
        {
            try { if (conditionExecute(t)) methodExecute(t); } catch (Exception) { exceptionExecute(); }
        }
        #endregion

        #region no result channel process flow Log + exceptionLogTitle
        public static void channel_Exception_Log(Action methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                methodExecute();    //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
            }
        }
        public static void channel_Exception_Log<T>(T t, Action<T> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                methodExecute(t);   //arguments is
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
            }
        }
        public static void channel_Exception_Log<T>(T t, Predicate<T> conditionExecute, Action<T> methodExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                if (conditionExecute(t)) methodExecute(t);   //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
            }
        }
        #endregion

        #region no result channel process flow Log + exceptionLogTitle exceptionExecute
        public static void channel_Exception_Log(Action methodExecute, Action exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                methodExecute();    //no arguments
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                exceptionExecute();
            }
        }
        public static void channel_Exception_Log<T>(T t, Action<T> methodExecute, Action exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                methodExecute(t);   //arguments is
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                exceptionExecute();
            }
        }
        public static void channel_Exception_Log<T>(T t, Predicate<T> conditionExecute, Action<T> methodExecute, Action exceptionExecute, string exceptionLogTitle = "ERROR")
        {
            try
            {
                if (conditionExecute(t)) methodExecute(t);   //arguments is t
            }
            catch (Exception ex)
            {
                Log_Helper_DG.Log_Error(ex.ToString(), exceptionLogTitle);
                exceptionExecute();
            }
        }
        #endregion


        #region return E uniform process flow channel_Exception_Throw

        public static E channel_Exception_Throw<E>(Func<E> methodExecute)
        {
            try { return methodExecute(); } catch (Exception ex) { throw ex; }
        }
        public static E channel_Exception_Throw<T, E>(T t, Func<T, E> methodExecute)
        {
            try { return methodExecute(t); } catch (Exception ex) { throw ex; }
        }
        public static E channel_Exception_Throw<T, E>(T t, Predicate<T> conditionExecute, Func<T, E> methodExecute)
        {
            try { return conditionExecute(t) == true ? methodExecute(t) : default(E); } catch (Exception ex) { throw ex; }
        }

        #endregion

        #region return List<E> uniform process flow Exception_Ignore
        public static List<E> channel_Exception_Throw<E>(Func<List<E>> methodExecute)
        {
            try { return methodExecute(); } catch (Exception ex) { throw ex; }
        }
        public static List<E> channel_Exception_Throw<T, E>(T t, Func<T, List<E>> methodExecute)
        {
            try { return methodExecute(t); } catch (Exception ex) { throw ex; }
        }
        public static List<E> channel_Exception_Throw<T, E>(T t, Predicate<T> conditionExecute, Func<T, List<E>> methodExecute)
        {
            try { return conditionExecute(t) == true ? methodExecute(t) : default(List<E>); } catch (Exception ex) { throw ex; }
        }
        #endregion

        #region no result channel process flow Exception_Ignore
        public static void channel_Exception_Throw(Action methodExecute)
        {
            try { methodExecute(); } catch (Exception ex) { throw ex; }
        }
        public static void channel_Exception_Throw<T>(T t, Action<T> methodExecute)
        {
            try { methodExecute(t); } catch (Exception ex) { throw ex; }
        }
        public static void channel_Exception_Throw<T>(T t, Predicate<T> conditionExecute, Action<T> methodExecute)
        {
            try { if (conditionExecute(t)) methodExecute(t); } catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}

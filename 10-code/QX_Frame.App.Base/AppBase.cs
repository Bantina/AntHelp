using Autofac;
using Autofac.Builder;
using Autofac.Core;
using System;
using System.Collections.Generic;

namespace QX_Frame.App.Base
{
    //author:qixiao
    //time:2017-1-2 20:45:40
    //summary: the Ioc override method

    /// <summary>
    /// the AppBase Ioc Container by AutoFac
    /// </summary>
    public abstract class AppBase : ContainerBuilder, IDependency
    {
        protected volatile static ContainerBuilder builder = null;

        #region The Singleton to new ContainerBuilder
        private static readonly object lockHelper = new object();
        static AppBase()
        {
            if (builder == null)
            {
                lock (lockHelper)
                {
                    if (builder == null)
                        builder = System.Activator.CreateInstance<ContainerBuilder>();
                }
            }
        }
        #endregion

        /// <summary>
        /// Get ContainerBuilder builder
        /// </summary>
        /// <returns>builder</returns>
        protected static ContainerBuilder GetBuilder() => builder;
        /// <summary>
        /// registerEntity
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="t"></param>
        protected static void Register<TService>(TService t) where TService : class=> builder.RegisterInstance(t).As<TService>();

        /// <summary>
        /// Register
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        protected static void Register<TService>() => builder.RegisterType<TService>();
        /// <summary>
        /// Register override
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="ITService"></typeparam>
        protected static void Register<TService, ITService>() => builder.RegisterType<TService>().As<ITService>();
        /// <summary>
        /// Register override
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delegate"></param>
        public static void Register<T>(Func<IComponentContext, T> @delegate)
        {
            if (@delegate == null)
            {
                throw new ArgumentNullException("delegate");
            }
            builder.Register<T>(((Func<IComponentContext, IEnumerable<Parameter>, T>)((c, p) => @delegate(c))));
        }
        /// <summary>
        /// Get The Ioc Container -> Factory
        /// </summary>
        /// <returns></returns>
        protected static IContainer Factory()=> builder.Build();
    }
}

using Autofac;

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
        protected volatile static ContainerBuilder builder = new ContainerBuilder();

        //#region The Singleton to new ContainerBuilder
        //private static readonly object lockHelper = new object();
        //static AppBase()
        //{
        //    if (builder == null)
        //    {
        //        lock (lockHelper)
        //        {
        //            if (builder == null)
        //                builder = System.Activator.CreateInstance<ContainerBuilder>();
        //        }
        //    }
        //}
        //#endregion

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
        protected static void RegisterEntity<TService>(TService t) where TService : class => builder.RegisterInstance(t).As<TService>();
        /// <summary>
        /// registerType
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        protected static void RegisterType<TService>() => builder.RegisterType<TService>();
        /// <summary>
        /// registerType override
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="ITService"></typeparam>
        protected static void RegisterType<TService, ITService>() => builder.RegisterType<TService>().As<ITService>();

        /// <summary>
        /// Get properties or class instance by Autofac Ioc Factory
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        protected static TService Fact<TService>()
        {
            using (var container = builder.Build())
            {
                return container.Resolve<TService>();
            }
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.App.Base
{
    public abstract class AppBase:ContainerBuilder,IDependency
    {
        protected volatile static ContainerBuilder builder=null;

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

        protected static ContainerBuilder GetBuilder() => builder;

        protected static void RegisterEntity<TService>(TService t) where TService:class => builder.RegisterInstance(t).As<TService>();

        protected static void RegisterType<TService>()=> builder.RegisterType<TService>();

        protected static void RegisterType<TService,ITService>()=> builder.RegisterType<TService>().As<ITService>();

        protected static TService Fact<TService>()
        {
            using (var container = builder.Build())
            {
                return container.Resolve<TService>();
            }
        }
    }
}

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    /// <summary>
    /// Ioc Container
    /// </summary>
    public static class IocFactory
    {
        static IocFactory()
        {
            RegisterComponents();
        }

        /// <summary>
        /// save the Ioc information.
        /// </summary>
        private static WindsorContainer _container;
        public static WindsorContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }
        /// <summary>
        /// Register Components to '_container'
        /// </summary>
        private static void RegisterComponents()
        {
            var container = new WindsorContainer();

            container.Register(Component
                .For<IWindsorContainer>()
                .Instance(container));

            #region register data visitor.
            //Assembly asmDataAccess = Assembly.Load("Gatekeeper.Toolbox.DataAccess");

            //ActivityDataVisitor
            container.Register(Component
                .For(typeof(IActivityDataVisitor))
                .ImplementedBy(typeof(ActivityDataVisitor))
                .Named("ActivityDataVisitor"));
            //container.Register(Component
            //    .For(asmDataAccess.GetType("Gatekeeper.Toolbox.DataAccess.IActivityDataVisitor"))
            //    .ImplementedBy(asmDataAccess.GetType("Gatekeeper.Toolbox.DataAccess.ActivityDataVisitor"))
            //    .Named("ActivityDataVisitor"));

            //CommonDataVisitor
            container.Register(Component
                .For(typeof(ICommonDataVisitor))
                .ImplementedBy(typeof(CommonDataVisitor))
                .Named("CommonDataVisitor"));
            //container.Register(Component
            //    .For(asmDataAccess.GetType("Gatekeeper.Toolbox.DataAccess.ICommonDataVisitor"))
            //    .ImplementedBy(asmDataAccess.GetType("Gatekeeper.Toolbox.DataAccess.CommonDataVisitor"))
            //    .Named("CommonDataVisitor"));

            //DashboardDataVisitor
            container.Register(Component
                .For(typeof(IDashboardDataVisitor))
                .ImplementedBy(typeof(DashboardDataVisitor))
                .Named("DashboardDataVisitor"));
            //container.Register(Component
            //    .For(asmDataAccess.GetType("Gatekeeper.Toolbox.DataAccess.IDashboardDataVisitor"))
            //    .ImplementedBy(asmDataAccess.GetType("Gatekeeper.Toolbox.DataAccess.DashboardDataVisitor"))
            //    .Named("DashboardDataVisitor"));

            #endregion register data access.
            
            _container = container;
        }

        /// <summary>
        /// create object
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <returns></returns>
        public static T CreateObject<T>(string key)
        {
            return _container.Resolve<T>(key);
        }

        public static T CreateObject<T>()
        {
            return _container.Resolve<T>();
        }

    }  
}

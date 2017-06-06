[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Vetstore.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Vetstore.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Vetstore.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Vetstore.Entities.IRepositories;
    using Vetstore.Persistence;
    using Vetstore.Persistence.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //UnityOfWork
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>();

            //MovieStoreContext
            kernel.Bind<VetStoreDbContext>().To<VetStoreDbContext>();

            //GenreRepository
            kernel.Bind<IUbigeoRepository>().To<UbigeoRepository>();

            //ActorRepository
            kernel.Bind<IDistritoRepository>().To<DistritoRepository>();

            //MovieRepository
            kernel.Bind<IDepartamentoRepository>().To<DepartamentoRepository>();
        }        
    }
}

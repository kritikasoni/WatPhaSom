using System.Configuration.Abstractions;
using Web.Models;
using Web.Service;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using global::Models.Repositories;
    using global::Models.Repository;
  //  using static global::Models.Repositories.OrderProcessorRepository;

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
            kernel.Bind<EfDbContext>().To<EfDbContext>();
            kernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<global::Web.Service.ProductService>().To<global::Web.Service.ProductService>();
            kernel.Bind<NewsService>().To<NewsService>();
            kernel.Bind<INewsRepository>().To<NewsRepository>();
            kernel.Bind<IReviewRepository>().To<ReviewRepository>();
            kernel.Bind<ReviewService>().To<ReviewService>();
            kernel.Bind<IOrderProcessor>().To<OrderProcessorRepository>();

        }

      
        }
}

using Ninject;
using Ninject.Web.Common.WebHost;
using SimpleNotes.Core;
using SimpleNotes.Core.Repository.Implementation;
using SimpleNotes.Core.Repository.Interface;
using SimpleNotes.Providers.Implementation;
using SimpleNotes.Providers.Interface;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleNotes
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new RepositoryModule());
            kernel.Bind<INoteRepository>().To<NoteRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAuthProvider>().To<AuthProvider>();
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            base.OnApplicationStarted();
        }
    }
}

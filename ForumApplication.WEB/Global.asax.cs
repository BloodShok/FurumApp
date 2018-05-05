
using System.Web.Mvc;
using System.Web.Routing;
using ForumApplication.Infrastructure.IoC;
using Ninject;
using AutoMapper;
using ForumApplication.DataTransferObjects.Profile;
using ForumApplication.WEB.Models.Profile;
using ForumApplication.WEB.App_Start;
using System.Web.Optimization;

namespace ForumApplication.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new ServiceLocator(new StandardKernel()));

            Mapper.Initialize(conf =>
                            {

                                conf.AddProfile(new BaseForumContainerProfile());
                                conf.AddProfile(new BaseForumContainerViewModelProfile());

                                conf.AddProfile(new NestedContainerElementsInfoProfile());

                                conf.AddProfile(new CreateUpdateViewModelProfile());
                                conf.AddProfile(new CreateUpdateProfile());


                                conf.AddProfile(new UserAccountProfile());
                                conf.AddProfile(new UserAccountViewModelProfile());

                            });
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

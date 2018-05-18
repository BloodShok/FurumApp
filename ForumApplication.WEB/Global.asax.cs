
using System.Web.Mvc;
using System.Web.Routing;
using ForumApplication.Infrastructure.IoC;
using Ninject;
using AutoMapper;
using ForumApplication.DataTransferObjects.Profile;
using ForumApplication.WEB.Models.Profile;
using ForumApplication.WEB.App_Start;
using System.Web.Optimization;
using System.Web.Http;
using Autofac.Integration.WebApi;
using ForumApplication.ServiceLayer.PostService;
using System.Reflection;
using Autofac;
using ForumApplication.ServiceLayer.ApiService;
using ForumApplication.ServiceLayer.ApiService.Interfaces;
using ForumApplication.WEB.API.Controllers;
using ForumApplication.WEB.Attributes;

namespace ForumApplication.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutofacForWebApi.Initialize();
            
           // DependencyResolver.SetResolver(new ServiceLocator(new StandardKernel()));
            
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

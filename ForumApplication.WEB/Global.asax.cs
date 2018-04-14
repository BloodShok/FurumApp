using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ForumApplication.Infrastructure.IoC;
using Ninject;
using AutoMapper;
using ForumApplication.WEB.Models;
using ForumApplication.DataTransferObjects.Profile;
namespace ForumApplication.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new ServiceLocator(new StandardKernel()));
            AutoMapper.Mapper.Initialize(conf =>
                            {
                                conf.AddProfile(new ForumProfile());
                            });
        }
    }
}

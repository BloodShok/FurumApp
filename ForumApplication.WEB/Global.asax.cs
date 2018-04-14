using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ForumApplication.Infrastructure.IoC;
using Ninject;
using AutoMapper;
using ForumApplication.DataLayer.ProfileDtoModels.QueryObjects;
using ForumApplication.WEB.Models;
using ForumApplication.Infrastructure.MapperConfig;

namespace ForumApplication.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new ServiceLocator(new StandardKernel()));
            MappingConfiguration.Initialize();
        }
    }
}

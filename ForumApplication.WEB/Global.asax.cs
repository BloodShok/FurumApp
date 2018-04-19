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
using ForumApplication.WEB.Models.Profile;

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

                                conf.AddProfile(new TopicViewModelProfile());

                               
                                conf.AddProfile(new PostViewModelProfile());

                                conf.AddProfile(new UserPostInfoDtoProfile());
                                conf.AddProfile(new UserPostInfoViewModelProfile());

                                conf.AddProfile(new NestedContainerElementsInfoProfile());
                                conf.AddProfile(new SaveNewForumContainerProfile());
                                conf.AddProfile(new HelpersProfile());
                            });
        }
    }
}

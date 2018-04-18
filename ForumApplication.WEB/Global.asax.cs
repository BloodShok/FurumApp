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
                                
                                conf.AddProfile(new ForumProfile());
                                conf.AddProfile(new ForumViewModelProfile());

                                conf.AddProfile(new SectionProfile());
                                conf.AddProfile(new SectionViewModelProfile());

                                conf.AddProfile(new SectionListProfie());
                                conf.AddProfile(new SectionListViewModelProfile());

                                conf.AddProfile(new TopicProfile());
                                conf.AddProfile(new TopicViewModelProfile());

                                conf.AddProfile(new PostDtoProfile());
                                conf.AddProfile(new PostViewModelProfile());

                                conf.AddProfile(new UserPostInfoDtoProfile());
                                conf.AddProfile(new UserPostInfoViewModelProfile());

                                conf.AddProfile(new NestedContainerElementProfile());
                                conf.AddProfile(new SaveNewForumContainerProfile());
                            });
        }
    }
}

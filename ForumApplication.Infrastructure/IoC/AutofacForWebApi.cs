using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac;
using ForumApplication.DataLayer.DataContext;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.ServiceLayer.AccountService;
using ForumApplication.ServiceLayer.ApiService.Interfaces;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.ServiceLayer.PostService;
using ForumApplication.ServiceLayer.SectionListService;
using ForumApplication.ServiceLayer.SectionService;
using ForumApplication.ServiceLayer.TopicService;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using ForumApplication.DataLayer.Repository.UserAccountManagers;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ForumApplication.ServiceLayer.ApiService;

namespace ForumApplication.Infrastructure.IoC
{
    public class AutofacForWebApi
    {
       
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.Load("ForumApplication.WEB"));
            builder.RegisterControllers(Assembly.Load("ForumApplication.WEB"));

            LoadDependences(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void  LoadDependences(ContainerBuilder builder)
        {
            builder.RegisterType<PostApiService>().As<IPostApiService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<ForumContext>().As<DbContext> ().InstancePerRequest();

            builder.RegisterType<ForumService>().As<IForumService>();
            builder.RegisterType<SectionService>().As<ISectionService>();
            builder.RegisterType<SectionListService>().As<ISectionListService>();
            builder.RegisterType<TopicService>().As<ITopicService>();
            builder.RegisterType<PostService>().As<IPostService>();

            builder.RegisterType<ForumRepository>().As<IForumRepository>();
            builder.RegisterType<SectionListRepository>().As<ISectionListRepository>();
            builder.RegisterType<SectionRepository>().As<ISectionRepository>();
            builder.RegisterType<TopicRepository>().As<ITopicRepository>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<UserProfileRepository>().As<IUserProfileRepository>();
            builder.Register(x => HttpContext.Current.GetOwinContext().GetUserManager<UserAccountManager>()).As<IAccountManager>();
            builder.Register(x => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(x => HttpContext.Current.GetOwinContext().GetUserManager<UserRoleManager>()).As<IRoleManager>();
        }
    }
}

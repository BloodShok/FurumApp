using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ForumApplication.DataLayer.DataContext;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.ServiceLayer.PostService;
using ForumApplication.ServiceLayer.SectionListService;
using ForumApplication.ServiceLayer.SectionService;
using ForumApplication.ServiceLayer.TopicService;
using Ninject;
using Ninject.Web.Common;

namespace ForumApplication.Infrastructure.IoC
{
   public class ServiceLocator : IDependencyResolver
    {
        IKernel _kernel;
        public ServiceLocator(IKernel kernel)
        {
            _kernel = kernel;
            AddBinding();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void AddBinding()
        {
            _kernel.Bind<DbContext>().To<ForumContext>().InRequestScope();

            _kernel.Bind<IForumService>().To <ForumService>();
            _kernel.Bind<ISectionService>().To<SectionService>();
            _kernel.Bind<ISectionListService>().To<SectionListService>();
            _kernel.Bind<ITopicService>().To<TopicService>();
            _kernel.Bind<IPostService>().To<PostService>();

            _kernel.Bind<IForumRepository>().To<ForumRepository>();
            _kernel.Bind<ISectionListRepository>().To<SectionListRepository>();
            _kernel.Bind<ISectionRepository>().To<SectionRepository>();
            _kernel.Bind<ITopicRepository>().To<TopicRepository>();
            _kernel.Bind<IPostRepository>().To<PostRepository>();
           
            
        }
    }
}

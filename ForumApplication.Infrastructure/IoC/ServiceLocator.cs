using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ForumApplication.DataAccessLayer.DataContext;
using Ninject;

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
            _kernel.Bind<DbContext>().To<ForumContext>();
        }
    }
}

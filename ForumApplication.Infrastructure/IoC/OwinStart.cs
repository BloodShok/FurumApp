using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.DataLayer.DataContext;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataLayer.Repository.UserAccountManagers;
using ForumApplication.ServiceLayer.AccountService;
using Owin;

namespace ForumApplication.Infrastructure.IoC
{
    class OwinStart
    {
        
        public OwinStart()
        {
            
        }
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(ForumContext.Create);
            app.CreatePerOwinContext<UserAccountManager>(UserAccountManager.Create);
            
        }

    }
}

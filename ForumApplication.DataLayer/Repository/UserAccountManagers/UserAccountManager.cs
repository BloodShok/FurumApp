using ForumApplication.DataLayer.DataContext;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.Domain.Entitys;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository.UserAccountManagers
{
    public class UserAccountManager : UserManager<UserAccount>, IAccountManager
    {
        
        public UserAccountManager(IUserStore<UserAccount> userStore) : base(userStore)
        {
           
        }

        public IdentityResult CreateUserAccount(UserAccount userAccount, string password)
        {
            return this.Create(userAccount, password);
        }

        public IList<UserAccount> GetUserAccounts()
        {
            return this.Users.ToList();           
        }

        public static UserAccountManager Create(
            IdentityFactoryOptions<UserAccountManager> options,
            IOwinContext context)
        {
            DbContext forumContext = context.Get<DbContext>();
            UserAccountManager manager = new UserAccountManager(new UserStore<UserAccount>(forumContext));

            return manager;
        }

    }
}

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
    public class UserRoleManager :RoleManager<Role>, IRoleManager
    {
        public UserRoleManager(RoleStore<Role> store) : base(store)
        {

        }

        public static UserRoleManager Create(
            IdentityFactoryOptions<UserRoleManager> options,
                IOwinContext context)
        {
            DbContext db = context.Get<DbContext>();
            return new UserRoleManager(new RoleStore<Role>(db));
        }

        public IdentityResult CreateRole(Role role)
        {
            return this.Create(role);
        }

        public Role FindRoleByName(string roleName)
        {
            return this.FindByName(roleName);
        }
       
    }
}

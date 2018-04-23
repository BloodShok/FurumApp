using ForumApplication.Domain.Entitys;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface IAccountManager 
    {
        IdentityResult CreateUserAccount(UserAccount userAccount, string password);
        IList<UserAccount> GetUserAccounts();
    }
}

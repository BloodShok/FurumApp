using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface IAccountManager 
    {
        IdentityResult CreateUserAccount(UserAccount userAccount, string password);
        IList<UserAccount> GetUserAccountsList();
        IList<UserAccount> GetUserAccountsList(int startPage, int size);
        UserAccount FindUser(string login, string password);
        ClaimsIdentity CreateIdentity(UserAccount user);
        int GetCountOfUsersAccounts();
        UserAccount GetUserAccount(string accId);
        string GetUserRole(string userId);
        IList<string> GetUserRolesList(string userId);
        void UpdateProfile(UserProfile updateUserProfile, string accountId);
        UserAccount FindUser(string userName);
        void AddUserToRole(string userName, string role);
        bool IsAccountActive(string login);
        void DisableAccount(string Id);
        void EnableAccount(string Id);
        void UpdateAccount(UserAccount updateUserAccount);
    }
}

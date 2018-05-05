using ForumApplication.DataLayer.DataContext;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
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

        public IList<UserAccount> GetUserAccountsList()
        {
            return this.Users.Include(x => x.UserProfile).ToList();           
        }

        public static UserAccountManager Create(
            IdentityFactoryOptions<UserAccountManager> options,
            IOwinContext context)
        {
            DbContext forumContext = context.Get<DbContext>();
            UserAccountManager manager = new UserAccountManager(new UserStore<UserAccount>(forumContext));

            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireUppercase = true
            };

            manager.UserValidator = new UserValidator<UserAccount>(manager)
            {
                RequireUniqueEmail = true
            };
            return manager;
            
        }

        public UserAccount FindUser(string login, string password)
        {
            return this.Find(login, password);
        }

        public ClaimsIdentity CreateIdentity(UserAccount user)
        {
            return this.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public UserAccount GetUserAccount(string accId)
        {
            return Users
                .Include(x => x.UserProfile)
                .FirstOrDefault(us => us.Id.Equals(accId));
        }

        public string GetUserRole(string userId)
        {
            return this.GetRoles(userId).FirstOrDefault();
        }

        public void UpdateProfile(UserProfile updateUserProfile, string accountId)
        {
            var accountForUpdate = this.Users
                .Include(x => x.UserProfile)
                .FirstOrDefault(x => x.Id.Equals(accountId));

            accountForUpdate.UserProfile.BirthDay = updateUserProfile.BirthDay;
            accountForUpdate.UserProfile.Location = updateUserProfile.Location;
            accountForUpdate.UserProfile.Gender = updateUserProfile.Gender;
            accountForUpdate.UserProfile.SomeInformation = updateUserProfile.SomeInformation;

            this.Update(accountForUpdate);
        }

        public IList<UserAccount> GetUserAccountsList(int startPage, int size)
        {
            var users = this.Users
                .Include(x => x.UserProfile)
                .OrderByDescending(x => x.UserProfile.DateRegistration)
                .Page(startPage, size)
                .ToList();

            return users;
        }

        public IList<string> GetUserRolesList(string userId)
        {
            return this.GetRoles(userId).ToList();
        }

        public UserAccount FindUser(string userName)
        {
            return this.FindByName(userName);
        }

        public void AddUserToRole(string userName, string role)
        {
            var userId = this.FindByName(userName).Id;
            this.AddToRole(userId, role);
        }

        public int GetCountOfUsersAccounts()
        {
            return this.Users.Count();
        }

        public bool IsAccountActive(string login)
        {
            var accountUser = this.FindByName(login);
            return accountUser.IsActive;
        }

        public void DisableAccount(string Id)
        {
            var account = this.FindById(Id);
            account.IsActive = false;
            this.Update(account);
        }

        public void EnableAccount(string Id)
        {
            var account = this.FindById(Id);
            account.IsActive = true;
            this.Update(account);
        }

        public void UpdateAccount(UserAccount updateUserAccount)
        {
            var account = this.Users
                .Include(x => x.UserProfile)
                .FirstOrDefault(x => x.Id
                                .Equals(updateUserAccount.Id));

            account.IsActive = updateUserAccount.IsActive;
            account.UserName = updateUserAccount.UserName;
            UpdateProfileFilds(account.UserProfile, updateUserAccount.UserProfile);
            this.Update(account);
        }

        private static void UpdateProfileFilds(UserProfile profileForUpdate, UserProfile profileWithUpdateData)
        {
            profileForUpdate.BirthDay = profileWithUpdateData.BirthDay;
            profileForUpdate.DateRegistration = profileWithUpdateData.DateRegistration;
            profileForUpdate.Gender = profileWithUpdateData.Gender;
            profileForUpdate.Image = profileWithUpdateData.Image;
            profileForUpdate.Location = profileWithUpdateData.Location;
            profileForUpdate.SomeInformation = profileWithUpdateData.SomeInformation;
        }
    }
}

using System;
using System.Collections.Generic;
using AutoMapper;
using ForumApplication.Domain.Entitys;
using ForumApplication.DataTransferObjects;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using ForumApplication.DataLayer.Interfaces;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin.Security;

using Microsoft.AspNet.Identity.Owin;


namespace ForumApplication.ServiceLayer.AccountService
{
    public class AccountService : IAccountService
    {
        IAccountManager _userManager;
        IRoleManager _roleManager;

        public int CountUserAccounts => _userManager.GetCountOfUsersAccounts();

        public AccountService(IAccountManager accountManager, IRoleManager roleManager)
        {
            _userManager = accountManager;
            _roleManager = roleManager;
                //new UserAccountManager(new UserStore<UserAccount>(context));
        }

        public IdentityResult CreateUserAccount(CreateAccountDto createAccountDto)
        {
            var userAccount = Mapper.Map<UserAccount>(createAccountDto);
            userAccount.UserProfile = new UserProfile();
            userAccount.UserProfile.DateRegistration = DateTime.Now;

            IdentityResult CreateIdentityReuslt = _userManager.CreateUserAccount(userAccount, createAccountDto.Password);

            if(CreateIdentityReuslt.Succeeded)
            {
                _userManager.AddUserToRole(createAccountDto.UserName, createAccountDto.RoleName);
            }
                //_userManager.Create(userAccount, createAccountDto.Password);
                return CreateIdentityReuslt;
            

        }

        public IList<UserAccountInfoDto> GetUserAccountsList()                                  
        {
            var ListOfUserAccounts = _userManager.GetUserAccountsList() ;

            return Mapper.Map<IList<UserAccountInfoDto>>(ListOfUserAccounts);
        }


        //public static AccountService Create(IAccountManager accountManager)
        //{
        //    return new AccountService(accountManager);
        //}

        public bool CheckUser(LoginModelDto loginModelDto)
        {
            var user = _userManager.FindUser(loginModelDto.Login,loginModelDto.Password);

            return user == null ? false : true;
           
        }

        public ClaimsIdentity GetClaimIdentity(LoginModelDto loginModelDto)
        {
            var user = _userManager.FindUser(loginModelDto.Login, loginModelDto.Password);

            return _userManager.CreateIdentity(user); 
        }

        public UserAccountInfoDto GetUserAccountInfo(string accId)
        {
            var userAccaount = _userManager.GetUserAccount(accId);

            var UserAccountDto = Mapper.Map<UserAccountInfoDto>(userAccaount);
            UserAccountDto.Role = _userManager.GetUserRole(accId);
            return UserAccountDto;
        }

        public void UpdateUserProfile(UpdateUserProfileDto updateUserProfileDto)
        {
            var updateUserProfile = Mapper.Map<UserProfile>(updateUserProfileDto);

            _userManager.UpdateProfile(updateUserProfile, updateUserProfileDto.AccountId);
            
        }

        public IList<JtableAccountInfoDto> GetUserAccountsListForJTable(int startPage, int size)
        {
            var listOfUserAccounts = _userManager.GetUserAccountsList(startPage, size);

            var jtableAccountInfoDto = Mapper.Map<IList<JtableAccountInfoDto>>(listOfUserAccounts);


            foreach (var account in jtableAccountInfoDto)
            {
                account.Role = _userManager.GetUserRole(account.Id);

            }
            return jtableAccountInfoDto;
        }

        public bool IsAccountActive(LoginModelDto loginDto)
        {
            return _userManager.IsAccountActive(loginDto.Login);
        }

        public void DisableAccount(string Id)
        {
            _userManager.DisableAccount(Id);
        }

        public void EnableAccount(string Id)
        {
            _userManager.EnableAccount(Id);
        }

        public IdentityResult CreateUserAccount(JtableCreateAccountDto jTableCreatUserAccountDto)
        {
            var newAccount = Mapper.Map<UserAccount>(jTableCreatUserAccountDto);

            IdentityResult CreateIdentityReuslt = _userManager.CreateUserAccount(newAccount, jTableCreatUserAccountDto.Password);

            if (CreateIdentityReuslt.Succeeded)
            {
                _userManager.AddUserToRole(jTableCreatUserAccountDto.UserName, jTableCreatUserAccountDto.RoleName);
            }

            return CreateIdentityReuslt;
        }

        public void UpdateUserProfile(JtableCreateAccountDto jTableUpdateAccountDto)
        {
            var updateUserAccount = Mapper.Map<UserAccount>(jTableUpdateAccountDto);

            _userManager.UpdateAccount(updateUserAccount);
        }
    }
}

using System;
using System.Collections.Generic;
using AutoMapper;
using ForumApplication.Domain.Entitys;
using ForumApplication.DataTransferObjects;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using ForumApplication.DataLayer.Interfaces;

namespace ForumApplication.ServiceLayer.AccountService
{
    public class AccountService : IAccountService
    {
        IAccountManager _userManager;
  
        public AccountService(IAccountManager accountManager)
        {
            _userManager = accountManager;
                //new UserAccountManager(new UserStore<UserAccount>(context));
        }

        public IdentityResult CreateUserAccount(CreateAccountDto createAccountDto)
        {
            var userAccount = Mapper.Map<UserAccount>(createAccountDto);



            IdentityResult CreateIdentityReuslt = _userManager.CreateUserAccount(userAccount, createAccountDto.Password);
                //_userManager.Create(userAccount, createAccountDto.Password);
                return CreateIdentityReuslt;
            

        }

        public IList<UserAccountInfoDto> GetUserAccounts()                                  
        {
            var ListOfUserAccounts = _userManager.GetUserAccounts() ;

            return Mapper.Map<IList<UserAccountInfoDto>>(ListOfUserAccounts);
        }


        public static AccountService Create(IAccountManager accountManager)
        {
            return new AccountService(accountManager);
        }
    }
}

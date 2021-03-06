﻿using AutoMapper;
using ForumApplication.ServiceLayer.AccountService;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ForumApplication.WEB.Models.AccountViewModel;
using ForumApplication.WEB.Models.AdministratorViewModel;
using ForumApplication.DataTransferObjects.AccountDto;
using ForumApplication.Infrastructure.Consts;

namespace ForumApplication.WEB.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        IAuthenticationManager _authenticationManager;
        public AccountController(IAccountService accountService, IAuthenticationManager authManager)
        {
            _accountService = accountService;
            _authenticationManager = authManager;
        }

        [HttpGet]
        public ActionResult SignUp(string ReturnUrl)
        {
            TempData[TempDataIndexConsts.ReturnUrl] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(CreateAccountViewModel createAccountView)
        {
            var createAccountDto = Mapper.Map<CreateAccountDto>(createAccountView);
            createAccountDto.Image = UserImages.User;
            createAccountDto.RoleName = RoleConsts.User;
            var statusCreated = _accountService.CreateUserAccount(createAccountDto);

            if (statusCreated.Succeeded)
            {
                return RedirectToAction("List","Forum");
            }
            else
            {
                foreach (var item in statusCreated.Errors)
                {
                    ModelState.AddModelError("", item);
                }

                return View();
            }
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

                var LoginDto = Mapper.Map<LoginModelDto>(loginModel);

                if (!_accountService.CheckUser(LoginDto))
                {
                    ModelState.AddModelError("", ErrorConstans.LoginPasswdError);

                    TempData[TempDataIndexConsts.Error] = ErrorConstans.LoginPasswdError;
                    return RedirectPermanent(Request.UrlReferrer.ToString());
                }

                if(!_accountService.IsAccountActive(LoginDto))
                {
                    TempData[TempDataIndexConsts.Status] = ErrorConstans.DeleteAccountError;
                    return RedirectPermanent(Request.UrlReferrer.ToString());
                }


                var CliemIdentity = _accountService.GetClaimIdentity(LoginDto);
                _authenticationManager.SignOut();

                _authenticationManager
                    .SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false,

                    }, CliemIdentity);

                if(ReturnUrl != "")
                {
                    return Redirect(ReturnUrl);
                }

                return Redirect(Request.UrlReferrer.ToString());
        }
           
        

        [HttpGet]
        public ActionResult LogOut()
        {
            
            _authenticationManager.SignOut();
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        [Authorize]
        public ActionResult UpdateProfile()
        {
            var accId = _authenticationManager.User.Identity.GetUserId();
            var userAccountInfoDto = _accountService.GetUserAccountInfo(accId);
            var UserAccountInfoViewModel = Mapper.Map<UserAccountsInfoViewModel>(userAccountInfoDto);
            return View(UserAccountInfoViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateProfile (UpdateUserProfileViewModel updateUserProfile)
        {
         
            var updateUserProfileDto = Mapper.Map<UpdateUserProfileDto>(updateUserProfile);
            _accountService.UpdateUserProfile(updateUserProfileDto);

            return RedirectToAction("ShowProfile");
        }


        [HttpGet]
        [Authorize]
        public ActionResult ShowProfile(string Id)
        {
            UserAccountInfoDto userAccountInfoDto;
            if (Id == null)
            {
                userAccountInfoDto = _accountService.GetUserAccountInfo(User.Identity.GetUserId());
            }
            else
            {
                userAccountInfoDto = _accountService.GetUserAccountInfo(Id);
            }
            
            var UserAccountInfoViewModel = Mapper.Map<UserAccountsInfoViewModel>(userAccountInfoDto);
            return View(UserAccountInfoViewModel);
        }

    }
}
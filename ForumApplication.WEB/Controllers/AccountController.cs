using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.ServiceLayer.AccountService;
using ForumApplication.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.IO;
using System;
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
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(CreateAccountViewModel createAccountView)
        {
            var createAccountDto = Mapper.Map<CreateAccountDto>(createAccountView);
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
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
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

                return Redirect(Request.UrlReferrer.ToString());
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
            var userAccountInfoDto = _accountService.GetUserAccountInfo(Id);
            var UserAccountInfoViewModel = Mapper.Map<UserAccountsInfoViewModel>(userAccountInfoDto);
            return View(UserAccountInfoViewModel);
        }

    }
}
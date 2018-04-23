using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.ServiceLayer.AccountService;
using ForumApplication.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace ForumApplication.WEB.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //public AccountController() : this(DependencyResolver.Current.GetService<IAccountService>()) { }

       [Authorize]
        //GET: Account
        public ActionResult Users()
        {
            var profilesDto = _accountService.GetUserAccounts();
            var profilesViewModel = Mapper.Map<List<UserAccountsInfoViewModel>>(profilesDto);
            return View(profilesViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateAccountViewModel createAccountView)
        {
            var createAccountDto = Mapper.Map<CreateAccountDto>(createAccountView);
            var statusCreated = _accountService.CreateUserAccount(createAccountDto);

            if (statusCreated.Succeeded)
            {
                return RedirectToAction("Users");
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
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(AuthenticationViewModel authenticationViewModel)
        {

            return View();
        }
    }
}
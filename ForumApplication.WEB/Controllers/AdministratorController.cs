using ForumApplication.ServiceLayer.AccountService;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumApplication.WEB.Models;
using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.WEB.Models.AdministratorViewModel;
using ForumApplication.DataTransferObjects.AccountDto;
using ForumApplication.Infrastructure.Consts;

namespace ForumApplication.WEB.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdministratorController : Controller
    {
        IAccountService _accountService;
        IAuthenticationManager _authenticationManager;

        public AdministratorController(IAccountService accountService, IAuthenticationManager authManager)
        {
            _accountService = accountService;
            _authenticationManager = authManager;
        }

        // GET: Adninistrator

        [HttpGet]
        public ActionResult UserManager()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserLists(int jtStartIndex = 0, int jtPageSize = 10)
        {
            var userAccountDto = _accountService.GetUserAccountsListForJTable(jtStartIndex, jtPageSize);

            var usersAccountsJTableViewModel = Mapper.Map<ICollection<TableAccountInfoViewModel>>(userAccountDto);


            return Json(new { Result = "OK", Records = usersAccountsJTableViewModel, TotalRecordCount = _accountService.CountUserAccounts });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public JsonResult DeleteAccount(string Id)
        {
            _accountService.DisableAccount(Id);

            return Json(new { Result = "OK" });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public JsonResult CreateAccount(TableCreateAccountViewModel newAccountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ErrorConstans.ValidationError });
            }

            newAccountViewModel.Image = ImageByRoleName( newAccountViewModel.RoleName);

                var JTableCreatUserAccountDto = Mapper.Map<TableCreateAccountDto>(newAccountViewModel);
                var createResult = _accountService.CreateUserAccount(JTableCreatUserAccountDto);

                if (createResult.Succeeded)
                {
                    var newUser = JTableCreatUserAccountDto;
                    return Json(new { Result = "OK", Record = newUser });
                }
                else
                {
                    return Json(new { Result = "ERROR", Message = createResult.Errors });
                }
            }
            
        


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public JsonResult UpdateAccount(TableUpdateAccountViewModel updateAccountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ErrorConstans.ValidationError });
            }


            var updateAccountDto = Mapper.Map<TableUpdateAccountDto>(updateAccountViewModel);

            updateAccountDto.Image = ImageByRoleName(updateAccountViewModel.RoleName);

            _accountService.UpdateUserProfile(updateAccountDto);
            return Json(new
            {
                Result = "OK"
            });
        }
        private string ImageByRoleName(string RoleName)
        {
            switch (RoleName)
            {
                case "User":
                    return UserImages.User;
                case "Moderator":
                    return UserImages.Moderator;
                default:
                    return UserImages.User;
            }

        }
    }
}
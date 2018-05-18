using AutoMapper;
using ForumApplication.ServiceLayer.AccountService;
using ForumApplication.WEB.Models.AccountViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using ForumApplication.Infrastructure.Consts;
using ForumApplication.DataTransferObjects.AccountDto;
using Microsoft.AspNet.Identity;
using System.Xml.Linq;
using System.Web.Http.Description;
using ForumApplication.WEB.Attributes;

namespace ForumApplication.WEB.Controllers.API
{
    public class ProfileController : ApiController
    {
        IAccountService _accountService;
        public ProfileController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [ApiAuthorization]
        public List<UserAccountsInfoViewModel> Get()
        {
            var userProfileDtoList = _accountService.GetUserAccountsList();
            return Mapper.Map<List<UserAccountsInfoViewModel>>(userProfileDtoList);
        }


        [ApiAuthorization]
        public UserAccountsInfoViewModel Get(string id)
        {
            var userProfileDto = _accountService.GetUserAccountInfo(id);
            return Mapper.Map<UserAccountsInfoViewModel>(userProfileDto);
        }

        
        [ApiAuthorization]
        [ResponseType(typeof(string))]
        public IHttpActionResult Post(CreateAccountViewModel account)
        {
            var newAccDto = Mapper.Map<CreateAccountDto>(account);
            newAccDto.RoleName = RoleConsts.User;
            newAccDto.Image = RoleConsts.User;
            var result = _accountService.CreateUserAccount(newAccDto);

            if(result.Succeeded)
                return Ok(new { Message = "User was created" });

            return Content(HttpStatusCode.BadRequest, new { Message = result.Errors });
            
        }

        [ApiAuthorization]
        [ResponseType(typeof(string))]
        public IHttpActionResult Put(UpdateUserProfileDto updateProfile)
        {
            if (updateProfile.AccountId.Equals(RequestContext.Principal.Identity.GetUserId()))
            {
                _accountService.UpdateUserProfile(updateProfile);
                return Ok(new { Message = "Account was update succes" });
            }

            return Content(HttpStatusCode.Forbidden, new { Message = "Execute access forbidden" });
        }


        [HttpGet]
        [Route("api/ForumApp/me")]
        [ApiAuthorization]
        public UserAccountsInfoViewModel GetUser()
        {
            var currentUserId = RequestContext.Principal.Identity.GetUserId();
            var currentUser = _accountService.GetUserAccountInfo(currentUserId);
            return Mapper.Map<UserAccountsInfoViewModel>(currentUser);
        }
    }
}
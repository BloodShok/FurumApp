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

namespace ForumApplication.WEB.Controllers.API
{
    public class ProfileController : ApiController
    {
        IAccountService _accountService;
        public ProfileController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "Administrator")]
        // GET api/<controller>
        public List<UserAccountsInfoViewModel> Get()
        {
            var userProfileDtoList = _accountService.GetUserAccountsList();
            return Mapper.Map<List<UserAccountsInfoViewModel>>(userProfileDtoList);
        }


        // GET api/<controller>/5
        public UserAccountsInfoViewModel Get(string id)
        {
            var userProfileDto = _accountService.GetUserAccountInfo(id);
            return Mapper.Map<UserAccountsInfoViewModel>(userProfileDto);
        }

        // POST api/<controller>
        public IHttpActionResult Post(CreateAccountViewModel account)
        {
            var newAccDto = Mapper.Map<CreateAccountDto>(account);
            newAccDto.RoleName = RoleConsts.User;
            newAccDto.Image = RoleConsts.User;
            var result = _accountService.CreateUserAccount(newAccDto);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User was created" });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { Message = result.Errors });
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(UpdateUserProfileDto updateProfile)
        {
            if (updateProfile.AccountId.Equals(RequestContext.Principal.Identity.GetUserId()))
            {
                _accountService.UpdateUserProfile(updateProfile);
                return Ok(new { Message = "Account was update succes" });

            }
            else
                return Content(HttpStatusCode.Forbidden, new { Message = "Execute access forbidden" });
        }


        [HttpGet]
        [Route("api/ForumApp/me")]
        [Authorize]
        public UserAccountsInfoViewModel GetUser()
        {
            var currentUserId = RequestContext.Principal.Identity.GetUserId();
            var currentUser = _accountService.GetUserAccountInfo(currentUserId);
           
                return Mapper.Map<UserAccountsInfoViewModel>(currentUser);


        }
    }
}
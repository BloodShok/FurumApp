using ForumApplication.DataTransferObjects;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.AccountService
{
    public interface IAccountService
    {
        IList<UserAccountInfoDto> GetUserAccounts();
        IdentityResult CreateUserAccount(CreateAccountDto createAccountDto);
    }
}

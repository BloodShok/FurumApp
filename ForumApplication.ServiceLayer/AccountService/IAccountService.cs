using ForumApplication.DataTransferObjects;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.AccountService
{
    public interface IAccountService
    {
        int CountUserAccounts { get; }

        IList<JtableAccountInfoDto> GetUserAccountsListForJTable(int startPage, int size);
        IdentityResult CreateUserAccount(CreateAccountDto createAccountDto);
        IList<UserAccountInfoDto> GetUserAccountsList();
        bool CheckUser(LoginModelDto loginModelDto);
        ClaimsIdentity GetClaimIdentity(LoginModelDto loginModelDto);
        UserAccountInfoDto GetUserAccountInfo(string accId);
        void UpdateUserProfile(UpdateUserProfileDto updateUserProfileDto);
        bool IsAccountActive(LoginModelDto loginDto);
        void DisableAccount(string Id);
        void EnableAccount(string Id);
        IdentityResult CreateUserAccount(JtableCreateAccountDto jTableCreatUserAccountDto);
        void UpdateUserProfile(JtableUpdateAccountDto jTableUpdateAccountDto);
    }
}

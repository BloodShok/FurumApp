using ForumApplication.Domain.Entitys;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
namespace ForumApplication.DataLayer.Repository.UserAccountManagers
{
    public class UserAuthProviderApi : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserAccountManager accountManager =
                context.OwinContext.Get<UserAccountManager>("AspNet.Identity.Owin:"
                + typeof(UserAccountManager).AssemblyQualifiedName);

            UserAccount user = await accountManager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("AuthorizationError", "The username or password is incorrect");
            }
            else
            {
                ClaimsIdentity ident = await accountManager.CreateIdentityAsync(user, "Custom");
                AuthenticationTicket ticket = new AuthenticationTicket(ident, new AuthenticationProperties());
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(ident);
            }
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}
    


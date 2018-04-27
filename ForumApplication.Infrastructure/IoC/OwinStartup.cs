﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ForumApplication.DataLayer.DataContext;
using ForumApplication.DataLayer.Repository.UserAccountManagers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ForumApplication.Infrastructure.IoC.OwinStartup))]

namespace ForumApplication.Infrastructure.IoC
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(ForumContext.Create);
            app.CreatePerOwinContext<UserAccountManager>(UserAccountManager.Create);
            app.CreatePerOwinContext<UserRoleManager>(UserRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/SignUp"),
            });
        }
    }
}

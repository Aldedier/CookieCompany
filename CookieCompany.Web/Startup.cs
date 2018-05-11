using CookieCompany.Web;
using Microsoft.Owin;

[assembly : OwinStartup(typeof(Startup))]

namespace CookieCompany.Web
{
    using Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity;
    using System.Web.Helpers;
    using System.Security.Claims;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    LoginPath = new PathString("/Cuenta/LogIn"),
                    LogoutPath = new PathString("/Cuenta/LogOut"),
                    CookieName = "ASPAUTH",
                    SlidingExpiration = true,
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    AuthenticationMode = AuthenticationMode.Active
                });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }
    }
}
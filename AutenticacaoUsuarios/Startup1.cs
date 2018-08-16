using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(AutenticacaoUsuarios.Startup1))]

namespace AutenticacaoUsuarios
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Authentication/Login")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(App.UI.MVC.Startup))]

namespace App.UI.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType="ApplicationCookie",
                    CookieName="AuthAppChinook",
                    ExpireTimeSpan=TimeSpan.FromSeconds(240),
                    LoginPath=new PathString("/Security/Login")
                }                
            );
        }
    }
}

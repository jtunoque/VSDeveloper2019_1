using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace App.UI.MVC.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string usuario,
                    string clave, string returnUrl)
        {
            //Validar en base de datos

            var claims = new List<Claim>();
            //Agregando los claims que se van 
            //a necesitar en la aplicación
            claims.Add(new Claim(ClaimTypes.Name, "Javier Tunoque"));
            claims.Add(new Claim("UsuarioID", "1"));

            var identity = new ClaimsIdentity(claims, "ApplicationCookie");
            //Llama a los componentes de Owin para iniciar el proceso
            //de generación de la cookie de autenticación
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignIn(identity); //Crea la cookie

            return Redirect(returnUrl ?? "~/");
        }
    }
}
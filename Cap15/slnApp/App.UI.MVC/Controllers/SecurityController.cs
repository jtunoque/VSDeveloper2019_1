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
            var seguridadClient = new SeguridadServices.SeguridadServicesClient();
            var usuarioFound = seguridadClient.ValidarAcceso(usuario, clave);

            if (usuarioFound == null) //Si el usuario no existe se queda en Login
            {
                return RedirectToAction("Login");
            }
            else
            {
                var claims = new List<Claim>();
                //Agregando los claims que se van 
                //a necesitar en la aplicación
                claims.Add(
                    new Claim(ClaimTypes.Name, $"{usuarioFound.Nombres} {usuarioFound.Apellidos}"));

                claims.Add(new Claim("UsuarioID", $"{usuarioFound.UsuarioId}"));

                //**************************************************
                //Configurando los roles para la implementación
                //del mecanismo de autorización
                string[] roles = usuarioFound.Roles.Split(';');
                foreach(string rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
                //***************************************************


                var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                //Llama a los componentes de Owin para iniciar el proceso
                //de generación de la cookie de autenticación
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(identity); //Crea la cookie

                return Redirect(returnUrl ?? "~/");
            }
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}
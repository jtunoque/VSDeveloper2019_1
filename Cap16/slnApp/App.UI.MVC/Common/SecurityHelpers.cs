using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.UI.MVC.Common
{
    public class SecurityHelpers
    {
        public static IEnumerable<Claim> GetClaimsByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = identity.Claims.Where(item => item.Type == type).ToList();

            return claims;
        }

        public static string GetUserFullName()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetusuarioID()
        {
            var claimValue = GetClaimsByType("UsuarioID").FirstOrDefault()!=null?
                     Convert.ToInt32(GetClaimsByType("UsuarioID").FirstOrDefault().Value):0;

            return claimValue;
        }

        public static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool IsAdmin()
        {
            return HttpContext.Current.User.IsInRole("admin");
        }

        public static bool IsSupervisor()
        {
            return HttpContext.Current.User.IsInRole("supervisor");
        }


    }
}
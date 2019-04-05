using App.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.MVC.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            List<string> artists = new List<string>();
            artists.Add("Aeroesmith");
            artists.Add("Robbin Williams");
            artists.Add("Soda Stereo");

            ViewBag.ArtistList = artists;

            return View();
        }

        public ActionResult Listado(string filtroByNombre)
        {
            var wcfClient = new MantenimientosServices.MantenimientosServicesClient();
            var listado = wcfClient.GetArtistAll(filtroByNombre);
            //Vistas fuertemente tipadas o strong-types
            return View(listado);
        }
    }
}
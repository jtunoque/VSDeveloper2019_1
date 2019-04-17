using App.Entities.Base;
using App.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.MVC.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {

        MantenimientosServices.MantenimientosServicesClient wcfClient = null;

        public ArtistController()
        {
            wcfClient = new MantenimientosServices.MantenimientosServicesClient();

        }


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
            
            var listado = wcfClient.GetArtistAll(filtroByNombre);
            //Vistas fuertemente tipadas o strong-types
            return View(listado);
        }

        public ActionResult Buscar(string filtroByNombre)
        {
            var listado = wcfClient.GetArtistAll(filtroByNombre);
            System.Threading.Thread.Sleep(1000);
            //Vistas fuertemente tipadas o strong-types
            return PartialView("ListadoResultado", listado);
        }

        public ActionResult Edit(int id)
        {
            var artist = wcfClient.GetArtist(id);

            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist model)
        {
            var artist = wcfClient.SaveArtist(model);

            //Redireccionamos a la acción que muestra el listado de artistas
            return RedirectToAction("Listado");
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Artist model)
        {
            var artist = wcfClient.SaveArtist(model);

            //Redireccionamos a la acción que muestra el listado de artistas
            return RedirectToAction("Listado");
        }
    }
}
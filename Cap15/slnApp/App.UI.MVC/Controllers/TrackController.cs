using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Queries;
using App.UI.MVC.MantenimientosServices;
using App.UI.MVC.ReportesServices;

namespace App.UI.MVC.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        ReporteServicesClient reporteServicesClient=null;
        MantenimientosServicesClient mantenimientosServicesClient  = null;

        public TrackController()
        {
            reporteServicesClient = 
                new ReportesServices.ReporteServicesClient();

            mantenimientosServicesClient = new MantenimientosServicesClient();
        }

        // GET: Track
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string filtroByNombre)
        {

            filtroByNombre = String.IsNullOrWhiteSpace(filtroByNombre)?"%": filtroByNombre;

            var model = reporteServicesClient.GetTrackAll(filtroByNombre);

            return PartialView("ListadoResultado", model);
        }

        public ActionResult VenderTrack()
        {
            var customers = mantenimientosServicesClient.GetCustomers("");
            ViewBag.customers = customers;

            var tracks = reporteServicesClient.GetTrackAll("");
            ViewBag.tracks = tracks;


            return View();
        }
    }
}
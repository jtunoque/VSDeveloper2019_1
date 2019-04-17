using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Queries;

namespace App.UI.MVC.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        ReportesServices.ReporteServicesClient reporteServicesClient=null;

        public TrackController()
        {
            reporteServicesClient = 
                new ReportesServices.ReporteServicesClient();
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
    }
}
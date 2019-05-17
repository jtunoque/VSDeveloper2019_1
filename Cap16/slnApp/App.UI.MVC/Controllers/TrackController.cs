﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;
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

            var tracks = reporteServicesClient.GetTrackAll("%");
            ViewBag.tracks = tracks;


            return View();
        }

        public ActionResult VenderTrackVue()
        {
            var customers = mantenimientosServicesClient.GetCustomers("");
            ViewBag.customers = customers;

            var tracks = reporteServicesClient.GetTrackAll("%");
            ViewBag.tracks = tracks;


            return View();
        }

        [HttpPost]
        public JsonResult GrabarVenta(Invoice venta)
        {
            venta.InvoiceDate = DateTime.Now;
            var result = mantenimientosServicesClient.SaveInvoice(venta);

            return Json(result);
        }


        public FileContentResult GetDocVenta(int id)
        {
            //Excel
            //var url = "http://s000-00:8093/ReportServer/Pages/ReportViewer.aspx?" + 
            //        "%2fChinookReportes%2frptInvoice&rs:Format=EXCELOPENXML&invoiceID=" + id.ToString();

            //PDF
            var url = "http://s000-00:8093/ReportServer/Pages/ReportViewer.aspx?" +
                    "%2fChinookReportes%2frptInvoice&rs:Format=PDF&invoiceID=" + id.ToString();

            //var nwc = new NetworkCredential("VS2015-WEB", "20170392");
            var wc = new WebClient();
            //wc.Credentials = nwc;
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //return File(wc.DownloadData(url), "application/vnd.ms-excel");
            return File(wc.DownloadData(url), "application/pdf");

        }


    }
}
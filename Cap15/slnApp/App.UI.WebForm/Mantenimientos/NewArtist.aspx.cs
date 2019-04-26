using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Mantenimientos
{
    public partial class NewArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) //Cuando se cargue por primera vez la página
            {
                GetArtist(); //Obtener información del artista
            }
        }

        private void GetArtist()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var client = new MantenimientoServices.MantenimientosServicesClient();
                var artist = client.GetArtist(id);

                //Asignando los valores al control
                txtNombre.Text = artist.Name;
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            var artist = new Artist();
            artist.Name = txtNombre.Text;

            //En modo edición deberia obtener el id del artista
            if(!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                artist.ArtistId =  Convert.ToInt32(Request.QueryString["id"]);

            //Llamando al proxy del servicio de mantenimientos
            var client = new MantenimientoServices.MantenimientosServicesClient();
            client.SaveArtist(artist);

            Response.Redirect("ManageArtist.aspx");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Mantenimientos
{
    public partial class ManageArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Recuperando el criterio de búqueda por nombre desde la caja de texto
            var nombre = txtFiltroPorNombre.Text;
            //Recuperando el servicio de client
            var client = new MantenimientoServices.MantenimientosServicesClient();        
            var listado = client.GetArtistAll(nombre);
            //Asignando la colección a la propiedad datasource del grid
            gvListado.DataSource = listado;
            //Enlanzando los datos
            gvListado.DataBind();

        }
    }
}
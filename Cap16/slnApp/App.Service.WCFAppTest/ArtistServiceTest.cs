using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Service.WCFAppTest
{
    [TestClass]
    public class ArtistServiceTest
    {
        [TestMethod]
        public void GetArtistAll()
        {
            var client = new MantenimientoServices.MantenimientosServicesClient();
            var lista = client.GetArtistAll("a");

            Assert.IsTrue(lista.Count > 0);

        }
    }
}

using System;
using App.DataAccess.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.DataAccess.Repository.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        [TestMethod]
        public void Count()
        {
            IArtistRepository repository = new ArtistRepository();
            int count = repository.Count();

            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            IArtistRepository repository = new ArtistRepository();
            var data = repository.GetAll();

            Assert.IsTrue(data.Count() > 0);
        }
    }
}

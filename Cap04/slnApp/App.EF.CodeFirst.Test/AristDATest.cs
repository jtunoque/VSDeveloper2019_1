using System;
using System.Collections.Generic;
using App.EF.CodeFirst.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.EF.CodeFirst.Test
{
    [TestClass]
    public class AristDATest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();
            Assert.IsTrue(da.Count() > 0);
        }
        [TestMethod]
        public void Insert()
        {
            var da = new ArtistDA();
            var id = da.Insert(
                new Artist() {Name="Artits_" 
                            + Guid.NewGuid().ToString() }
                );

            Assert.IsTrue(id > 0);

        }

        [TestMethod]
        public void DeleteBatch()
        {
            var list = new List<int>();
            list.Add(1283);
            list.Add(1282);
            list.Add(1281);
            var da = new ArtistDA();
            Assert.IsTrue(da.DeleteBatch(list));
        }
    }
}

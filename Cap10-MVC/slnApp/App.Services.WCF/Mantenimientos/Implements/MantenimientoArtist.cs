﻿using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Services.WCF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace App.Services.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public partial class MantenimientosServices : 
        IMantenimientosServices
    {
        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            IArtistDomain domain = new ArtistDomain();
            return domain.GetArtists(nombre);
        }

        public Artist GetArtist(int id)
        {
            IArtistDomain domain = new ArtistDomain();
            return domain.Get(id);
        }

        public bool SaveArtist(Artist entity)
        {
            var result = false;

            try
            {
                IArtistDomain domain = new ArtistDomain();
                result = domain.SaveArtist(entity);
            }
            catch(Exception ex)
            {
                //Se debería guarda el error un log
            }

            return result;

        }
    }
}

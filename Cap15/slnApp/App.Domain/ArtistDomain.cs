using App.DataAccess.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class ArtistDomain : IArtistDomain
    {
        public Artist Get(int id)
        {
            Artist result = new Artist();

            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetById<int>(id);
            }

            return result;
        }

        public IEnumerable<Artist> GetArtists(string nombre)
        {
            IEnumerable<Artist> result = new List<Artist>();

            using(var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetAll(
                            item=>item.Name.Contains(nombre)
                    );
            }

            return result;
        }

        public IEnumerable<TrackAll> GetTracksAll(string nombre)
        {
            IEnumerable<TrackAll> result = new List<TrackAll>();

            using (var uw = new AppUnitOfWork())
            {
                result = uw.TrackRepository.GetTracksAll(nombre);
            }

            return result;
        }

        public bool SaveArtist(Artist entity)
        {
            var result = false;

            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    /*Editando el artista*/
                    if (entity.ArtistId > 0) {
                        uw.ArtistRepository.Update(entity);
                    }
                    else //Cuando es nuevo artista
                    {
                        uw.ArtistRepository.Add(entity);
                    }

                    result = uw.Complete()>0;
                }
           
            }
            catch(Exception ex)
            {
                //Agregar el exeption aun log de errores
            }

            return result;
        }
    }
}

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
    public class TrackDomain : ITrackDomain
    {       

        public IEnumerable<TrackAll> GetTracksAll(string nombre)
        {
            IEnumerable<TrackAll> result = new List<TrackAll>();

            using (var uw = new AppUnitOfWork())
            {
                result = uw.TrackRepository.GetTracksAll(nombre);
            }

            return result;
        }
    }
}

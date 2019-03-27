using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Queries;
using App.Services.WCF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.WCF
{
    public partial class ReporteServices : IReporteServices
    {
        public IEnumerable<TrackAll> GetTrackAll(string trackName)
        {
            ITrackDomain domain = new TrackDomain();
            return domain.GetTracksAll(trackName);
        }
    }
}

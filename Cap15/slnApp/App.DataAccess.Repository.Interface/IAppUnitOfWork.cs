﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository.Interface
{
    public interface IAppUnitOfWork:IDisposable
    {
        IArtistRepository ArtistRepository { get; set; }
        ITrackRepository TrackRepository { get; set; }
        IUsuarioRepository UsuarioRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IInvoiceRepository InvoiceRepository { get; set; }
        int Complete();
    }
}

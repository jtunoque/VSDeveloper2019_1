using App.Domain;
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
    public partial class MantenimientosServices : 
        IMantenimientosServices
    {
        public int SaveInvoice(Invoice entity)
        {
            var result = 0;

            try
            {
                IInvoiceDomain domain = new InvoiceDomain();
                result = domain.SaveInvoice(entity);
            }
            catch(Exception ex)
            {
            }

            return result;

        }
    }
}

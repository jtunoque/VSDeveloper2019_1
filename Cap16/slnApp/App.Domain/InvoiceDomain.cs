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
    public class InvoiceDomain : IInvoiceDomain
    {
        public int SaveInvoice(Invoice entity)
        {
            var result = 0;

            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    if (entity.InvoiceId > 0)
                    {
                        uw.InvoiceRepository.Update(entity);
                    }
                    else
                    {
                        uw.InvoiceRepository.Add(entity);
                    }

                    uw.Complete();
                    result = entity.InvoiceId;
                }

            }
            catch (Exception ex)
            {
                result = 0;
            }

            return result;
        }
    }
}

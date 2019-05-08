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
        public bool SaveInvoice(Invoice entity)
        {
            var result = false;

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

                    result = uw.Complete() > 0;
                    result = true;
                }

            }
            catch (Exception ex)
            {
            }

            return result;
        }
    }
}

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
    public class CustomerDomain : ICustomerDomain
    {

        public IEnumerable<Customer> GetCustomers(string nombre)
        {
            IEnumerable<Customer> result = new List<Customer>();

            using(var uw = new AppUnitOfWork())
            {
                result = uw.CustomerRepository.GetAll(
                            item=>String.Concat(item.FirstName, " ", item.LastName)
                                    .Contains(nombre)
                    );
            }

            return result;
        }

     
    }
}

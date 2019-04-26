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
    public class UsuarioDomain : IUsuarioDomain
    {
        public Usuario ValidarAcceso(string login, string password)
        {
            Usuario result = null;
            using (var uw = new AppUnitOfWork())
            {
                result = uw.UsuarioRepository.GetAll(
                    filter:item=>item.Login==login                     
                    && item.Password==password
                    ).FirstOrDefault();
            }

            return result;
        }
    }
}

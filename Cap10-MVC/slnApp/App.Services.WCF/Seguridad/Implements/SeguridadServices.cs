using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using App.Services.WCF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.WCF
{
    public partial class SeguridadServices : ISeguridadServices
    {
        public Usuario ValidarAcceso(string login, string clave)
        {
            IUsuarioDomain domain = new UsuarioDomain();
            return domain.ValidarAcceso(login,clave);
        }
    }
}

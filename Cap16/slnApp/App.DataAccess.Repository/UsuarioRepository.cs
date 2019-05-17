using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>
        , IUsuarioRepository
    {
        public UsuarioRepository(DbContext context):base(context)
        {

        }
    }
}

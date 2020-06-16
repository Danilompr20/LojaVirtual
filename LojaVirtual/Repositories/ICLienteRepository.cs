using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
     public interface ICLienteRepository :IBaseRepository<Cliente>
    {
        Cliente Login(string Email, string Senha);
        Cliente ObterCliente(int id );
      

    }
}

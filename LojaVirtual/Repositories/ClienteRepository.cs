using LojaVirtual.Database;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, ICLienteRepository
    {
       
        public ClienteRepository(LojaVirtualContext context): base(context)
        {
           
        }

        public Cliente Login(string email, string senha)
        {
            Cliente cliente=_context.Clientes.Where(x=> x.Email ==email &&  x.Senha == senha ).FirstOrDefault();
            return cliente;
        }

        public Cliente ObterCliente(int id)
        {
            return _context.Clientes.FirstOrDefault(x=> x.ClienteId == id);
            
        }

       
    }
}

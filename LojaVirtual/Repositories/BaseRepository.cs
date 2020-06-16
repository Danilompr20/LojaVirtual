using LojaVirtual.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {

        protected LojaVirtualContext _context;
        public BaseRepository(LojaVirtualContext context)
        {
            _context = context;
        }
        
            public void Atualizar(T Entity)
        {
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }

        public void Cadastrar(T Entity)
        {
            _context.Set<T>().Add(Entity);
            _context.SaveChanges();
        }

        public void Excluir(T Entity)
        {
            _context.Set<T>().Remove(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<T> ObterTodosOsClientes()
        {
            return _context.Set<T>().ToList();
        }
    }
}

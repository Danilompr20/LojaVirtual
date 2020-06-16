using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
     public interface IBaseRepository<T>
    {
        void Cadastrar(T Entity);
        void Atualizar(T Entity);
        void Excluir(T Entity);
        IEnumerable<T> ObterTodosOsClientes();
    }
}

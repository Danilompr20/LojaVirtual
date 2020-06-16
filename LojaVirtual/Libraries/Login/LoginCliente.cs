using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        // salvar cliente na sessão
        public void SalvarClienteSessao(Cliente cliente)
        {
            //transforma obejto em string
            string clienteString = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(key, clienteString);

        }

        public Cliente GetClienteNaSessao( )
        {
            if (_sessao.Existe(key))
            {
                string clienteString = _sessao.Consultar(key);
                // transforma string em objeto
                return JsonConvert.DeserializeObject<Cliente>(clienteString);
            }

            else
            {
                return null;
            }            
        }

        public void LogOut()
        {
            _sessao.RemoverRodos();
        }
    }
}

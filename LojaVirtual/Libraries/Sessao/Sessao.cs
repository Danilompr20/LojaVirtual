using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao
{
    public class Sessao
    {
        // é necessario injetar o HttpContext
        private IHttpContextAccessor _httpcontext;
        public Sessao(IHttpContextAccessor httpcontext)
        {
            _httpcontext = httpcontext;
        }
        public void Cadastrar(string key, string valor)
        {
            _httpcontext.HttpContext.Session.SetString(key, valor);
        }
        
        public void Atualizar(string key, string valor)
        {
            if (Existe(key))
            {
                
                _httpcontext.HttpContext.Session.Remove(key);
            }

            _httpcontext.HttpContext.Session.SetString(key, valor);
        }
    

        public void Remover(string key)
        {
            _httpcontext.HttpContext.Session.Remove(key);
        }

        public string Consultar(string key)
        {
            return  _httpcontext.HttpContext.Session.GetString(key);
        }

        public bool Existe(string key)
        {
            if (_httpcontext.HttpContext.Session.GetString(key)==null)
            {
                return false;  
            }
            else
            {
                return true;
            }
        }
    

        public void RemoverRodos()
        {
            _httpcontext.HttpContext.Session.Clear();
        }

    }
}

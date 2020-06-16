using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {

        private LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // quando é atributo não da pra usar injeção de dependencia, então essa é  a maneira correta de ter acesso ao serviço
            _loginCliente=  (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Cliente cliente = _loginCliente.GetClienteNaSessao();
            if (cliente == null)
            {
                context.Result = new ContentResult() { Content = "Acesso Negado" };
            }
           
        }
    }
}

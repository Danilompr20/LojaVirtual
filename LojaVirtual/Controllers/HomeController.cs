using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();
                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];
                // validando msg de erro do dataanotations 
                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                //tryValidateObject retorna um boolean, true no fim do metodo é para validar todos campos
               bool isValid= Validator.TryValidateObject(contato,contexto,listaMensagens,true);

                if( isValid)
                    {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
                }
                else
                {
                    // capturando a msg de erro
                    StringBuilder sb = new StringBuilder();
                    foreach ( var texto in listaMensagens)
                    {
                        sb.Append(texto.ErrorMessage);
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["Contato"] = contato;
                }
            }
            catch (Exception e)
            {

                ViewData["MSG_E"]="Um erro ocorreu tente novamente mais tarde!";
            }

            return View("Contato");

            // retorna uma tela com os dados formatados
            // return new ContentResult() { Content= string.Format("Dados recebido com sucesso: </br> nome: {0}, E-mail: {1},Texto: {2}",contato.Nome,contato.Email,contato.Texto ),ContentType="text/html"};
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
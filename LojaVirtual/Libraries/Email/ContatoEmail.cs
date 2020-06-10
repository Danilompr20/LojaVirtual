using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            // smtp servidor que vai enviar a mensagem
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.UseDefaultCredentials = false;
            //obtem as credenciais para autenticar o remetente
            smtp.Credentials = new NetworkCredential("moises.rodrigues4r@gmail.com", "spotlight10");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - loja virtual</h2>" +
                "<b>Nome:</b>{0} </br>" +
                "<b>E-mail:</b>{1} </br>" +
                "<b>Texto :</b>{2} </br>"+
                "E-mail enviado automaticamente",contato.Nome,contato.Email,contato.Texto);
            //MailMessage serve para construir a mensagem a ser enviada

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("moises.rodrigues4r@gmail.com");
            mensagem.To.Add (new MailAddress("Danilompr@hotmail.com"));
            mensagem.Subject = "Contato Loja virtual E-mail " + contato.Email;
            mensagem.Body = corpoMsg;
            // permite que seja usado html no corpo da mensagem
            mensagem.IsBodyHtml = true;
            //Enviar mensagem 
            smtp.Send(mensagem);
        }
    }
}

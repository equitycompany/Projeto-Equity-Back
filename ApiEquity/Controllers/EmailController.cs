using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Net.Mail;
using DataAccess;
using Model;
using Microsoft.VisualBasic;

namespace ApiEquity.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        [HttpGet]
        [Route("EnviarEmail/{nome}&{email}&{mensagem}")]
        public bool SendEmail(string nome, string email, string mensagem)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("equitycompany2021@gmail.com", "Fecap@2021");
            MailMessage mail = new MailMessage();
            mail.Sender = new MailAddress(email, nome);
            mail.From = new MailAddress(email, "Help Equity");
            mail.ReplyToList.Add( new MailAddress(email, nome));
            mail.To.Add(new MailAddress("equitycompany2021@gmail.com", "EquityCompany"));
            mail.Subject = "Contato - Equity";
            mail.Body = "Mensagem para Equity:<br/> Nome:  " + nome + "<br/> Email : " + email + " <br/> Mensagem : " + mensagem;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                Console.WriteLine(erro);
                return false;
            }
            finally
            {
                mail = null;
            }

            return true;
        }

        [HttpGet]
        [Route("TrocadeSenha/{email}")]
        public bool SendChangePass(string email)
        {
            Candidato cand = DBCandidato.GetCandidatoByEmail(email);

            if ( Strings.Len(cand.Nome) == 0 ) {
                return false;
            }

            DBCandidato.MarkChangePass(email);

            string urlsenha = DBCandidato.FindChangePassSenha(email);

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("equitycompany2021@gmail.com", "Fecap@2021");
            MailMessage mail = new MailMessage();
            mail.Sender = new MailAddress(email, cand.Nome);
            mail.From = new MailAddress(email, "Help Equity");
            mail.ReplyToList.Add(new MailAddress(email, cand.Nome));
            mail.To.Add(new MailAddress(email, "EquityCompany"));
            mail.Subject = "Contato - Equity";
            mail.Body = "Mensagem para Equity:<br/> Nome:  " + cand.Nome + "<br/> Email : " + email + " <br/> Mensagem : Foi solicitada a troca de senha, utilize o link a seguir para redefiní-la: " + "<a href='" + "http://127.0.0.1:5500/esqueci-a-senha.html#?_" + urlsenha + "'>Clique Aqui</a>";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                Console.WriteLine(erro);
                return false;
            }
            finally
            {
                mail = null;
            }

            return true;
        }
    }
}

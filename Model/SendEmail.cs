using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SendEmail
    {
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Mensagem { get; set; }

        public SendEmail() { }

        public SendEmail(string nome, string email, string mensagem)
        {
            Nome = nome;
            Email = email;
            Mensagem = mensagem;
        }
    }
}

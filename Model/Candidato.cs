using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Candidato
    {
        public Int64 ID { get; set; }
        public String CPF { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }

        public Candidato() { }

        public Candidato(string cpf, string nome, string email, string senha)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public static bool ValidarCPFExistente(string cpf, List<Candidato> list)
        {

            foreach (Candidato cand in list)
            {
                if (cpf == cand.CPF)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

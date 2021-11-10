using System;
using System.Data.SQLite;
using System.Collections.Generic;
using Model;

namespace Model
{
    public class Empresa
    {
        public Int64 ID { get; set; }
        public String CNPJ { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public Empresa() { }
        public Empresa(string cnpj, string nome, string email, string senha)
        {
            CNPJ = cnpj;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public static bool ValidarCNPJExistente(string cnpj, List<Empresa> list)
        {

            foreach (Empresa emp in list)
            {
                if (cnpj == emp.CNPJ)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

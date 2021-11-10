using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Curriculo
    {
        public Int64 ID { get; set; }
        public String CPF { get; set; }
        public String Nome { get; set; }
        public String Endereço { get; set; }
        public String Complemento { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public Int64 CEP { get; set; }
        public String Pais { get; set; }
        public Int64 DataNasc { get; set; }
        public String GrauEscolar { get; set; }
        public String Curso { get; set; }
        public String Idioma { get; set; }
        public String Experiencia { get; set; }
        public String Objetivo { get; set; }

        public Curriculo() { }

        public Curriculo(string cpf, string nome, string endereco, string complemento, string cidade, string estado, Int64 cep, string pais, 
        Int64 datanasc, string grauescolar, string curso, string idioma, string experiencia, string objetivo)
        {
            CPF = cpf;
            Nome = nome;
            Endereço = endereco;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Pais = pais;
            DataNasc = datanasc;
            GrauEscolar = grauescolar;
            Curso = curso;
            Idioma = idioma;
            Experiencia = experiencia;
            Objetivo = objetivo;
        }
    }
}

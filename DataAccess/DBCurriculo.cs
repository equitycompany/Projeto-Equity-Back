using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using Model;

namespace DataAccess
{
    class DBCurriculo
    {
        public static void Inserir(Curriculo Curriculo)
        {
            List<Curriculo> list = DBCurriculo.GetCurriculos();

            string strSql = "INSERT INTO Curriculo ( CPF, Nome, Endereço, Complemento, Cidade, Estado, CEP, " +
                            "Pais, DataNasc, GrauEscolar, Curso, Idioma, Experiencia, Objetivo) values ( @CPF, " +
                            "@Nome, @Endereço, @Complemento, Cidade, Estado, CEP, Pais, DataNasc, GrauEscolar, Curso, Idioma, Experiencia, Objetivo)";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@CPF", Curriculo.CPF);
            cmd.Parameters.AddWithValue("@Nome", Curriculo.Nome);
            cmd.Parameters.AddWithValue("@Endereço", Curriculo.Endereço);
            cmd.Parameters.AddWithValue("@Complemento", Curriculo.Complemento);
            cmd.Parameters.AddWithValue("@Cidade", Curriculo.Cidade);
            cmd.Parameters.AddWithValue("@Estado", Curriculo.Estado);
            cmd.Parameters.AddWithValue("@CEP", Curriculo.CEP);
            cmd.Parameters.AddWithValue("@Pais", Curriculo.Pais);
            cmd.Parameters.AddWithValue("@DataNasc", Curriculo.DataNasc);
            cmd.Parameters.AddWithValue("@GrauEscolar", Curriculo.GrauEscolar);
            cmd.Parameters.AddWithValue("@Curso", Curriculo.Curso);
            cmd.Parameters.AddWithValue("@Idioma", Curriculo.Idioma);
            cmd.Parameters.AddWithValue("@Experiencia", Curriculo.Experiencia);
            cmd.Parameters.AddWithValue("@Objetivo", Curriculo.Objetivo);
            cmd.ExecuteNonQuery();
        }
        public static void Alterar(Curriculo Curriculo)
        {
            String strSql = "UPDATE Curriculo ";
            strSql += "SET CPF=@CPF, ";
            strSql += "Nome=@Nome, ";
            strSql += "Endereço=@Endereço, ";
            strSql += "Complemento=@Complemento ";
            strSql += "Cidade=@Cidade ";
            strSql += "Estado=@Estado ";
            strSql += "CEP=@CEP ";
            strSql += "Pais=@Pais ";
            strSql += "DataNasc=@DataNasc ";
            strSql += "GrauEscolar=@GrauEscolar ";
            strSql += "Curso=@Curso ";
            strSql += "Idioma=@Idioma ";
            strSql += "Experiencia=@Experiencia ";
            strSql += "Objetivo=@Objetivo ";
            strSql += "WHERE ID=@Id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@CPF", Curriculo.CPF);
            cmd.Parameters.AddWithValue("@Nome", Curriculo.Nome);
            cmd.Parameters.AddWithValue("@Endereço", Curriculo.Endereço);
            cmd.Parameters.AddWithValue("@Complemento", Curriculo.Complemento);
            cmd.Parameters.AddWithValue("@Cidade", Curriculo.Cidade);
            cmd.Parameters.AddWithValue("@Estado", Curriculo.Estado);
            cmd.Parameters.AddWithValue("@CEP", Curriculo.CEP);
            cmd.Parameters.AddWithValue("@Pais", Curriculo.Pais);
            cmd.Parameters.AddWithValue("@DataNasc", Curriculo.DataNasc);
            cmd.Parameters.AddWithValue("@GrauEscolar", Curriculo.GrauEscolar);
            cmd.Parameters.AddWithValue("@Curso", Curriculo.Curso);
            cmd.Parameters.AddWithValue("@Idioma", Curriculo.Idioma);
            cmd.Parameters.AddWithValue("@Experiencia", Curriculo.Experiencia);
            cmd.Parameters.AddWithValue("@Objetivo", Curriculo.Objetivo);
            cmd.Parameters.AddWithValue("@Id", Curriculo.ID);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Alteração realizada\n");
        }

        public static void Excluir(int Id)
        {
            String strSql = "DELETE from Curriculo";
            strSql += " WHERE ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Id " + Id.ToString() + " excluído com sucesso\n");
        }

        public static Curriculo GetEmpresa(int id)
        {
            Curriculo cur = new Curriculo();
            String strSQl = "Select CPF, Nome, Endereço, Complemento, Cidade, Estado, CEP, " +
                            "Pais, DataNasc, GrauEscolar, Curso, Idioma, Experiencia, Objetivo from Curriculo Where ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cur.ID = (Int64)dr["ID"];
                    cur.CPF = dr["CPF"].ToString();
                    cur.Nome = dr["Nome"].ToString();
                    cur.Endereço = dr["Endereço"].ToString();
                    cur.Complemento = dr["Complemento"].ToString();
                    cur.Cidade = dr["Cidade"].ToString();
                    cur.Estado = dr["Estado"].ToString();
                    cur.CEP = (Int64)dr["CEP"];
                    cur.Pais = dr["Pais"].ToString();
                    cur.DataNasc = (Int64)dr["DataNasc"];
                    cur.GrauEscolar = dr["GrauEscolar"].ToString();
                    cur.Curso = dr["Curso"].ToString();
                    cur.Idioma = dr["Idioma"].ToString();
                    cur.Experiencia = dr["Experiencia"].ToString();
                    cur.Objetivo = dr["Objetivo"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cur;
        }

        public static List<Curriculo> GetCurriculos()
        {
            List<Curriculo> listEmp = new List<Curriculo>();

            String strSQl = "Select CPF, Nome, Endereço, Complemento, Cidade, Estado, CEP, " +
                            "Pais, DataNasc, GrauEscolar, Curso, Idioma, Experiencia, Objetivo from Curriculo";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curriculo cur = new Curriculo();
                    cur.ID = (Int64)dr["ID"];
                    cur.CPF = dr["CPF"].ToString();
                    cur.Nome = dr["Nome"].ToString();
                    cur.Endereço = dr["Endereço"].ToString();
                    cur.Complemento = dr["Complemento"].ToString();
                    cur.Cidade = dr["Cidade"].ToString();
                    cur.Estado = dr["Estado"].ToString();
                    cur.CEP = (Int64)dr["CEP"];
                    cur.Pais = dr["Pais"].ToString();
                    cur.DataNasc = (Int64)dr["DataNasc"];
                    cur.GrauEscolar = dr["GrauEscolar"].ToString();
                    cur.Curso = dr["Curso"].ToString();
                    cur.Idioma = dr["Idioma"].ToString();
                    cur.Experiencia = dr["Experiencia"].ToString();
                    cur.Objetivo = dr["Objetivo"].ToString();
                    listEmp.Add(cur);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEmp;
        }
    }
}

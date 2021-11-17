using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using Model;

namespace DataAccess
{
    public class DBCandidato
    {
        public static void Inserir(Candidato candidato)
        {
            List<Candidato> list = DBCandidato.GetCandidatos();
            if (Candidato.ValidarCPFExistente(candidato.CPF, list))
            {
                string strSql = "INSERT INTO Candidato (CPF, Nome, Email, Senha) values ( @CPF, @Nome, @Email, @Senha )";
                SQLiteConnection con = DBConnect.Open();

                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = strSql;
                cmd.Parameters.AddWithValue("@CPF", candidato.CPF);
                cmd.Parameters.AddWithValue("@Nome", candidato.Nome);
                cmd.Parameters.AddWithValue("@Email", candidato.Email);
                cmd.Parameters.AddWithValue("@Senha", candidato.Senha);
                cmd.ExecuteNonQuery();
            } else
            {
                Console.WriteLine("CPF já cadastrado\n");
            }
        }

        public static void Alterar(Candidato candidato)
        {
            String strSql = "UPDATE Candidato ";
            strSql += "SET CPF=@CPF, ";
            strSql += "Nome=@Nome, ";
            strSql += "Email=@Email, ";
            strSql += "Senha=@Senha ";
            strSql += "WHERE ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@CPF", candidato.CPF);
            cmd.Parameters.AddWithValue("@Nome", candidato.Nome);
            cmd.Parameters.AddWithValue("@Email", candidato.Email);
            cmd.Parameters.AddWithValue("@Senha", candidato.Senha);
            cmd.Parameters.AddWithValue("@Id", candidato.ID);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Alteração realizada\n");
        }

        public static void Excluir(int Id)
        {
            String strSql = "DELETE from Candidato";
            strSql += " WHERE ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Id " + Id.ToString() + " excluído com sucesso\n");
        }

        public static Candidato GetCandidato(int id)
        {
            Candidato cand = new Candidato();
            String strSQl = "Select ID, CPF, Nome, Email, Senha from Candidato Where ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cand.ID = (Int64)dr["ID"];
                    cand.CPF = dr["CPF"].ToString();
                    cand.Nome = dr["Nome"].ToString();
                    cand.Email = dr["Email"].ToString();
                    cand.Senha = dr["Senha"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cand;
        }

        public static List<Candidato> GetCandidatos()
        {
            List<Candidato> listCand = new List<Candidato>();

            String strSQl = "Select ID, CPF, Nome, Email, Senha from Candidato";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Candidato cand = new Candidato();
                    cand.ID = (Int64)dr["ID"];
                    cand.CPF = dr["CPF"].ToString();
                    cand.Nome = dr["Nome"].ToString();
                    cand.Email = dr["Email"].ToString();
                    cand.Senha = dr["Senha"].ToString();
                    listCand.Add(cand);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCand;
        }

        public static bool CheckLogin(string login, string senha)
        {
            String strSQl = "Select Email, Senha from Candidato Where Email=@login";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@login", login);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (login == dr["Email"].ToString() && senha == dr["Senha"].ToString())
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}

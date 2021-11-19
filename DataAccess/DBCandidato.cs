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

        public static void AlterarSenha(string email, string senha)
        {
            Candidato cand = GetCandidatoByEmail(email);
            String strSql = "UPDATE Candidato ";
            strSql += "SET CPF=@CPF, ";
            strSql += "Nome=@Nome, ";
            strSql += "Email=@Email, ";
            strSql += "Senha=@Senha ";
            strSql += "WHERE ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@CPF", cand.CPF);
            cmd.Parameters.AddWithValue("@Nome", cand.Nome);
            cmd.Parameters.AddWithValue("@Email", cand.Email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            cmd.Parameters.AddWithValue("@Id", cand.ID);
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

        public static Candidato GetCandidatoByEmail(string email)
        {
            Candidato cand = new Candidato();
            String strSQl = "Select ID, CPF, Nome, Email, Senha from Candidato Where Email=@email";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@email", email);
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

        public static bool MarkChangePass(string login)
        {
            String strSQl = "Select ID, Email from Candidato Where Email=@login";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@login", login);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string strSql = "INSERT INTO Recuperar_senha (ID, Email, Senha) VALUES ( @ID, @Email, @Senha)";
                    SQLiteConnection con2 = DBConnect.Open();

                    SQLiteCommand cmd2 = new SQLiteCommand(con2);
                    cmd2.CommandText = strSql;
                    cmd2.Parameters.AddWithValue("@ID", dr["ID"]);
                    cmd2.Parameters.AddWithValue("@Email", dr["Email"]);
                    cmd2.Parameters.AddWithValue("@Senha", GerarSenhas());
                    cmd2.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        public static string GerarSenhas()
        {
            int Tamanho = 10; // Numero de digitos da senha
            string senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return senha;
        }

        public static string FindChangePassEmail(string chgsenha)
        {
            string email = string.Empty;
            String strSQl = "Select Email from Recuperar_senha Where Senha=@senha";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@senha", chgsenha);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    email = dr["Email"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return email;
        }

        public static string FindChangePassSenha(string email)
        {
            string chgsenha = string.Empty;
            String strSQl = "Select Senha from Recuperar_senha Where Email=@email";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chgsenha = dr["Senha"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return chgsenha;
        }

        public static bool ExcluirChgSenha(string email)
        {
            String strSql = "DELETE from Recuperar_senha";
            strSql += " WHERE Email=@email";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();

            return true;
        }
    }
}

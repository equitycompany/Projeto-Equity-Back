using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using Model;

namespace DataAccess
{
    public class DBEmpresa
    {
        public static void Inserir( Empresa empresa )
        {
            List<Empresa> list = DBEmpresa.GetEmpresas();
            if (Empresa.ValidarCNPJExistente(empresa.CNPJ, list))
            {
                string strSql = "INSERT INTO Empresa ( CNPJ, Nome, Email, Senha ) values ( @CNPJ, @Nome, @Email, @Senha )";
                SQLiteConnection con = DBConnect.Open();

                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = strSql;
                cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                cmd.Parameters.AddWithValue("@Nome", empresa.Nome);
                cmd.Parameters.AddWithValue("@Email", empresa.Email);
                cmd.Parameters.AddWithValue("@Senha", empresa.Senha);
                cmd.ExecuteNonQuery();
            } else
            {
                Console.WriteLine("CNPJ já cadastrado\n");
            }
        }

        public static void Alterar(Empresa empresa)
        {
            String strSql = "UPDATE Empresa ";
            strSql += "SET CNPJ=@CNPJ, ";
            strSql += "Nome=@Nome, ";
            strSql += "Email=@Email, ";
            strSql += "Senha=@Senha ";
            strSql += "WHERE ID=@Id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
            cmd.Parameters.AddWithValue("@Nome", empresa.Nome);
            cmd.Parameters.AddWithValue("@Email", empresa.Email);
            cmd.Parameters.AddWithValue("@Senha", empresa.Senha);
            cmd.Parameters.AddWithValue("@Id", empresa.ID);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Alteração realizada\n");
        }

        public static void Excluir(int Id)
        {
            String strSql = "DELETE from Empresa";
            strSql += " WHERE ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Id " + Id.ToString() + " excluído com sucesso\n");
        }

        public static Empresa GetEmpresa(int id)
        {
            Empresa emp = new Empresa();
            String strSQl = "Select ID, CNPJ, Nome, Email, Senha from Empresa Where ID=@id";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp.ID = (Int64)dr["ID"];
                    emp.CNPJ = dr["CNPJ"].ToString();
                    emp.Nome = dr["Nome"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Senha = dr["Senha"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public static List<Empresa> GetEmpresas()
        {
            List<Empresa> listEmp = new List<Empresa>();

            String strSQl = "Select ID, CNPJ, Nome, Email, Senha from Empresa";
            SQLiteConnection con = DBConnect.Open();

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = strSQl;
            try
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empresa emp = new Empresa();
                    emp.ID = (Int64)dr["ID"];
                    emp.CNPJ = dr["CNPJ"].ToString();
                    emp.Nome = dr["Nome"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Senha = dr["Senha"].ToString();
                    listEmp.Add(emp);
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

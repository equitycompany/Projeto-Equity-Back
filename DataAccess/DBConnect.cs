using System;
using System.Data.SQLite;

namespace DataAccess
{
    public class DBConnect
    {
        static string Path = "Data Source=C:\\Users\\vanessa.ruama\\Documents\\FECAP\\Algoritmos e Estrutura de Dados\\Equity\\Banco de Dados\\DBEquity.db";
        static SQLiteConnection con;

        public static SQLiteConnection Open()
        {
            if (con == null)
            {
                con = new SQLiteConnection(Path);
                con.Open();
            }

            return con;
        }
    }
}

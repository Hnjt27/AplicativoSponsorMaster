using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AplicativoSponsor.Models
{
    public class Conexao : IDisposable
    {
        public MySqlConnection conn;
        private readonly string host = "localhost";
        private readonly string port = "3306";
        private readonly string db = "bd_sponsor";
        private readonly string user = "root";
        private readonly string pass = "2701";

        public Conexao()
        {
            Conectar();
        }

        private void Conectar()
        {
            string StrConn = "";
            StrConn = "Server=" + host + ";Port=" + port + ";Database=" + db + ";Uid=" + user + ";Pwd=" + pass + ";";
            conn = new MySqlConnection(StrConn);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }

        public void FecharConexao()
        {
            conn.Close();
            conn.Dispose();
        }

    }
}

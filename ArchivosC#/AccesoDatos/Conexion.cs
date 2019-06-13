using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ErpTEC.AccesoDatos
{
    public class Conexion
    {
        private static String bd = "erptec";
        private static String login = "postgres";
        private static String password = "12345";
        private static String server = "localhost";
        private static String port = "5432";

        public Conexion()
        {
            try
            {
                Conn =
                    new NpgsqlConnection("Host=" + server + ";Username=" + login + ";Password=" + password + ";Database=" +
                              bd + ";Port=" + port);
                Conn.Open();
            }
            catch (Exception error)
            {
                ExisteError = true;
                MensajeError = error.Message;

            }
        }

        public static bool ExisteError { get; set; } = false;
        public static string MensajeError { get; set; } = "";
        public NpgsqlConnection Conn { get; set; } = null;

    }
}

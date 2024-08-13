using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace veterinaria.modelo
{
    public class ModeloDoctores : Conexion
    {
        MySqlConnection con = new MySqlConnection(cadenaConexion());

        public DataTable loginDoctor(string username, string password)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT id,nombre FROM doctores WHERE " +
                $"documento = @username AND clave = @password", con);

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                DataTable tabla = new DataTable();
                con.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                adaptador.Fill(tabla);
                con.Close();
                return tabla;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}

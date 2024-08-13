using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace veterinaria.modelo
{
    public class ModeloTipoDocumento:Conexion
    {
        MySqlConnection con = new MySqlConnection(cadenaConexion());

        public DataTable ListarTiposDocumento()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tipodocumento;", con);
            
            try
            {
                cmd.CommandType = CommandType.Text;
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

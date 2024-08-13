using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace veterinaria.modelo
{
    public class ModeloPropietarios:Conexion
    {
        MySqlConnection con = new MySqlConnection(cadenaConexion());
        public string RegistrarPropietarios(TablaPropietarios tablaPropietarios)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO propietarios (" +
                "id," +
                "IdTipoDocumento," +
                "Documento," +
                "Nombre," +
                "Direccion," +
                "Telefono," +
                "Celular," +
                "Correo)" +
                "VALUES (NULL,@IdTipoDocumento,@Documento," +
                "@Nombre,@Direccion,@Telefono,@Celular,@Correo);", con);
            
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tablaPropietarios.Id);
                cmd.Parameters.AddWithValue("@IdTipoDocumento", tablaPropietarios.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@Documento", tablaPropietarios.Documento);
                cmd.Parameters.AddWithValue("@Nombre", tablaPropietarios.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", tablaPropietarios.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", tablaPropietarios.Telefono);
                cmd.Parameters.AddWithValue("@Celular", tablaPropietarios.Celular);
                cmd.Parameters.AddWithValue("@Correo", tablaPropietarios.Correo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Registro de propietario exitoso.";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable ListarPropietarios()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT " +
                "propietarios.id, " +
                "propietarios.IdTipoDocumento, " +
                "concat(tipodocumento.Abreviatura,'-',tipodocumento.Descripcion) as TipoDocumento," +
                "propietarios.Documento, " +
                "propietarios.Nombre, " +
                "propietarios.Direccion, " +
                "propietarios.Telefono, " +
                "propietarios.Celular, " +
                "propietarios.Correo " +
                "FROM propietarios " +
                "INNER JOIN tipodocumento ON propietarios.IdTipoDocumento = tipodocumento.id;", con);
           
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
        public string EditarPropietarios(TablaPropietarios tablaPropietarios)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE propietarios " +
                "SET IdTipoDocumento = @IdTipoDocumento, " +
                "Documento = @Documento, " +
                "Nombre = @Nombre, " +
                "Direccion = @Direccion, " +
                "Telefono = @Telefono, " +
                "Celular = @Celular, " +
                "Correo = @Correo " +
                "WHERE id = @id;", con);
         
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tablaPropietarios.Id);
                cmd.Parameters.AddWithValue("@IdTipoDocumento", tablaPropietarios.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@Documento", tablaPropietarios.Documento);
                cmd.Parameters.AddWithValue("@Nombre", tablaPropietarios.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", tablaPropietarios.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", tablaPropietarios.Telefono);
                cmd.Parameters.AddWithValue("@Celular", tablaPropietarios.Celular);
                cmd.Parameters.AddWithValue("@Correo", tablaPropietarios.Correo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Actualización de propietario exitosa.";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public string EliminarPropietarios(TablaPropietarios tablaPropietarios)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM propietarios WHERE id = @id;", con);
            
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tablaPropietarios.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Registro borrado exitosamente.";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

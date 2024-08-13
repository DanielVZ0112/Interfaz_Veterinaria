using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace veterinaria.modelo
{
    public class ModeloPacientes:Conexion
    {
        MySqlConnection con = new MySqlConnection(cadenaConexion());

        public string RegistrarPacientes(TablaPaciente tablaPaciente)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO pacientes (" +
                "id, " +
                "idPropietario, " +
                "NombreMascota, " +
                "FechaNacimiento, " +
                "Edad, " +
                "Especie, " +
                "Raza, " +
                "Color, " +
                "Peso, " +
                "Sexo, " +
                "Vacunado) " +
                "VALUES (NULL, @IdPropietario, @NombreMascota, @FechaNacimiento, @Edad, @Especie, @Raza, @Color, @Peso, @Sexo, @Vacunado);", con);
           
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdPropietario", tablaPaciente.IdPropietario);
                cmd.Parameters.AddWithValue("@NombreMascota", tablaPaciente.NombreMascota);
                cmd.Parameters.AddWithValue("@FechaNacimiento", tablaPaciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Edad", tablaPaciente.Edad);
                cmd.Parameters.AddWithValue("@Especie", tablaPaciente.Especie);
                cmd.Parameters.AddWithValue("@Raza", tablaPaciente.Raza);
                cmd.Parameters.AddWithValue("@Color", tablaPaciente.Color);
                cmd.Parameters.AddWithValue("@Peso", tablaPaciente.Peso);
                cmd.Parameters.AddWithValue("@Sexo", tablaPaciente.Sexo);
                cmd.Parameters.AddWithValue("@Vacunado", tablaPaciente.Vacunado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Registro de paciente exitoso.";
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

        public DataTable ListarPacientes(string docPropietario)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT " +
                "pacientes.id, " +
                "pacientes.idPropietario," +
                "pacientes.NombreMascota," +
                "pacientes.Peso," +
                "pacientes.Especie," +
                "pacientes.Raza," +
                "pacientes.FechaNacimiento," +
                "pacientes.Edad," +
                "pacientes.Color," +
                "pacientes.Sexo," +
                "pacientes.Vacunado, " +
                "propietarios.id as idProp, " +
                "propietarios.Documento, " +
                "propietarios.Nombre " +
                "FROM pacientes " +
                "RIGHT JOIN propietarios ON pacientes.idPropietario = propietarios.id " +
                "WHERE propietarios.Documento = @docPropietario;", con);
   
            DataTable tabla = new DataTable();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@docPropietario", docPropietario);
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

        public string EditarPacientes(TablaPaciente tablaPaciente)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE pacientes SET NombreMascota = @NombreMascota, FechaNacimiento = @FechaNacimiento, " +
                                                "Edad = @Edad, Especie = @Especie, Raza = @Raza, Color = @Color, Peso = @Peso, Sexo = @Sexo, Vacunado = @Vacunado WHERE id = @id;", con);
           
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tablaPaciente.Id);
                cmd.Parameters.AddWithValue("@NombreMascota", tablaPaciente.NombreMascota);
                cmd.Parameters.AddWithValue("@FechaNacimiento", tablaPaciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Edad", tablaPaciente.Edad);
                cmd.Parameters.AddWithValue("@Especie", tablaPaciente.Especie);
                cmd.Parameters.AddWithValue("@Raza", tablaPaciente.Raza);
                cmd.Parameters.AddWithValue("@Color", tablaPaciente.Color);
                cmd.Parameters.AddWithValue("@Peso", tablaPaciente.Peso);
                cmd.Parameters.AddWithValue("@Sexo", tablaPaciente.Sexo);
                cmd.Parameters.AddWithValue("@Vacunado", tablaPaciente.Vacunado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Actualización de paciente exitosa.";
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

        public string EliminarPacientes(TablaPaciente tablaPaciente)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM pacientes WHERE id = @id;", con);
            
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tablaPaciente.Id);
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

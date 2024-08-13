using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinaria.modelo
{
    public class ModeloConsultas : Conexion
    {
        MySqlConnection con = new MySqlConnection(cadenaConexion());

        public string RegistrarConsulta(TablaConsultas tablaConsulta)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO consultas (" +
                "id, " +
                "IdPropietario, " +
                "IdPaciente, " +
                "IdDoctor, " +
                "FechaConsulta, " +
                "CostoConsulta, " +
                "MotivoConsulta, " +
                "Sintomas, " +
                "Diagnostico, " +
                "FormulaMedica, " +
                "AplicaExamenes, " +
                "NotasAdicionales, " +
                "ProximoControl) " +
                "VALUES (NULL, @IdPropietario, @IdPaciente, @IdDoctor, @FechaConsulta, @CostoConsulta, @MotivoConsulta, @Sintomas, " +
                "@Diagnostico, @FormulaMedica, @AplicaExamenes, @NotasAdicionales, @ProximoControl);", con);
            
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdPropietario", tablaConsulta.IdPropietario);
                cmd.Parameters.AddWithValue("@IdPaciente", tablaConsulta.IdPaciente);
                cmd.Parameters.AddWithValue("@IdDoctor", tablaConsulta.IdDoctor);
                cmd.Parameters.AddWithValue("@FechaConsulta", tablaConsulta.FechaConsulta);
                cmd.Parameters.AddWithValue("@CostoConsulta", tablaConsulta.CostoConsulta);
                cmd.Parameters.AddWithValue("@MotivoConsulta", tablaConsulta.MotivoConsulta);
                cmd.Parameters.AddWithValue("@Sintomas", tablaConsulta.Sintomas);
                cmd.Parameters.AddWithValue("@Diagnostico", tablaConsulta.Diagnostico);
                cmd.Parameters.AddWithValue("@FormulaMedica", tablaConsulta.FormulaMedica);
                cmd.Parameters.AddWithValue("@AplicaExamenes", tablaConsulta.AplicaExamenes);
                cmd.Parameters.AddWithValue("@NotasAdicionales", tablaConsulta.NotasAdicionales);
                cmd.Parameters.AddWithValue("@ProximoControl", tablaConsulta.ProximoControl);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Registro de consulta exitoso.";
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

        public DataTable ListarConsultas(string idPaciente)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT " +
                "consultas.id, " +
                "consultas.IdPropietario, " +
                "consultas.IdPaciente, " +
                "consultas.IdDoctor, " +
                "consultas.FechaConsulta, " +
                "consultas.CostoConsulta, " +
                "consultas.MotivoConsulta, " +
                "consultas.Sintomas, " +
                "consultas.Diagnostico, " +
                "consultas.FormulaMedica, " +
                "consultas.AplicaExamenes, " +
                "consultas.NotasAdicionales, " +
                "consultas.ProximoControl " +
                "FROM consultas " +
                "INNER JOIN propietarios ON propietarios.id = consultas.IdPropietario " +
                "INNER JOIN pacientes ON pacientes.id = consultas.IdPaciente WHERE consultas.IdPaciente = @idPaciente;", con);
           
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
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

        public string EditarConsulta(TablaConsultas tablaConsulta)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE consultas SET FechaConsulta = @FechaConsulta, CostoConsulta = @CostoConsulta, MotivoConsulta = @MotivoConsulta, " +
                                           "Sintomas = @Sintomas, Diagnostico = @Diagnostico, FormulaMedica = @FormulaMedica, AplicaExamenes = @AplicaExamenes, " +
                                           "NotasAdicionales = @NotasAdicionales, ProximoControl = @ProximoControl WHERE id = @id;", con);
            
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", tablaConsulta.Id);
                cmd.Parameters.AddWithValue("@FechaConsulta", tablaConsulta.FechaConsulta);
                cmd.Parameters.AddWithValue("@CostoConsulta", tablaConsulta.CostoConsulta);
                cmd.Parameters.AddWithValue("@MotivoConsulta", tablaConsulta.MotivoConsulta);
                cmd.Parameters.AddWithValue("@Sintomas", tablaConsulta.Sintomas);
                cmd.Parameters.AddWithValue("@Diagnostico", tablaConsulta.Diagnostico);
                cmd.Parameters.AddWithValue("@FormulaMedica", tablaConsulta.FormulaMedica);
                cmd.Parameters.AddWithValue("@AplicaExamenes", tablaConsulta.AplicaExamenes);
                cmd.Parameters.AddWithValue("@NotasAdicionales", tablaConsulta.NotasAdicionales);
                cmd.Parameters.AddWithValue("@ProximoControl", tablaConsulta.ProximoControl);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Actualización de consulta exitosa";
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

        public string EliminarConsulta(TablaConsultas tablaConsulta)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM consultas WHERE id = @id;", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", tablaConsulta.Id);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Registro borrado exitosamente";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
    }
}

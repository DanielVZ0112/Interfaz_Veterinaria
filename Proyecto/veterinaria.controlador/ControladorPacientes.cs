using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veterinaria.modelo;

namespace veterinaria.controlador
{
    public class ControladorPacientes
    {
        ModeloPacientes modeloPaciente = new ModeloPacientes();

        public string RegistrarPaciente(TablaPaciente tablaPacientes)
        {
            return modeloPaciente.RegistrarPacientes(tablaPacientes);
        }

        public DataTable ListarPacientes(string docPropietario)
        {
            return modeloPaciente.ListarPacientes(docPropietario);
        }

        public string EditarPaciente(TablaPaciente tablaPacientes)
        {
            return modeloPaciente.EditarPacientes(tablaPacientes);
        }

        public string EliminarPaciente(TablaPaciente tablaPacientes)
        {
            return modeloPaciente.EliminarPacientes(tablaPacientes);
        }
    }
}

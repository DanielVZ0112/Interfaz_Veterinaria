using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veterinaria.modelo;

namespace veterinaria.controlador
{
    public class ControladorConsultas
    {
        ModeloConsultas modeloConsultas = new ModeloConsultas();

        public string RegistrarConsulta(TablaConsultas tablaConsulta)
        {
            return modeloConsultas.RegistrarConsulta(tablaConsulta);
        }

        public DataTable ListarConsultas(string idPaciente)
        {
            return modeloConsultas.ListarConsultas(idPaciente);
        }

        public string EditarConsulta(TablaConsultas tablaConsulta)
        {
            return modeloConsultas.EditarConsulta(tablaConsulta);
        }

        public string EliminarConsulta(TablaConsultas tablaConsulta)
        {
            return modeloConsultas.EliminarConsulta(tablaConsulta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veterinaria.modelo;

namespace veterinaria.controlador
{
    public class ControladorPropietarios
    {
        ModeloPropietarios modeloPropietarios = new ModeloPropietarios();

        public string RegistrarPropietario(TablaPropietarios tablaPropietarios)
        {
            return modeloPropietarios.RegistrarPropietarios(tablaPropietarios);
        }

        public DataTable ListarPropietarios()
        {
            return modeloPropietarios.ListarPropietarios();
        }

        public string EditarPropietario(TablaPropietarios tablaPropietarios)
        {
            return modeloPropietarios.EditarPropietarios(tablaPropietarios);
        }

        public string EliminarPropietario(TablaPropietarios tablaPropietarios)
        {
            return modeloPropietarios.EliminarPropietarios(tablaPropietarios);
        }
        //public DataTable consultarPropietarioPorDocumento(string documento)
        //{
        //    return modeloPropietarios.consultarPropietarioPorDocumento(documento);
        //}
    }
}

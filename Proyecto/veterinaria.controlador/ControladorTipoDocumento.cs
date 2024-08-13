using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veterinaria.modelo;

namespace veterinaria.controlador
{
    public class ControladorTipoDocumento
    {
        ModeloTipoDocumento modeloTipoDocumento = new ModeloTipoDocumento();

        public DataTable ListarTipoDocumentos()
        {
            DataTable tiposDocumento = modeloTipoDocumento.ListarTiposDocumento();
            return tiposDocumento;
        }
    }
}

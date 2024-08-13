using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veterinaria.modelo;

namespace veterinaria.controlador
{
    public class ControladorDoctores
    {
        ModeloDoctores modeloDoctores = new ModeloDoctores();

        public TablaDoctores LoginDoctor(string username, string password)
        {
            DataTable doctores = modeloDoctores.loginDoctor(username, password);
            TablaDoctores tablaDoctores = new TablaDoctores();
            if (doctores.Rows.Count > 0)
            {
                tablaDoctores.Id = Convert.ToInt32(doctores.Rows[0]["id"].ToString());
                tablaDoctores.Nombre = doctores.Rows[0]["Nombre"].ToString();
            }
            return tablaDoctores;
        }
    }
}

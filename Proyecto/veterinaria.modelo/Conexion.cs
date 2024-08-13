using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinaria.modelo
{
    public class Conexion
    {
        public static string cadenaConexion()
        {
            string cadenaConexion =
                     "server=localhost;" +
                     "port=3306;" +
                     "database=Proyecto_FinalPOO_Avanzada;" +
                     "user id=root;" +
                     "password='';";
            return cadenaConexion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinaria.modelo
{
    public class TablaPropietarios
    {
        private int id;
        private int idTipoDocumento;
        private string documento;
        private string nombre;
        private string direccion;
        private string telefono;
        private string celular;
        private string correo;

        public int Id { get => id; set => id = value; }
        public int IdTipoDocumento { get => idTipoDocumento; set => idTipoDocumento = value; }
        public string Documento { get => documento; set => documento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Correo { get => correo; set => correo = value; }

        public TablaPropietarios() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinaria.modelo
{
    public class TablaPaciente
    {
        private int id;
        private int idPropietario;
        private string nombreMascota;
        private DateTime fechaNacimiento;
        private int edad;
        private string especie;
        private string raza;
        private string color;
        private int peso;
        private string sexo;
        private bool vacunado;

        public int Id { get => id; set => id = value; }
        public int IdPropietario { get => idPropietario; set => idPropietario = value; }
        public string NombreMascota { get => nombreMascota; set => nombreMascota = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Especie { get => especie; set => especie = value; }
        public string Raza { get => raza; set => raza = value; }
        public string Color { get => color; set => color = value; }
        public int Peso { get => peso; set => peso = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public bool Vacunado { get => vacunado; set => vacunado = value; }

        public TablaPaciente() { }
    }
}

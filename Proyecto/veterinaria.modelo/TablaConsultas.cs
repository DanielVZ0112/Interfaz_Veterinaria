using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinaria.modelo
{
    public class TablaConsultas
    {
        private int id;
        private int idPropietario;
        private int idPaciente;
        private int idDoctor;
        private DateTime fechaConsulta;
        private decimal costoConsulta;
        private string motivoConsulta;
        private string sintomas;
        private string diagnostico;
        private string formulaMedica;
        private bool aplicaExamenes;
        private string notasAdicionales;
        private DateTime proximoControl;

        public int Id { get => id; set => id = value; }
        public int IdPropietario { get => idPropietario; set => idPropietario = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public int IdDoctor { get => idDoctor; set => idDoctor = value; }
        public DateTime FechaConsulta { get => fechaConsulta; set => fechaConsulta = value; }
        public decimal CostoConsulta { get => costoConsulta; set => costoConsulta = value; }
        public string MotivoConsulta { get => motivoConsulta; set => motivoConsulta = value; }
        public string Sintomas { get => sintomas; set => sintomas = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string FormulaMedica { get => formulaMedica; set => formulaMedica = value; }
        public bool AplicaExamenes { get => aplicaExamenes; set => aplicaExamenes = value; }
        public string NotasAdicionales { get => notasAdicionales; set => notasAdicionales = value; }
        public DateTime ProximoControl { get => proximoControl; set => proximoControl = value; }

        public TablaConsultas() { }
    }
}

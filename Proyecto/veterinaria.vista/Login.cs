using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using veterinaria.controlador;
using veterinaria.modelo;

namespace veterinaria.vista
{
    public partial class Login : Form
    {
        public TablaDoctores tablaDoctores { get; set; }
        ControladorDoctores controladorDoctores = new ControladorDoctores();
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 2;

            if (m.Msg == WM_NCLBUTTONDOWN && (int)m.WParam == HTCAPTION)
            {
                return;
            }
            base.WndProc(ref m);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {   

            tablaDoctores = controladorDoctores.LoginDoctor(txtDocumentoUsuario.Text, txtContraseña.Text);
            if (string.IsNullOrEmpty(tablaDoctores.Nombre))
            {
                MessageBox.Show("Usuario o Contaseña incorrecta.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            } else {
                VeterinariaForm veterinariaForm = new VeterinariaForm(tablaDoctores);
                veterinariaForm.Show();
                this.Hide();    
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

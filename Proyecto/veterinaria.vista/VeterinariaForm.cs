using System;
using System.Data;
using System.Windows.Forms;
using veterinaria.controlador;
using veterinaria.modelo;

namespace veterinaria.vista
{
    public partial class VeterinariaForm : Form
    {
        ControladorTipoDocumento controladorTipoDocumento = new ControladorTipoDocumento();
        ControladorPropietarios controladorPropietarios = new ControladorPropietarios();
        ControladorPacientes controladorPacientes = new ControladorPacientes();
        ControladorConsultas controladorConsultas = new ControladorConsultas();

        TablaPropietarios tablaPropietarios = new TablaPropietarios();
        TablaPaciente tablaPaciente = new TablaPaciente();
        TablaConsultas tablaConsultas = new TablaConsultas();
        TablaDoctores tablaDoctorLogueado = new TablaDoctores();

        int idPropietarioSeleccionado = 0;
        int idPacienteSeleccionado = 0;
        
        public VeterinariaForm(TablaDoctores tablaDoctores)
        {
            InitializeComponent();
            cargarComboTipoDocumento();
            CargarDgvPropietario();
            tablaDoctorLogueado = tablaDoctores;
            txtDoctor.Text = tablaDoctorLogueado.Nombre;
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
        #region Propietario
        private void cargarComboTipoDocumento()
        {
            try
            {
                DataTable tipoDocumentos = controladorTipoDocumento.ListarTipoDocumentos();
                comboTipoDoc.ValueMember = "id";
                comboTipoDoc.DisplayMember = "Descripcion";
                comboTipoDoc.DataSource = tipoDocumentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDgvPropietario()
        {
            try
            {
                dgvPropietario.DataSource = controladorPropietarios.ListarPropietarios();
                dgvPropietario.Columns["id"].Visible = false;
                dgvPropietario.Columns["IdTipoDocumento"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardarPropietario_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposIngresadosPropietario())
                {
                    tablaPropietarios.IdTipoDocumento = Convert.ToInt32(comboTipoDoc.SelectedValue);
                    tablaPropietarios.Documento = txtDocumentoPropietario.Text;
                    tablaPropietarios.Nombre = txtNombreProp.Text;
                    tablaPropietarios.Direccion = txtDireccionPropietario.Text;
                    tablaPropietarios.Telefono = txtTelefonoPropietario.Text;
                    tablaPropietarios.Celular = txtCelularPropietario.Text;
                    tablaPropietarios.Correo = txtCorreoPropietario.Text;

                    string mensaje;
                    mensaje = controladorPropietarios.RegistrarPropietario(tablaPropietarios);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    CargarDgvPropietario();
                    LimpiarCamposPropietario();
                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditarPropietario_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposIngresadosPropietario())
                {
                    tablaPropietarios.Id = Convert.ToInt32(dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["id"].Value);
                    tablaPropietarios.IdTipoDocumento = Convert.ToInt32(comboTipoDoc.SelectedValue);
                    tablaPropietarios.Documento = txtDocumentoPropietario.Text;
                    tablaPropietarios.Nombre = txtNombreProp.Text;
                    tablaPropietarios.Direccion = txtDireccionPropietario.Text;
                    tablaPropietarios.Telefono = txtTelefonoPropietario.Text;
                    tablaPropietarios.Celular = txtCelularPropietario.Text;
                    tablaPropietarios.Correo = txtCorreoPropietario.Text;

                    string mensaje;
                    mensaje = controladorPropietarios.EditarPropietario(tablaPropietarios);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDgvPropietario();
                    LimpiarCamposPropietario();
                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarPropietario_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar el dato?",
               "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tablaPropietarios.Id = Convert.ToInt32(dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["id"].Value);

                    string mensaje;
                    mensaje = controladorPropietarios.EliminarPropietario(tablaPropietarios);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information    );
                    CargarDgvPropietario();
                    LimpiarCamposPropietario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        private void dgvPropietario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["IdTipoDocumento"].Value.ToString()))
            {
                comboTipoDoc.SelectedValue = int.Parse(dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["IdTipoDocumento"].Value.ToString());
                txtDocumentoPropietario.Text = dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["Documento"].Value.ToString();
                txtNombreProp.Text = dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                txtDireccionPropietario.Text = dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["Direccion"].Value.ToString();
                txtTelefonoPropietario.Text = dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["Telefono"].Value.ToString();
                txtCelularPropietario.Text = dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["Celular"].Value.ToString();
                txtCorreoPropietario.Text = dgvPropietario.Rows[dgvPropietario.CurrentRow.Index].Cells["Correo"].Value.ToString();
            }
        }
        private void txtTelefonoPropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtCelularPropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private bool ValidarCamposIngresadosPropietario()
        {
            bool camposIngresados = true;
            if (string.IsNullOrEmpty(txtDocumentoPropietario.Text) || string.IsNullOrEmpty(txtNombreProp.Text) ||
                string.IsNullOrEmpty(txtDireccionPropietario.Text) || string.IsNullOrEmpty(txtTelefonoPropietario.Text) || string.IsNullOrEmpty(txtCelularPropietario.Text) || string.IsNullOrEmpty(txtCorreoPropietario.Text))
            {
                camposIngresados = false;
            }
            return camposIngresados;
        }
        private void btnBuscarDocPropietario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDocumentoPropietario.Text))
            {
                foreach (DataGridViewRow row in dgvPropietario.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString() == txtDocumentoPropietario.Text)
                        {
                            row.Selected = true;
                            dgvPropietario.FirstDisplayedScrollingRowIndex = row.Index;
                            txtDocPropietario.Text = row.Cells["Documento"].Value.ToString();
                            txtNomProp_Paciente.Text = row.Cells["Nombre"].Value.ToString();
                            txtDocPropietario_Consulta.Text = row.Cells["Documento"].Value.ToString();
                            txtNombrePropietario_Consulta.Text = row.Cells["Nombre"].Value.ToString();
                            MessageBox.Show("El documento ingresado ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }
        private void LimpiarCamposPropietario()
        {
            comboTipoDoc.SelectedIndex = -1;
            txtDocumentoPropietario.Text = "";
            txtNombreProp.Text = "";
            txtDireccionPropietario.Text = "";
            txtTelefonoPropietario.Text = "";
            txtCelularPropietario.Text = "";
            txtCorreoPropietario.Text = "";
        }
        private void btnLimpiarPropietario_Click(object sender, EventArgs e)
        {
            LimpiarCamposPropietario();
        }
        private void btnSalirPropietario_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region Paciente
        private void CargarDgvPaciente(string docPropietario)
        {
            try
            {
                dgvPaciente.DataSource = controladorPacientes.ListarPacientes(docPropietario);
                if (!string.IsNullOrEmpty(dgvPaciente.Rows[0].Cells["id"].Value.ToString()))
                {
                    dgvPaciente.Columns["id"].Visible = false;
                    dgvPaciente.Columns["idPropietario"].Visible = false;
                    dgvPaciente.Columns["Nombre"].Visible = false;
                }
                idPropietarioSeleccionado = Convert.ToInt32(dgvPaciente.Rows[0].Cells["idProp"].Value.ToString());
                txtNomProp_Paciente.Text = dgvPaciente.Rows[0].Cells["Nombre"].Value.ToString();
                txtDocPropietario_Consulta.Text = dgvPaciente.Rows[0].Cells["Documento"].Value.ToString();
                txtNombrePropietario_Consulta.Text = dgvPaciente.Rows[0].Cells["Nombre"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       private double CalcularEdadMascota(string Edad)
        {
            double convertirMesesAMeses;
            if (rdbMeses.Checked)
            {
                convertirMesesAMeses = Convert.ToDouble(Edad) / 12;
                return convertirMesesAMeses;
            }
            else
            {
                convertirMesesAMeses = Convert.ToDouble(Edad);
                return convertirMesesAMeses;
            }
        }
        private void btnGuardarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposIngresadosPaciente())
                {
                    tablaPaciente.IdPropietario = idPropietarioSeleccionado;
                    tablaPaciente.NombreMascota = txtNomMascota.Text;
                    tablaPaciente.FechaNacimiento = dtpFechaNacimiento.Value;
                    tablaPaciente.Edad = (int)CalcularEdadMascota(txtEdad.Text);
                    tablaPaciente.Especie = txtEspecie.Text;
                    tablaPaciente.Raza = txtRaza.Text;
                    tablaPaciente.Color = comboColor.Text;
                    tablaPaciente.Peso = Convert.ToInt32(txtPeso.Text);
                    tablaPaciente.Sexo = rdbMacho.Checked ? "M" : "H";
                    tablaPaciente.Vacunado = chkVacunado.Checked;

                    string mensaje;
                    mensaje = controladorPacientes.RegistrarPaciente(tablaPaciente);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombreMascota_Consultas.Text = txtNomMascota.Text;                    
                    CargarDgvPaciente(txtDocPropietario.Text);
                    LimpiarCamposPaciente();

                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar el dato?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        tablaPaciente.Id = Convert.ToInt32(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["id"].Value);

                        string mensaje = controladorPacientes.EliminarPaciente(tablaPaciente);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDgvPaciente(txtDocPropietario.Text);
                        LimpiarCamposPaciente();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposIngresadosPaciente())
                {
                    tablaPaciente.Id = Convert.ToInt32(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["id"].Value);
                    tablaPaciente.NombreMascota = txtNomMascota.Text;
                    tablaPaciente.FechaNacimiento = dtpFechaNacimiento.Value;
                    tablaPaciente.Edad = (int)CalcularEdadMascota(txtEdad.Text);
                    tablaPaciente.Especie = txtEspecie.Text;
                    tablaPaciente.Raza = txtRaza.Text;
                    tablaPaciente.Color = comboColor.Text;
                    tablaPaciente.Peso = Convert.ToInt32(txtPeso.Text);
                    tablaPaciente.Sexo = rdbMacho.Checked ? "M" : "H";
                    tablaPaciente.Vacunado = chkVacunado.Checked;

                    string mensaje = controladorPacientes.EditarPaciente(tablaPaciente);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDgvPaciente(txtDocPropietario.Text);
                    LimpiarCamposPropietario();
                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        private void dgvPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["id"].Value.ToString()))
            {
                txtNomMascota.Text = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["NombreMascota"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["FechaNacimiento"].Value);
                txtEdad.Text = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Edad"].Value.ToString();
                rdbAños.Checked = true;
                txtEspecie.Text = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Especie"].Value.ToString();
                txtRaza.Text = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Raza"].Value.ToString();
                comboColor.Text = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Color"].Value.ToString();
                txtPeso.Text = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Peso"].Value.ToString();
                string sexo = dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Sexo"].Value.ToString();
                switch (sexo)
                {
                    case "M":
                        rdbMacho.Checked = true;
                        break;
                    case "H":
                        rdbHembra.Checked = true;
                        break;

                }
                chkVacunado.Checked = Convert.ToBoolean(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["Vacunado"].Value);
                CargarDgvConsultas(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["id"].Value.ToString());
                txtNombreMascota_Consultas.Text = txtNomMascota.Text;
                idPacienteSeleccionado = Convert.ToInt32(dgvPaciente.Rows[dgvPaciente.CurrentRow.Index].Cells["id"].Value.ToString());
            }
        }
        private bool ValidarCamposIngresadosPaciente()
        {
            bool camposIngresados = true;
            if (string.IsNullOrEmpty(txtDocPropietario.Text) || string.IsNullOrEmpty(txtNomMascota.Text) || string.IsNullOrEmpty(dtpFechaNacimiento.Text) ||
                string.IsNullOrEmpty(txtEspecie.Text) || string.IsNullOrEmpty(txtRaza.Text) || string.IsNullOrEmpty(comboColor.Text) || string.IsNullOrEmpty(txtEdad.Text))
            {
                camposIngresados = false;
            }
            return camposIngresados;
        }
        private void btnSalirPaciente_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtBuscarPropietario_Paciente_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtDocPropietario.Text))
            {
                CargarDgvPaciente(txtDocPropietario.Text);
            }
            else
            {
                MessageBox.Show("Debe ingresar un documento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLimpiarPaciente_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaciente();
        }
        private void LimpiarCamposPaciente()
        {
            txtNomMascota.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtEdad.Text = "";
            rdbAños.Checked = false;
            rdbMeses.Checked = false;
            txtEspecie.Text = "";
            txtRaza.Text = "";
            comboColor.Text = "";
            txtPeso.Text = "";
            rdbMacho.Checked = false;
            rdbHembra.Checked = false;
            chkVacunado.Checked = false;
        }
        #endregion

        #region Consultas

        private void CargarDgvConsultas(string idPaciente)
        {
            try
            {
                dgvConsultas.DataSource = controladorConsultas.ListarConsultas(idPaciente);
                dgvConsultas.Columns["id"].Visible = false;
                dgvConsultas.Columns["IdPropietario"].Visible = false;
                dgvConsultas.Columns["IdPaciente"].Visible = false;
                dgvConsultas.Columns["IdDoctor"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void btnGuardarConsultas_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposIngresadosConsultas())
                {
                    tablaConsultas.IdPropietario = idPropietarioSeleccionado;
                    tablaConsultas.IdPaciente = idPacienteSeleccionado;
                    tablaConsultas.IdDoctor = tablaDoctorLogueado.Id;
                    tablaConsultas.FechaConsulta = dateFechaConsulta.Value;
                    tablaConsultas.CostoConsulta = Convert.ToDecimal(txtCostoConsulta.Text);
                    tablaConsultas.MotivoConsulta = txtMotivoConsulta.Text;
                    tablaConsultas.Sintomas = txtSintomas.Text;
                    tablaConsultas.Diagnostico= txtDiagnostico.Text;    
                    tablaConsultas.FormulaMedica=txtFormulaMedica.Text;    
                    if(checkExamenes.Checked)
                    {
                        tablaConsultas.AplicaExamenes = true;
                    }
                    else
                    {
                        tablaConsultas.AplicaExamenes= false;
                    }
                    tablaConsultas.NotasAdicionales = txtNotaAdicional.Text;
                    tablaConsultas.ProximoControl = dtpFechaProximaConsulta.Value;

                    string mensaje;
                    mensaje = controladorConsultas.RegistrarConsulta(tablaConsultas);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDgvConsultas(Convert.ToString(idPacienteSeleccionado));
                    LimpiarCamposConsulta();
                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }
        private bool ValidarCamposIngresadosConsultas()
        {
            bool camposIngresados = true;
            if (string.IsNullOrEmpty(txtNombreMascota_Consultas.Text) || string.IsNullOrEmpty(txtDocPropietario_Consulta.Text) || string.IsNullOrEmpty(txtDoctor.Text) ||
                string.IsNullOrEmpty(txtSintomas.Text) || string.IsNullOrEmpty(dateFechaConsulta.Text) || string.IsNullOrEmpty(txtCostoConsulta.Value.ToString()) || string.IsNullOrEmpty(dtpFechaProximaConsulta.Text) ||
                 string.IsNullOrEmpty(txtFormulaMedica.Text) || string.IsNullOrEmpty(txtMotivoConsulta.Text) || string.IsNullOrEmpty(txtDiagnostico.Text) || string.IsNullOrEmpty(txtNotaAdicional.Text))
            {
                camposIngresados = false;
            }
            return camposIngresados;
        }
        private void btnSalirConsultas_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnEliminarConsultas_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar el dato?",
               "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tablaConsultas.Id = Convert.ToInt32(dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["id"].Value);

                    string mensaje;
                    mensaje = controladorConsultas.EliminarConsulta(tablaConsultas);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDgvConsultas(idPacienteSeleccionado.ToString());
                    LimpiarCamposConsulta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void btnEditarConsultas_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposIngresadosConsultas())
                {
                    tablaConsultas.Id = Convert.ToInt32(dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["id"].Value);
                    tablaConsultas.FechaConsulta = dateFechaConsulta.Value;
                    tablaConsultas.CostoConsulta = Convert.ToDecimal(txtCostoConsulta.Text);
                    tablaConsultas.MotivoConsulta = txtMotivoConsulta.Text;
                    tablaConsultas.Sintomas = txtSintomas.Text;
                    tablaConsultas.Diagnostico = txtDiagnostico.Text;
                    tablaConsultas.FormulaMedica = txtFormulaMedica.Text;
                    if (checkExamenes.Checked)
                    {
                        tablaConsultas.AplicaExamenes = true;
                    }
                    else
                    {
                        tablaConsultas.AplicaExamenes = false;
                    }
                    tablaConsultas.NotasAdicionales = txtNotaAdicional.Text;
                    tablaConsultas.ProximoControl = dtpFechaProximaConsulta.Value;

                    string mensaje;
                    mensaje = controladorConsultas.EditarConsulta(tablaConsultas);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDgvConsultas(Convert.ToString(idPacienteSeleccionado));
                    LimpiarCamposConsulta();
                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCamposConsulta()
        {
            txtSintomas.Text = ""; 
            dateFechaConsulta.Value = DateTime.Now;
            txtCostoConsulta.Text = "";
            dtpFechaProximaConsulta.Value = DateTime.Now;
            txtFormulaMedica.Text = ""; 
            txtMotivoConsulta.Text = ""; 
            txtDiagnostico.Text = ""; 
            txtNotaAdicional.Text = "";
            checkExamenes.Checked = false;
        }
        private void btnLimpiarConsultas_Click(object sender, EventArgs e)
        {
            LimpiarCamposConsulta();
        }

        private void dgvConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["id"].Value.ToString()))
            {
                txtSintomas.Text = dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["Sintomas"].Value.ToString();
                dateFechaConsulta.Value = Convert.ToDateTime(dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["FechaConsulta"].Value);
                txtCostoConsulta.Text = dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["CostoConsulta"].Value.ToString();
                dtpFechaProximaConsulta.Value = Convert.ToDateTime(dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["ProximoControl"].Value);
                txtFormulaMedica.Text = dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["FormulaMedica"].Value.ToString();
                txtMotivoConsulta.Text = dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["MotivoConsulta"].Value.ToString();
                txtDiagnostico.Text = dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["Diagnostico"].Value.ToString();
                txtNotaAdicional.Text = dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["NotasAdicionales"].Value.ToString();
                checkExamenes.Checked = Convert.ToBoolean(dgvConsultas.Rows[dgvConsultas.CurrentRow.Index].Cells["AplicaExamenes"].Value);
            }
        }

        private void btnCerrarSeccion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();   
        }

        #endregion
    }
}

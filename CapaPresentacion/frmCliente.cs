﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese el Apellido del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Direccion del Cliente");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el Numero de Documento del Cliente");
        }

        // mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // limpiamos todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
        }
        // habilitamos los controles de los formularios
        private void Habilitar(bool valor) //si recibimos true las cajas de texto van a estar habilitadas si recibimos false se desabilitan
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;            
            this.cmbTipo_Documento.Enabled = valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;            
            this.txtEmail.ReadOnly = !valor;
            this.txtIdCliente.ReadOnly = !valor;
        }
        // habilitamos los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        // metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dtgvListado.Columns[0].Visible = false; //columna eliminar
            //this.dtgvListado.Columns[1].Visible = false; //columna idcategoria
        }
        //metodo mostrar
        private void Mostrar()
        {
            this.dtgvListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarApellidos
        private void BuscarApellidos()
        {
            this.dtgvListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarNumero_Documento
        private void BuscarNumero_Documento()
        {
            this.dtgvListado.DataSource = NCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cmbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumero_Documento();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dtgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("Ok"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }

                    this.Mostrar();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ChkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dtgvListado.Columns[0].Visible = true;
            }
            else
            {
                this.dtgvListado.Columns[0].Visible = false;
            }
        }

        private void DtgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dtgvListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void DtgvListado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["idcliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["apellidos"].Value);
            this.cmbSexo.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["sexo"].Value);
            this.dtpFechaNacimiento.Value = Convert.ToDateTime(this.dtgvListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.cmbTipo_Documento.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["email"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtNum_Documento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtNombre, "Ingrese la Razon Social");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Numero de Documento");
                    errorIcono.SetError(txtDireccion, "Ingrese la Direccion");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text,
                            this.cmbSexo.Text, this.dtpFechaNacimiento.Value, 
                            cmbTipo_Documento.Text, txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text);
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text),
                            this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text,
                            this.cmbSexo.Text, this.dtpFechaNacimiento.Value,
                            cmbTipo_Documento.Text, txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text);
                    }
                }
                if (rpta.Equals("ok"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se inserto correctamente el registro");
                    }
                    else
                    {
                        this.MensajeOk("Se actualizo correctamente el registro");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                }

                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdCliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdCliente.Text = string.Empty;
            this.Habilitar(false);
        }
    }
}

using System;
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
    public partial class frmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        //dos procedimientos para cuando seleccionemos un articulo desde frmVistaCategoria_Articulo seleccionemos un articulo
        // nos aparesca la informacion en frmArticulo
        private static frmArticulo _Instancia;

        //en este procedimiento vemos si esta creada la instancia frmArticulo, si esta creada la envio, sino, la creo y la envio
        public static frmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmArticulo();
            }
            return _Instancia;
        }
        // con este metodo enviamos los datos a la caja de texto txtIdCategoria
        public void setCategoria (string idcategoria, string nombre)
        {
            this.txtIdCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }
            


        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la Categoria");
            this.ttMensaje.SetToolTip(this.pxImage, "Seleccione la imagen del Articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la categoria del Articulo");
            this.ttMensaje.SetToolTip(this.cmbIdPresentacion, "Seleccione la presentacion del Articulo");
            this.txtIdCategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();
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
            this.txtCodigoVta.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdArticulo.Text = string.Empty;
            //this.pxImage.Image = global::CapaPresentacion.Resources.file; REVISAR!!! imagen de fondo de pximage
        }
        // habilitamos los controles de los formularios
        private void Habilitar(bool valor) //si recibimos true las cajas de texto van a estar habilitadas si recibimos false se desabilitan
        {
            this.txtCodigoVta.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCat.Enabled = valor;
            this.cmbIdPresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdArticulo.ReadOnly = !valor;
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
            //this.dtgvListado.Columns[6].Visible = false; //columna idcategoria
            //this.dtgvListado.Columns[8].Visible = false; //columna idcategoria
        }
        //metodo mostrar
        private void Mostrar()
        {
            this.dtgvListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dtgvListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        // llenamos el combobox presentacion
        private void LlenarComboPresentacion()
        {
            cmbIdPresentacion.DataSource = NPresentacion.Mostrar();
            cmbIdPresentacion.ValueMember = "idpresentacion";
            cmbIdPresentacion.DisplayMember = "nombre";

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.pxImage.Image = global::CapaPresentacion.Resources.file; REVISAR LA IMAGEN A CARGAR
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.pxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImage.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
           // this.BuscarNombre();
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
                if (this.txtNombre.Text == string.Empty || this.txtIdCategoria.Text == string.Empty || this.txtCodigoVta.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtNombre, "Ingrese un nombre");
                    errorIcono.SetError(txtCategoria, "Ingrese una Categoria");
                    errorIcono.SetError(txtCodigoVta, "Ingrese un Codigo");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(); //creamos el buffer para guardar la imagen que eliga el usuario
                    this.pxImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer(); //array para obtener y meter en imagen lo que esta en el buffer creado ms

                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(this.txtCodigoVta.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdCategoria.Text),
                            Convert.ToInt32(this.cmbIdPresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdArticulo.Text), this.txtCodigoVta.Text,
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(),                            
                            imagen, Convert.ToInt32(this.txtIdCategoria.Text),
                            Convert.ToInt32(this.cmbIdPresentacion.SelectedValue));
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
                    this.MensajeError(rpta);//Aca salta el error
                    //MessageBox.Show("ERROR");
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
                //MessageBox.Show("ERROR");
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdArticulo.Text.Equals(""))
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
            this.Habilitar(false);
        }

        private void DtgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dtgvListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void DtgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdArticulo.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["IdArticulo"].Value);
            this.txtCodigoVta.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["descripcion"].Value);
            //para la imagen
            byte[] imagenBuffer = (byte[])this.dtgvListado.CurrentRow.Cells["Imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImage.Image = Image.FromStream(ms);
            this.pxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            // hasta aca
            this.txtIdCategoria.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["IdCategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["Categoria"].Value);
            this.cmbIdPresentacion.SelectedValue = Convert.ToString(this.dtgvListado.CurrentRow.Cells["IdPresentacion"].Value);
            this.tabControl1.SelectedIndex = 1;
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
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

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

        private void CmbIdPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteArticulos frm = new frmReporteArticulos();
            frm.ShowDialog();
        }
    }
}

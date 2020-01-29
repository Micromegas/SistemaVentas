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
    public partial class frmIngreso : Form
    {
        public int Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private static frmIngreso _instancia;// en esta instancia verifico si ya esta abierto el formulario frmIngreso
        //si esta abierto no abro otro, si no esta abierto lo abro
        public static frmIngreso GetInstancia()
        {
            if (_instancia==null)
            {
                _instancia = new frmIngreso();
            }
            return _instancia;
        }
        public void setProveedor(string idproveedor, string nombre)
        {
            this.txtIdProveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }
        public void setArticulo(string idarticulo, string nombre)
        {
            this.txtIdArticulo.Text = idarticulo;
            this.txtArticulo.Text = nombre;
        }



        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Seleccione la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad del articulo");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el Articulo de compra");
            this.txtIdProveedor.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
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
            this.txtIdingreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIGV.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";
            this.txtIGV.Text = "21";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {

        }
        // habilitamos los controles de los formularios
        private void Habilitar(bool valor) //si recibimos true las cajas de texto van a estar habilitadas si recibimos false se desabilitan
        {
            this.txtIdingreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIGV.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cmbTipo_Comprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }
        // habilitamos los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }
        // metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dtgvListado.Columns[0].Visible = false; //columna eliminar
            //this.dtgvListado.Columns[1].Visible = false; //columna idcategoria
            //this.dtgvListado.Columns[6].Visible = false; //columna 
            //this.dtgvListado.Columns[8].Visible = false; //columna 
        }
        //metodo mostrar
        private void Mostrar()
        {
            this.dtgvListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarFechas
        private void BuscarFechas()
        {
            this.dtgvListado.DataSource = NIngreso.BuscarFecha(this.dtFecha1.Value.ToString("MM/dd/yyyy"),
                this.dtFecha2.Value.ToString("MM/dd/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        
        //metodo BuscarDetalles
        private void MostrarDetalle()
        {            
            //this.dtgvListado.DataSource = NIngreso.MostrarDetalles(this.txtIdingreso.Text);
            this.dtgvDetalles.DataSource = NIngreso.MostrarDetalles(this.txtIdingreso.Text);
        }
        private void crearTabla()
        {
            //esta es la tabla que se carga al ingresar al formulario
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //relacionamos el DatGridView con el DataTable
            //cambiamos aca!!!!
            //this.dtgvListado.DataSource = this.dtDetalle;
            this.dtgvDetalles.DataSource = this.dtDetalle;
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null; //cuando se cierre el formulario la instancia es igual a null
        }

        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso vista = new frmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Ingreso vista = new frmVistaArticulo_Ingreso();
            vista.ShowDialog();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea anular los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dtgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("Ok"))
                            {
                                this.MensajeOk("Se abulo correctamente el ingreso");
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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.limpiarDetalle();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIGV.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtIdProveedor, "Ingrese un Proveedor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    errorIcono.SetError(txtIGV, "Ingrese un valor");
                }
                else
                {
                    

                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(Idtrabajador, Convert.ToInt32(this.txtIdProveedor.Text),
                            dtFecha.Value, cmbTipo_Comprobante.Text, txtSerie.Text, txtCorrelativo.Text,
                            Convert.ToDecimal(txtIGV.Text), "EMITIDO", dtDetalle);
                    }
                    
                }
                if (rpta.Equals("ok"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se inserto correctamente el registro");
                    }                   
                }
                else
                {
                    this.MensajeError(rpta);//Aca salta el error
                    //MessageBox.Show("ERROR");
                }

                this.IsNuevo = false;
                this.Botones();
                this.Limpiar();
                this.limpiarDetalle();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                //MessageBox.Show("ERROR");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdArticulo.Text == string.Empty || this.txtStock.Text == string.Empty ||
                    this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un valor");
                    errorIcono.SetError(txtStock, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(this.txtIdArticulo.Text))//si lo que esta en la fila idarticulo esta en la 
                            //caja de texto txtIdeArticulo no va a permitir ingresarlo nuevamente
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar) //es true
                    {
                        decimal SubTotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        totalPagado = totalPagado + SubTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //agregamos ese detalle al dtgvDetalles
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtIdArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fecha_produccion"] = dtFechaProduccion.Value;
                        row["fecha_vencimiento"] = dtFechaVencimiento.Value;
                        row["subtotal"] = SubTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }

                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                //MessageBox.Show("ERROR");
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dtgvDetalles.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //disminuir el total pagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover!");
            }
        }

        private void DtgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdingreso.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["idingreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dtgvListado.CurrentRow.Cells["fecha"].Value);
            this.cmbTipo_Comprobante.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;

        }

        private void DtgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}

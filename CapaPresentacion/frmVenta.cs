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
    public partial class frmVenta : Form
    {
        public bool IsNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle; //en este datatable almacenamos todos los detalles de la venta
        private decimal totalPagado = 0;
        private static frmVenta _instancia;

        public static frmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();//si no esta la instancia creada la creamos
            }
            return _instancia;//si la instancia esta creada la devolvemos
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdCliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setArticulo(string iddetalle_ingreso, string nombre, decimal precio_compra, decimal precio_venta,
            int stock, DateTime fecha_vencimiento)
        {
            this.txtIdArticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecioCompra.Text = Convert.ToString(precio_compra);
            this.txtPrecioVenta.Text = Convert.ToString(precio_venta);
            this.txtStock_Actual.Text = Convert.ToString(stock);
            this.dtFechaVencimiento.Value = fecha_vencimiento;
        }
        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Seleccione un Comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Seleccione un Numero de comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Seleccione una Cantidad");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Articulo");
            this.txtIdCliente.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFechaVencimiento.Enabled = false;
            this.txtPrecioCompra.ReadOnly = true;
            this.txtStock_Actual.ReadOnly = true;
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
            this.txtIdventa.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIGV.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";
            this.txtIGV.Text = "21";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock_Actual.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
        }
        // habilitamos los controles de los formularios
        private void Habilitar(bool valor) //si recibimos true las cajas de texto van a estar habilitadas si recibimos false se desabilitan
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIGV.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cmbTipo_Comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtStock_Actual.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.dtFechaVencimiento.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
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
            this.dtgvListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarFechas
        private void BuscarFechas()
        {
            this.dtgvListado.DataSource = NVenta.BuscarFecha(this.dtFecha1.Value.ToString("MM/dd/yyyy"),
                this.dtFecha2.Value.ToString("MM/dd/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }

        //metodo BuscarDetalles
        private void MostrarDetalle()
        {
            this.dtgvListado.DataSource = NVenta.MostrarDetalles(this.txtIdventa.Text);
        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));//le indicamos el tipo de dato del que va a ser la columna
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //relacionamos el DatGridView con el DataTable
            //cambiamos aca!!!!
            //this.dtgvListado.DataSource = this.dtDetalle;
            this.dtgvDetalles.DataSource = this.dtDetalle;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente_Venta vista = new frmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Venta vista = new frmVistaArticulo_Venta();
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
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("Ok"))
                            {
                                this.MensajeOk("Se elimino correctamente la venta");
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
            this.txtIdventa.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dtgvListado.CurrentRow.Cells["fecha"].Value);
            this.cmbTipo_Comprobante.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dtgvListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);         
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdCliente.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIGV.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtIdCliente, "Ingrese un Proveedor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    errorIcono.SetError(txtIGV, "Ingrese un valor");
                }
                else
                {


                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text), Idtrabajador,
                            dtFecha.Value, cmbTipo_Comprobante.Text, txtSerie.Text, txtCorrelativo.Text,
                            Convert.ToDecimal(txtIGV.Text), dtDetalle);
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
                if (this.txtIdArticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty ||
                    this.txtDescuento.Text == string.Empty /*|| this.txtPrecioVenta.Text == string.Empty*/)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un valor");
                    //errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;//verifica si se puede registra la venta
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdArticulo.Text))//si lo que esta en la fila idarticulo esta en la 
                                                                                                           //caja de texto txtIdeArticulo no va a permitir ingresarlo nuevamente
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock_Actual.Text))
                    //es true, y que la cantidad a vender sea menos al stock actual                    
                    {
                        decimal SubTotal = Convert.ToDecimal(this.txtCantidad.Text) 
                            * Convert.ToDecimal(this.txtPrecioVenta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + SubTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //agregamos ese detalle al dtgvDetalles
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtIdArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = SubTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }
                    else
                    {
                        MensajeError("No hay stock suficiente");
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            frmReporteFactura frm = new frmReporteFactura();
            frm.Idventa = Convert.ToInt32(this.dtgvListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();
        }
    }    
 }
    


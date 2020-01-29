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
    public partial class frmVistaArticulo_Venta : Form
    {
        public frmVistaArticulo_Venta()
        {
            InitializeComponent();
        }
        // metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dtgvListado.Columns[0].Visible = false; //columna eliminar
            //this.dtgvListado.Columns[1].Visible = false; //columna idcategoria
        }

        private void Mostrar_Carga_Vista()
        {
            //mio
            this.dtgvListado.DataSource = NVenta.Mostrar_Carga_Vista();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }

        //metodo BuscarNombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dtgvListado.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarCodigo
        private void MostrarArticulo_Venta_Codigo()
        {            
            this.dtgvListado.DataSource = NVenta.MostrarArticulo_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }

        private void FrmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            //mio
            Mostrar_Carga_Vista();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (cmbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        private void DtgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string parametro1, parametro2;
            decimal parametro3, parametro4; //precio_compra precio_venta
            int parametro5; //cantidad
            DateTime parametro6; //fecha_vencimiento
            parametro1 = Convert.ToString(this.dtgvListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            parametro2 = Convert.ToString(this.dtgvListado.CurrentRow.Cells["nombre"].Value);
            parametro3 = Convert.ToDecimal(this.dtgvListado.CurrentRow.Cells["precio_compra"].Value);
            parametro4 = Convert.ToDecimal(this.dtgvListado.CurrentRow.Cells["precio_venta"].Value);
            parametro5 = Convert.ToInt32(this.dtgvListado.CurrentRow.Cells["stock_actual"].Value);
            parametro6 = Convert.ToDateTime(this.dtgvListado.CurrentRow.Cells["fecha_vencimiento"].Value);
            form.setArticulo(parametro1, parametro2, parametro3, parametro4, parametro5, parametro6);
            this.Hide();
        }

        private void DtgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

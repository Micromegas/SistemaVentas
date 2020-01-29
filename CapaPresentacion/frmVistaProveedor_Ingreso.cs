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
    public partial class frmVistaProveedor_Ingreso : Form
    {
        public frmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
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
            this.dtgvListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dtgvListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarNumero_Documento
        private void BuscarNumero_Documento()
        {
            this.dtgvListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cmbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumero_Documento();
            }
        }

        private void DtgvListado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string parametro1, parametro2;
            parametro1 = Convert.ToString(this.dtgvListado.CurrentRow.Cells["idproveedor"].Value);
            parametro2 = Convert.ToString(this.dtgvListado.CurrentRow.Cells["razon_social"].Value);
            form.setProveedor(parametro1, parametro2);
            this.Hide();
        }

        private void DtgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

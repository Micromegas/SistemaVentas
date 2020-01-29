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
    public partial class frmVistaCategoria_Articulo : Form
    {
        public frmVistaCategoria_Articulo()
        {
            InitializeComponent();
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
            this.dtgvListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }
        //metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dtgvListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dtgvListado.Rows.Count);
        }

        private void FrmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void DtgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DtgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo form = frmArticulo.GetInstancia();//llamamos a la instancia de frmArticulo
            string parametroUno, parametroDos;
            parametroUno = Convert.ToString(this.dtgvListado.CurrentRow.Cells["idcategoria"].Value);
            parametroDos = Convert.ToString(this.dtgvListado.CurrentRow.Cells["nombre"].Value);
            form.setCategoria(parametroUno, parametroDos);
            this.Hide();
        }

        private void LblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}

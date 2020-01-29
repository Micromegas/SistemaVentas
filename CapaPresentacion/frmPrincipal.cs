using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PresentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frm = frmArticulo.GetInstancia(); //en el archivo frmArticulo tenemos codigo para saber si creamos una instancia(ver)
            // si la instancia esta creada la llamamos si no esta creada la instancia entonces la creamos
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuarios();
        }

        private void GestionUsuarios()
        {
            //Controla los accesos
            if ( Acceso == "Administrador")
            {
                this.MenuSistema.Enabled = true;
                this.MenuCompras.Enabled = true;
                this.MenuConsultas.Enabled = true;
                this.MenuDeposito.Enabled = true;
                this.MenuVentas.Enabled = true;
                this.MenuMantenimiento.Enabled = true;
                this.MenuView.Enabled = true;
                this.MenuTools.Enabled = true;
                this.MenuWindows.Enabled = true;
                this.MenuHelp.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;
            }
            else if ( Acceso == "Vendedor")
            {
                this.MenuSistema.Enabled = true;
                this.MenuCompras.Enabled = false;
                this.MenuConsultas.Enabled = true;
                this.MenuDeposito.Enabled = false;
                this.MenuVentas.Enabled = true;
                this.MenuMantenimiento.Enabled = false;
                this.MenuView.Enabled = true;
                this.MenuTools.Enabled = true;
                this.MenuWindows.Enabled = true;
                this.MenuHelp.Enabled = true;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = true;
            }
            else if (Acceso == "Deposito")
            {
                this.MenuSistema.Enabled = true;
                this.MenuCompras.Enabled = true;
                this.MenuConsultas.Enabled = true;
                this.MenuDeposito.Enabled = true;
                this.MenuVentas.Enabled = false;
                this.MenuMantenimiento.Enabled = false;
                this.MenuView.Enabled = true;
                this.MenuTools.Enabled = true;
                this.MenuWindows.Enabled = true;
                this.MenuHelp.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = false;
            }
            else
            {
                this.MenuSistema.Enabled = false;
                this.MenuCompras.Enabled = false;
                this.MenuConsultas.Enabled = false;
                this.MenuDeposito.Enabled = false;
                this.MenuVentas.Enabled = false;
                this.MenuMantenimiento.Enabled = false;
                this.MenuView.Enabled = false;
                this.MenuTools.Enabled = false;
                this.MenuWindows.Enabled = false;
                this.MenuHelp.Enabled = false;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = false;
            }
        }

        private void IngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void VentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void stockDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.frmConsulta_Stock_Articulos frm = new Consultas.frmConsulta_Stock_Articulos();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}

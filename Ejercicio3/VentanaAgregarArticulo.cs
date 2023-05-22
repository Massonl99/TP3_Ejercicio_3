using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class VentanaAgregarArticulo : Form
    {
        private VentanaPrincipal principal = Application.OpenForms.OfType<VentanaPrincipal>().FirstOrDefault(); 

        public VentanaAgregarArticulo()
        {
            InitializeComponent();
            CargarTabla();
        }
        public void CargarTabla()
        {
            IReadOnlyList<Articulo> ListaArticulos = principal.ListaArticulos;
            //Cargamos la lista 
            GridArticulos.DataSource = ListaArticulos;
            GridArticulos.Columns[0].Visible = false;
            GridArticulos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            principal.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool pass = true;
            if(boxCantidad.Text == "" || !int.TryParse(boxCantidad.Text,out int num) || num<=0)
            {
                error1.SetError(boxCantidad, "Debe Ingresar una cantidad");
                boxCantidad.Focus();
                pass = false;
            }
            else
                error1.SetError(boxCantidad, "");
            if (GridArticulos.SelectedRows.Count < 0)
            {
                MessageBox.Show("Debe seleccionar un producto");
                pass= false;
            }
            if(pass == true)
            {
                int nArticulo = GridArticulos.CurrentCell.RowIndex;
                principal.AgregarProducto(nArticulo,int.Parse(boxCantidad.Text));
                principal.Show();
                this.Close();
            }

        }
    }
}

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
    public partial class VentanaNuevoArticulo : Form
    {
        private VentanaPrincipal principal = Application.OpenForms.OfType<VentanaPrincipal>().FirstOrDefault();
        private int id;

        public VentanaNuevoArticulo()
        {
            InitializeComponent();
            CargarTabla();
            boxCodigo.Enabled = false;
        }
        //Metodos
       
        public void CargarTabla()
        {
            IReadOnlyList<Articulo> ListaArticulos = principal.ListaArticulos;
            id = 00001 + ListaArticulos.Count;
            boxCodigo.Text = id.ToString("00000");
            //limiamos las entradas
            boxPrecio.Clear();
            boxDenominacion.Clear();
            //Cargamos la lista 
            GridArticulos.DataSource = ListaArticulos;
            GridArticulos.Columns[0].Visible = false;
            GridArticulos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        //Botones
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            principal.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool pass = true;

            if(boxDenominacion.Text == "")
            {
                error2.SetError(boxDenominacion, "Ingrese la denominacion aqui");
                boxDenominacion.Focus();
                pass = false;
            }
            else
                error2.SetError(boxDenominacion, "");

           if (boxPrecio.Text == "" || !float.TryParse(boxPrecio.Text,out float nose) || nose <= 0)
            {
                error2.SetError(boxPrecio, "Ingrese el precio aqui");
                boxPrecio.Focus();
                pass = false;
            }
            else
                error2.SetError(boxPrecio,"");
         
            if (pass == true)
            {
                principal.CrearNuevoArticulo(id, boxDenominacion.Text, float.Parse(boxPrecio.Text));
                CargarTabla();
            }
            else
            {
                MessageBox.Show("ERROR al Ingresar Los Datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridArticulos.SelectedRows.Count > 0)
            {
                int nArticulo = GridArticulos.CurrentCell.RowIndex;
                principal.EliminarArticulo(nArticulo);
                CargarTabla();
            }
            else
            {
                MessageBox.Show("Selecciones un Articulo para eliminar");
            }
        }
    }
}

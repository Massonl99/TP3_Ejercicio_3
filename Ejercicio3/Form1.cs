using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ejercicio3
{
    public partial class VentanaPrincipal : Form
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Articulo> articulos = new List<Articulo>();

        private Factura factura = new Factura();

        public VentanaPrincipal()
        {
            InitializeComponent();
            cbClientes.Text = "Seleccione un Cliente";
            ActualizarCarrito();
            boxTotal.Enabled = false;
            boxTotal.TextAlign = HorizontalAlignment.Right;
        }
        //Metodos
        public IReadOnlyList<Articulo> ListaArticulos
        {
            get { return articulos.AsReadOnly(); }
        }
        public void ActualizarListaClientes()
        {
            cbClientes.Items.Clear();   
            cbClientes.Text = "Seleccione un Cliente";
            foreach (Cliente i in clientes)
            {
                cbClientes.Items.Add(i);
            }
            cbClientes.DisplayMember = "NombreCompleto";
        }
        public void CrearNuevoCliente(string nombre, string apellido, int DNI)
        {
            clientes.Add(new Cliente());
            clientes.Last().DNI = DNI;
            clientes.Last().Nombre = nombre;
            clientes.Last().Apellido = apellido;
            ActualizarListaClientes();
        }
        public void CrearNuevoArticulo(int codigo,string denominacion, float precio)
        {
            articulos.Add(new Articulo());
            articulos.Last().Codigo = codigo;
            articulos.Last().Denominacion = denominacion;
            articulos.Last().Precio = precio;
        }
        public void EliminarArticulo(int nProducto)
        {
            articulos.RemoveAt(nProducto);
        }
        public void AgregarProducto(int nFila, int cantidad)
        {
            factura.articulos.Add(articulos[nFila]);
            factura.cantidadArticulos.Add(cantidad);
            ActualizarCarrito();
        }
        public void ActualizarCarrito()
        {
            GridFactura.Rows.Clear();

            //creamos y cargamos los nombres de las comlumnas
            GridFactura.ColumnCount = 4;
            GridFactura.Columns[0].Name = "CODIGO";
            GridFactura.Columns[0].Width = 75;
            GridFactura.Columns[1].Name = "Cantidad";
            GridFactura.Columns[1].Width = 75;
            GridFactura.Columns[2].Name = "Producto";
            GridFactura.Columns[3].Name = "Precio";
            GridFactura.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Cargar las lista

            for (int i= 0; i< factura.articulos.Count;i++)
            {
                string Codigo = factura.articulos[i].CODIGO;
                string cantidad = factura.cantidadArticulos[i].ToString();
                string Producto = factura.articulos[i].Denominacion;
                string precio ="$ "+ factura.articulos[i].Precio.ToString();
                GridFactura.Rows.Add(Codigo, cantidad, Producto, precio);
            }
            ActualizarTotal();
        }
        public void EliminardelaFactura(int nProducto)
        {
            factura.articulos.RemoveAt(nProducto);
            factura.cantidadArticulos.RemoveAt(nProducto);
        }
        public void ActualizarTotal()
        {
            float total=0;
            for (int i = 0; i < factura.articulos.Count;i++)
            {
                total += factura.articulos[i].Precio * factura.cantidadArticulos[i];
            }
            boxTotal.Text ="$ " + total.ToString();
        }
        public void Facturar()
        {

        }
        //Botones
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            VentanaNuevoCliente ventanaNuevoCliente = new VentanaNuevoCliente();
            ventanaNuevoCliente.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            VentanaNuevoArticulo ventanaNuevoArticulo = new VentanaNuevoArticulo(); 
            ventanaNuevoArticulo.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            VentanaAgregarArticulo agregarArticulo = new VentanaAgregarArticulo();
            agregarArticulo.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            factura = new Factura();
            ActualizarCarrito();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (GridFactura.SelectedRows.Count > 0)
            {
                int nArticulo = GridFactura.CurrentCell.RowIndex;
                EliminardelaFactura(nArticulo);
                ActualizarCarrito();
            }
            else
            {
                MessageBox.Show("Selecciones un Articulo para eliminar");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            bool pass = true;
            if(cbClientes.SelectedIndex <0)
            {
                MessageBox.Show("Por favor seleccione un Cliente");
                pass = false;
            }
            if (boxTotal.Text == "$ 0")
            {
                MessageBox.Show("Lista a Facturar Vacia");
                pass = false;
            }
            if(pass == true)
            {
                Facturar();
            }
        }

    }
}

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


        public VentanaPrincipal()
        {
            InitializeComponent();
            cbClientes.Text = "Seleccione un Cliente";
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
    }
}

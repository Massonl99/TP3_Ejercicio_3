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
    public partial class VentanaNuevoCliente : Form
    {
        private VentanaPrincipal principal = Application.OpenForms.OfType<VentanaPrincipal>().FirstOrDefault();
       
        public VentanaNuevoCliente()
        {
            InitializeComponent();
        }
        //Botones
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Paso = true;
            if(boxNombre.Text == "")
            {
                error1.SetError(boxNombre, "Ingrese el nombre aqui");
                boxNombre.Focus();
                Paso = false;
            }
            else
            error1.SetError(boxNombre, "");
            if (boxApellido.Text == "")
            {
                error1.SetError(boxApellido, "Ingrese el apellido aqui");
                boxApellido.Focus();
                Paso = false;
            }
            else
                error1.SetError(boxApellido, "");
            if (BoxDNI.Text.Length != 8 || !int.TryParse(BoxDNI.Text, out _))
            {
                error1.SetError(BoxDNI, "Ingrese el DNI aqui");
                BoxDNI.Focus();
                Paso = false;
            }
            else
            error1.SetError(BoxDNI, "");
            if (Paso == true)
            {
                principal.CrearNuevoCliente(boxNombre.Text, boxApellido.Text, int.Parse(BoxDNI.Text));
                principal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR al Ingresar Los Datos");
            }
        }

        private void boxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

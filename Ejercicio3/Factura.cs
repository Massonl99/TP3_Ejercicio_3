using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class Factura
    {
       
        private int numero;
        private Cliente cliente;

        //----------------------lineas---------------------------------------
        public List<Articulo> articulos = new List<Articulo>();
        public List<int> cantidadArticulos = new List<int>();
        //-------------------------------------------------------------------

        public int Numero {
            get { return numero; }
            set { numero = value; }
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
    }
}

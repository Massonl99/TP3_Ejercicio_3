using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class Articulo
    {
        private int codigo;
        private string denominacion;
        private float precio;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string CODIGO{ get { return codigo.ToString("00000"); }}
        public string Denominacion { get { return denominacion; } set {  denominacion = value; }}
        public float Precio{get { return precio; }set { precio = value; }}
    }
}

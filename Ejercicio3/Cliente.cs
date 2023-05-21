using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class Cliente
    {
        private int dni; //variable en minusculas
        private string nombre;
        private string apellido;

        //Metodos
        public string NombreCompleto
        {
            get { return $"{apellido}, {nombre}"; }
        }
        public int DNI {get { return dni;}set { dni = value; }}
        public string Nombre { get {  return nombre;}set {  nombre = value; }}
        public string Apellido { get {  return apellido;}set {  apellido = value; }}

        
    }
}

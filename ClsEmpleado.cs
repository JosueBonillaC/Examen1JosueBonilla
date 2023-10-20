using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsEmpleado
    {
        // atributos
        public string cedula {  get; set; } 
        public string nombre{ get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public float salario { get; set; }



        //metodos 

        //constructor
        public ClsEmpleado(string cedula, string nombre, string direccion, int telefono, float salario)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.salario = salario;
        }

        

        


    }
}

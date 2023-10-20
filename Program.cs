using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClsMenu.Inicializar();

            int opcion;
            do
            {
                // Mostrar el menú principal
                ClsMenu.Mostarar();

                // Leer la opción del usuario
                opcion = int.Parse(Console.ReadLine());


            } while (opcion != 0);

        }
    }
}

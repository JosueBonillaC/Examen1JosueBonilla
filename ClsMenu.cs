using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsMenu
    {
        private static ClsEmpleado[] empleados;
        private static int aux = 0;
        private static int opcion = 0;
        private static int cant = 0;

        //metodos 


         public static void Inicializar()
        {
            Console.WriteLine("Ingrese la cantidad máxima de empleados:");
            cant = int.Parse(Console.ReadLine());

            empleados = new ClsEmpleado[cant];
            aux = 0;
        }
        public static void Mostarar()
        {
            do
            {
                Console.WriteLine("1- Agregar empleados");
                Console.WriteLine("2- Consultar empleados");
                Console.WriteLine("3- Modificar empleados");
                Console.WriteLine("4- Borrar empleados");
                Console.WriteLine("5- Inicializar arreglos");
                Console.WriteLine("6- Reportes");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {

                    case 1:
                        AgregarEmpleado();
                        
                        break;

                    case 2: 
                        ConsultarEmpleado(); 
                        
                        break;

                    case 3:
                        ModificarEmpleado();
                        
                        break;
                    case 4: 
                        BorrarEmpleado();
                        
                        break;
                    case 5:
                        InicializarArreglos();
                        
                        break;

                    case 6:
                        MenuReportes();
                        
                        break;


                    default:
                        Console.WriteLine("Ingrese una opcion correcta");
                        break;
                }
            } while (true);
        }

        public static void AgregarEmpleado()
        {
            if (aux < cant)
            {
                Console.WriteLine("Ingrese la cédula del empleado:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del empleado:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la dirección del empleado:");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el teléfono del empleado:");
                int telefono = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el salario del empleado:");
                float salario = float.Parse(Console.ReadLine());

                empleados[aux] = new ClsEmpleado(cedula, nombre, direccion, telefono, salario);
                aux++;

                Console.WriteLine("El empleado fue agregado");
            }else
            {
                Console.WriteLine("No puede agregar mas empleados");
            }
        }

        public static void ConsultarEmpleado()
        {
            Console.WriteLine("La lista de empleados:");

            for (int i = 0; i < aux; i++)
            {
                Console.WriteLine($"Cédula: {empleados[i].cedula}, Nombre: {empleados[i].nombre}, Direccion: {empleados[i].direccion} Telefono: {empleados[i].telefono}, Salario: {empleados[i].salario}");


            }
        }
        // Buscar un empleado por cédula 
        static int BuscarEmpleadoCedula(string cedula)
        {
            for (int i = 0; i < aux; i++)
            {
                if (empleados[i].cedula == cedula)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void ModificarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado para modificar:");
            string cedula = Console.ReadLine();

            int indice = BuscarEmpleadoCedula(cedula);

            if (indice != -1)
            {
                Console.WriteLine("Ingrese el nuevo nombre del empleado:");
                empleados[indice].nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva dirección del empleado:");
                empleados[indice].direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo teléfono del empleado:");
                empleados[indice].telefono = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo salario del empleado:");
                empleados[indice].salario = float.Parse(Console.ReadLine());

                Console.WriteLine("Empleado modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }

        }

        public static void BorrarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a borrar:");
            string cedula = Console.ReadLine();

            int indice = BuscarEmpleadoCedula(cedula);

            if (indice != -1)
            {
                for (int i = indice; i < aux - 1; i++)
                {
                    empleados[i] = empleados[i + 1];
                }
                aux--;

                Console.WriteLine("Empleado borrado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }
        public static void InicializarArreglos()
        {
            
            empleados = new ClsEmpleado[empleados.Length];
            aux = 0;

            Console.WriteLine("Arreglos inicializados con éxito.");
        }

        //Reportes 

        public static void MenuReportes()
        {
            do
            {
                Console.WriteLine("1- Consultar empleado con numero de cedula");
                Console.WriteLine("2- Listar todos los empleados");
                Console.WriteLine("3- Calcular y mostrar el promedio de los salarios");
                Console.WriteLine("4- Calcular y mostrar el salario mas alto y el mas bajo de los empleados");
                Console.WriteLine("5- Volver");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {

                    case 1:
                        ConsultareEmpleadoCedulaReportes();
                        
                        break;

                    case 2:
                        ListarEmpleadosOrdenados();
                        
                        break;

                    case 3:
                        CalcularPromedioSalarios();
                        
                        break;
                    case 4:
                        MostrarSalarios();
                       
                        break;
                    case 5:
                        Mostarar();
                        break;

                    default:
                        Console.WriteLine("Ingrese una opcion correcta");
                        break;
                }
            } while (true);
        }

        public static void ConsultareEmpleadoCedulaReportes()
        {
            Console.WriteLine("Ingrese la cédula del empleado a consultar:");
            string cedula = Console.ReadLine();

          
            int indice = BuscarEmpleadoCedula(cedula);

            if (indice != -1)
            {
                Console.WriteLine($"Nombre: {empleados[indice].nombre}, Cédula: {empleados[indice].cedula}, Direccion: {empleados[indice].direccion}, Telefono: {empleados[indice].telefono}, Salario: {empleados[indice].salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

            public static void ListarEmpleadosOrdenados()
            {
                
                ClsEmpleado[] empleadosOrdenados = empleados.OrderBy(e => e.nombre).ToArray();

                Console.WriteLine("Lista de Empleados Ordenados por Nombre:");

                for (int i = 0; i < aux; i++)
                {
                    Console.WriteLine($"{i + 1}. Nombre: {empleadosOrdenados[i].nombre}, Cédula: {empleadosOrdenados[i].cedula}, Direccion: {empleadosOrdenados[i].direccion}, Telefono: {empleadosOrdenados[i].telefono}, Salario: {empleadosOrdenados[i].salario}");
                }
            }

        public static void CalcularPromedioSalarios()
        {
            if (aux > 0)
            {
                double totalSalarios = empleados.Sum(e => e.salario);
                double promedioSalarios = totalSalarios / aux;

                Console.WriteLine($"El promedio de los salarios es: {promedioSalarios}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            }
        }

        public static void MostrarSalarios()
        {
            if (aux > 0)
            {
                double salarioMaximo = empleados.Max(e => e.salario);
                double salarioMinimo = empleados.Min(e => e.salario);

                Console.WriteLine($"Salario más alto: {salarioMaximo}");
                Console.WriteLine($"Salario más bajo: {salarioMinimo}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular los salarios extremos.");
            }
        }


    }

}


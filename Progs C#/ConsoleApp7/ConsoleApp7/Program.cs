using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        //Args es un array de cadenas
        static void Main(string[] args)
        {
            double promedio = 0;
            int aux;
            int cantidadNumeros = 0;
            int[] numeros;
            string ppp="4";

            Console.Write("Ingrese la cantidad de numeros a promediar: ");
            cantidadNumeros = int.Parse(Console.ReadLine());
            

            if (cantidadNumeros > 0)
            {
                numeros = new int[cantidadNumeros];
                for (int i = 0; i < cantidadNumeros; i++)
                {
                    Console.Write($"Ingrese el numero {i + 1}: ");
                    //aux = int.Parse( Console.ReadLine());

                    //if ( ppp. )
                    numeros[ i] = int.Parse( Console.ReadLine());
                    promedio += numeros[i];
                }
                promedio = promedio / cantidadNumeros;
                
                Console.WriteLine("                    ------------");
                Console.WriteLine($"El promedio es      = { Math.Round(promedio,2)}" );
                //Console.WriteLine($"El promedio es      = { promedio}");
            }



            Console.WriteLine("\n\n\n\nPresione ENTER para salir.");
            Console.ReadLine();
        }
    }
}


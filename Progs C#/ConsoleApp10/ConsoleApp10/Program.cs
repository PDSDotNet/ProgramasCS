//---------------------------------------------------------------------
// ConsoleApp10.cs                                  Diplomatura dotNet
//
// Programa que calcula el cuadrado de un numero y lo muestra por la
// consola. Si el numero es cero se da aviso por consola.
//
// 2018-07-05                                  Ing Pablo Daniel Scuteri
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            double cuadrado = 0, aux;

            if ((args.Length == 0) || (args[0] == "-h") || (args[0] == "-H") ||
                (args[0] == "-help") || (args[0] == "-Help") || (args[0] == "-HELP"))
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ejecute ConsoleApp10 seguido del numero a calcular el cuadrado");
                Console.WriteLine("\n Ej: ConsolaApp10 3.6 ");
                Console.WriteLine("----------------------------------------------------------------");

            }
            else
            {
                //Si la cantidad de argumentos es mayor que 0,
                //se intenta calcular el cuadrado.
                   
                //detecta si se utilizo '.' como indicador decimal y lo reemplaza por ','
                //por ser el indicador de punto decimal en español
                if (args[ 0].Contains("."))
                    args[ 0] = args[ 0].Replace(".", ",");

                if (double.TryParse(args[ 0], out aux))
                {
                    if (aux != 0)
                    {
                        cuadrado = Math.Pow(aux, 2);
                        Console.WriteLine($"El cuadrado de {aux} es { Math.Round(cuadrado, 2)}\n\n");
                    }
                    else
                        Console.WriteLine("OJO: Se introdujo cero\n\n");
                }
                else
                    Console.WriteLine("\n\n-----ERROR: No introdujo un numero.-------\n\n");
            }

            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadLine();
        }
    }
}

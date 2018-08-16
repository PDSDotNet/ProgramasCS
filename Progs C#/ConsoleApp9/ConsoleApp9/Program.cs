//---------------------------------------------------------------------
// ConsoleApp9.cs                                    Diplomatura dotNet
//
// Programa que realiza el promedio de una serie de numeros arbirarios
// introducidos por la linea de comando.
//
// 2018-07-04                                  Ing Pablo Daniel Scuteri
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            double promedio = 0, aux;

            if((args.Length == 0) || (args[ 0] == "-h") || (args[0] == "-H") || 
                (args[0] == "-help") || (args[0] == "-Help") || (args[0] == "-HELP"))    
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ejecute ConsoleApp9 seguido de los numeros que quiera promediar");
                Console.WriteLine("\n Ej: ConsolaApp9 3.6 5.2 -9.3");
                Console.WriteLine("----------------------------------------------------------------");
                
            }
            else
            {
                if(args.Length > 1 )
                {
                    //Si la cantidad de argumentos es mayor que 1,
                    //se intenta hacer el promedio.
                    int i = 0;
                    while (i < args.Length)
                    {
                        //detecta si se utilizo '.' como indicador decimal y lo reemplaza por ','
                        //por ser el indicador de punto decimal en español
                        if (args[ i].Contains("."))
                            args[i] = args[i].Replace(".", ",");
                        
                        if (double.TryParse(args[i], out aux))
                        {
                            promedio += aux;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("\n\n-----ERROR: Alguno de los numeros introducidos no es Real.-------\n\n");
                            break;
                        }
                    }
                    
                    if (i >= args.Length)
                    {
                        //Calcula el promedio y lo muestra
                        promedio /= (args.Length);
                        Console.WriteLine($"El promedio es = { Math.Round(promedio, 2)}\n\n");
                    }
                }
                else
                    Console.WriteLine("\n\n-----ERROR: Introdujo un numero o menos.-------\n\n");
            }

            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadLine();
        }
    }
}

//---------------------------------------------------------------------
// ConsoleApp8.cs                                    Diplomatura dotNet
//
// Programa que realiza el promedio de una serie de numeros arbirarios
// introducidos por el usuario.
//
// 2018-07-04                                  Ing Pablo Daniel Scuteri
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidadNumeros = 0;
            double[] vectorNumeros;
            double promedio = 0;
            string aux;
            /*if((args.Length == 0) || (args[ 0] == "-h") || (args[0] == "-H"))    // agregar esta condicion cuando se utiliza la linea de comando
            {
                Console.WriteLine("Ejecute ConsoleApp8 y luego introdusca la cantidad de numeros que quiera ");
                Console.WriteLine("promediar, luego introduzca esa cantidad de numeros a medida que el ");
                Console.WriteLine("programa lo solicita. Al finalizar se muestra el promedio.");
            }*/

            //Obtiene la cantidad de numeros a introducir
            Console.Write( "Candidad de numeros: ");
            if( int.TryParse(Console.ReadLine(), out cantidadNumeros))
            {
                if (cantidadNumeros > 1)
                {
                    //crea el vector de numeros para promediar
                    vectorNumeros = new double[cantidadNumeros];

                    int i = 0;
                    while( i < cantidadNumeros)
                    {
                        Console.Write($"Introduzca el {i + 1}º= ");
                        aux = Console.ReadLine();
                        //detecta si se utilizo '.' como indicador decimal y lo reemplaza por ','
                        //por ser el indicador de punto decimal en español
                        if (aux.Contains("."))
                            aux = aux.Replace(".", ",");

                        if (double.TryParse(aux, out vectorNumeros[i]))
                        {
                            promedio += vectorNumeros[i];
                            i++;
                        }
                        else
                            Console.WriteLine("\n\n-----ERROR: Introduzca un numero real.-------\n\n");
                        continue;
                    }
                    //Calcula el promedio y lo muestra
                    promedio /= cantidadNumeros;
                    Console.WriteLine("                ----------");
                    Console.WriteLine($"El promedio es  = { Math.Round( promedio, 2)}\n\n");
                }
                else
                    Console.WriteLine("\n\n-----ERROR: Introdujo un numero menor que uno.-------\n\n");
            }
            else
                Console.WriteLine("\n\n-----ERROR: No introduzco un numero.-------\n\n");




            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadLine();
        }
    }
}

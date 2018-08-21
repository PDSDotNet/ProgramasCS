//---------------------------------------------------------------------
// ConsoleApp13.cs                                  Diplomatura dotNet
//
// Programa que cuenta la cantidad de vocales de una frace ingresada 
// por linea de comando.
//
// 2018-07-05                                  Ing Pablo Daniel Scuteri
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            

            if ((args.Length == 0) || (args[0] == "-h") || (args[0] == "-H") ||
                (args[0] == "-help") || (args[0] == "-Help") || (args[0] == "-HELP"))
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ejecute ConsoleApp13 seguido de una cadena a la que se le cuentam los caracteres");
                Console.WriteLine("\n Ej: ConsolaApp13 El virrey robo una cabra.");
                Console.WriteLine("----------------------------------------------------------------");
            }
            else
            {
                int cantVocales = 0;

                for(int i = 0; i < args.Length; i++)
                {
                    for( int j = 0; j < args[i].Length; j++)
                    {
                        if( (args[i][j] == 'a') || (args[i][j] == 'A') ||
                            (args[i][j] == 'e') || (args[i][j] == 'E') ||
                            (args[i][j] == 'i') || (args[i][j] == 'I') ||
                            (args[i][j] == 'o') || (args[i][j] == 'O') ||
                            (args[i][j] == 'u') || (args[i][j] == 'U')) 
                            cantVocales++;
                    }
                }
                Console.WriteLine($"La cantidad de palabras es: {args.Length}");
                Console.WriteLine($"La cantidad de vocales es: {cantVocales}");
            }


            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadLine();
        }
    }
}

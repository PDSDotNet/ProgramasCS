//---------------------------------------------------------------------
// ConsoleApp11.cs                                  Diplomatura dotNet
//
// Programa que calcula la potencia de un numero y lo muestra por la
// consola. Si el numero es cero se da aviso por consola.
//
// 2018-07-05                                  Ing Pablo Daniel Scuteri
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{


    class Program
    {
        //Calcula la cantidad de ceros a mostrar para un número real mayor que -1 
        //y menor que 1, manteniendo n decimales útiles 
        static int CantidadDeDecimalesUtiles(double num, int decimalesUtiles = 2)
        {
            int cantDeCeros = 0;
            if (num < 1)
            {
                if (num >= 0)
                    cantDeCeros = Convert.ToInt32(Math.Log10(1 / num));
                else
                    if (num > -1)
                    cantDeCeros = Convert.ToInt32(Math.Log10(-1 / num));
            }

            return cantDeCeros + decimalesUtiles;
        }


        static void Main(string[] args)
        {
            double cuadrado = 0, num, pot;

            if ((args.Length == 0) || (args[0] == "-h") || (args[0] == "-H") ||
                (args[0] == "-help") || (args[0] == "-Help") || (args[0] == "-HELP"))
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ejecute ConsoleApp11 seguido del numero y la potencia");
                Console.WriteLine("\n Ej: ConsolaApp10 3.6 2.3 ");
                Console.WriteLine("----------------------------------------------------------------");
                //-1.9 ^ -3 = -0.145
                //-1.9 ^ -2 = -0.277
                //-1.9 ^ 2 = 3.61
                //-1.9 ^ 3 = -6.86
                //-0.9 ^ 3 = -0.00073
                //0.09 ^ -3.2 = 2220.36
            }
            else
            {
                //Si la cantidad de argumentos es mayor que 2,
                //se intenta calcular el cuadrado.
                if( args.Length > 1)
                {
                    //detecta si se utilizo '.' como indicador decimal y lo reemplaza por ','
                    //por ser el indicador de punto decimal en español
                    if (args[0].Contains("."))
                        args[0] = args[0].Replace(".", ",");
                    if (args[1].Contains("."))
                        args[1] = args[1].Replace(".", ",");

                    if (double.TryParse(args[0], out num))
                    {
                        if (double.TryParse(args[1], out pot))
                        {
                            if ((num != 0) || (pot != 0))
                            {
                                //calcula la potencia
                                cuadrado = Math.Pow(num, pot);
                                
                                //Calcula la cantidad de ceros a mostrar
                                int aux = CantidadDeDecimalesUtiles(cuadrado);

                                Console.WriteLine($"{num} elevado al {pot} es { Math.Round(cuadrado, aux)}\n\n");
                            }
                            else
                                Console.WriteLine("OJO: Se introdujo cero en numero y potencia\n\n");
                        }
                        else
                            Console.WriteLine("\n\n-----ERROR: No introdujo un numero para la potencia.-------\n\n");
                    }
                    else
                        Console.WriteLine("\n\n-----ERROR: No introdujo un numero.-------\n\n");
                }
                else
                    Console.WriteLine("\n\n-----ERROR: Falta un parametro.-------\n\n");

            }





            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadLine();
        }
    }
}

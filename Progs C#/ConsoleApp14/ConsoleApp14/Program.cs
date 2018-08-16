//---------------------------------------------------------------------
// ConsoleApp14.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri
//
// Programa que cuenta ingresa una matriz bidimensional por linea de 
// comando o por teclado, y luego la muestra por pantalla.
//
// 2018-07-05   Se implemento el ingreso por teclado y se mostro la matriz.
// 2018-07-05   Se implemento la linea de comando.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        //funcion que muestra el help
        static void HelpText()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Ejecute: ConsoleApp14 ENTER: el programa pide que se ingrese el");
            Console.WriteLine("         tamaño de la matriz y luego los valores de la misma.\n\n");
            Console.WriteLine("Ejecute: ConsoleApp14 4 2 2 3 6 4  2 5 8 5 ENTER el programa ");
            Console.WriteLine("         ingresara la matriz desde la linea de comando y la");
            Console.WriteLine("         mostrara por pantalla.");
            Console.WriteLine("         NOTA1: El primer dato es la dimension X del array");
            Console.WriteLine("         NOTA2: El segundo dato es la dimension Y del array");
            Console.WriteLine("         NOTA3: entre los numeros hay un espacio.");
            Console.WriteLine("Ejecute: ConsoleApp14 -h ENTER esta auda");
            Console.WriteLine("----------------------------------------------------------------");
        }

        //funcion que muestra la matriz por pantalla
        static void MostrarMatriz( int x, int y, int[,] mat)
        {
            string aux;
            Console.Write($"\n\nmatriz[ {x}, {y}] = ");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    aux = string.Format("{0,5:D}", mat[i, j]);
                    if (j == 0)
                        if( y == 1)
                            Console.Write($"| {aux}| ");
                        else
                            Console.Write($"| {aux}, ");
                    else if (j == (y - 1))
                        Console.Write($" {aux} |");
                    else
                        Console.Write($" {aux}, ");
                }
                Console.Write("\n                ");
            }
        }




        static void Main(string[] args)
        {
            int dimX=0, dimY=0, aux=0;
            int[,] matriz;

            if (args.Length != 0)
            {
                //Si se ingreso algo por la linea de comando
                if((args[0] != "-h") || (args[0] != "-H") || (args[0] != "-help") ||
                (args[0] != "?") || (args[0] != "-?") || (args[0] != "-Help") || (args[0] != "-HELP"))
                {
                    //se se ingreso informacion
                    if (int.TryParse(args[0], out dimX))
                    {
                        if (int.TryParse(args[1], out dimY))
                        {
                            matriz = new int[dimX, dimY];

                            for (int i = 0; i < dimX; i++)
                            {
                                for (int j = 0; j < dimY; j++)
                                {
                                    if (int.TryParse(args[i * dimY + j + 2], out aux))
                                        matriz[i, j] = aux;
                                    else
                                    {
                                        Console.WriteLine($"ERROR: el dato Nro {i * dimY + j + 2} no es un numero.\nEjecute: ConsoleApp14 -h");
                                        break;
                                    }
                                }
                            }

                            //mostrar la matriz en forma de matriz
                            MostrarMatriz(dimX, dimY, matriz);

                        }else Console.WriteLine("ERROR: el segundo dato no es un numero.\nEjecute: ConsoleApp14 -h");
                    }else Console.WriteLine("ERROR: el primer dato no es un numero.\nEjecute: ConsoleApp14 -h");
                }else HelpText();    //se se ingreso un pedido de ayuda
            }
            else
            {
                //si no se ingreso nada por la linea de comando
                Console.Write("Ingrese la cantidad de elementos de la primer dimension: ");
                if (int.TryParse(Console.ReadLine(), out dimX))
                {
                    if( dimX > 0)
                    {
                        Console.Write("Ingrese la cantidad de elementos de la segunda dimension: ");
                        if (int.TryParse(Console.ReadLine(), out dimY))
                        {
                            if( dimY > 0)
                            {
                                matriz = new int[dimX, dimY];

                                for (int i = 0; i < dimX; i++)
                                {
                                    for (int j = 0; j < dimY; j++)
                                    {
                                        Console.Write($"Ingrese matris[ {i}, {j}] = ");
                                        if (int.TryParse(Console.ReadLine(), out aux))
                                            matriz[i, j] = aux;
                                        else
                                        {
                                            Console.Write("No ingreso un numero");
                                            break;
                                        }
                                    }
                                }

                                //mostrar la matriz en forma de matriz
                                MostrarMatriz(dimX, dimY, matriz);

                            }else    Console.Write("ERROR: Introdujo cero o negativo para la segunda dimension.");
                        }else    Console.Write("ERROR: No introdujo un numero para la segunda dimension.");
                    }else    Console.Write("ERROR: Introdujo cero o negativo para la primer dimension.");
                }else    Console.Write("ERROR: No introdujo un numero para la primer dimension.");
            }




            //mostrar la matriz en forma de matriz
            //MostrarMatriz(dimX, dimY, matriz);

            

            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadKey();
        }
    }
}

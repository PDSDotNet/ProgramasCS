//---------------------------------------------------------------------
// ConsoleApp15.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri
//
// Programa ordena un vector ingresado por por linea de 
// comando o por teclado, y luego muestra por pantalla ambos vectores.
//
// 2018-07-05   Se implemento el ingreso por teclado y se mostro la matriz.ConsoleApp14
// 2018-07-05   Se implemento la linea de comando.ConsoleApp14
// 2018-07-05   
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        //funcion que muestra el help
        static void HelpText()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Ejecute: ConsoleApp15 ENTER: el programa pide que se ingrese el");
            Console.WriteLine("         tamaño del vector y luego los valores de la misma.\n\n");
            Console.WriteLine("Ejecute: ConsoleApp15 4 2 2 3 6 4  2 5 8 5 ENTER el programa ");
            Console.WriteLine("         ingresara el vector desde la linea de comando y la");
            Console.WriteLine("         mostrara por pantalla.");
            Console.WriteLine("         NOTA1: entre los numeros hay un espacio.");
            Console.WriteLine("Ejecute: ConsoleApp15 -h ENTER esta auda");
            Console.WriteLine("----------------------------------------------------------------");
        }

        //funcion que muestra la matriz por pantalla
        static void MostrarMatriz(int[,] mat)
        {
            //obtiene las dimensiones de la matris a mostrar
            int x = mat.GetLength(0);
            int y = mat.GetLength(1);

            string aux, aux1;
            aux = string.Format("{0,3:D}", x);
            aux1 = string.Format("{0,3:D}", y);
            Console.Write($"\n\nmatriz[ {aux}, {aux1}] = ");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    aux = string.Format("{0,3:D}", mat[i, j]);
                    if (j == 0)
                        if (y == 1)
                            Console.Write($"| {aux}| ");
                        else
                            Console.Write($"| {aux}, ");
                    else if (j == (y - 1))
                        Console.Write($" {aux} |");
                    else
                        Console.Write($" {aux}, ");
                }
                Console.Write("\n                    ");
            }
        }

        //funcion que ordena un vector 
        //retorna true en si todo funciono ok, si falló retorna false
        static void OrdenarVector(int[] vector)
        {
            int aux = 0;
            int tam = vector.Length;
            for( int indExt = 0; indExt < tam -1; indExt++)
                for( int indInt = indExt + 1; indInt < tam; indInt++)
                    if(vector[ indExt] > vector[indInt])
                    {
                        aux = vector[indInt];
                        vector[indInt] = vector[indExt];
                        vector[indExt] = aux;
                    }
         }



        static void Main(string[] args)
        {
            int dimX = 0, aux = 0;
            int[,] matriz;
            int[] matrizIn;

            if (args.Length != 0)
            {
                //Si se ingreso algo por la linea de comando
                if ((args[0] != "-h") || (args[0] != "-H") || (args[0] != "-help") ||
                (args[0] != "?") || (args[0] != "-?") || (args[0] != "-Help") || (args[0] != "-HELP"))
                {
                    //se se ingreso informacion
                    if( args.Length > 0)
                    {
                        matrizIn = new int[ args.Length];

                        for (int i = 0; i < args.Length; i++)
                        {
                            if (int.TryParse(args[ i], out aux))
                                matrizIn[ i] = aux;
                            else
                            {
                                Console.WriteLine($"ERROR: el dato Nro {i} no es un numero.\nEjecute: ConsoleApp14 -h");
                                break;
                             }
                        }
                        //Copia el vector para poder mostrar el vector original y el ordenado
                        matriz = new int[matrizIn.Length, 2];
                        for (int i = 0; i < matrizIn.Length; i++)
                        {
                            matriz[i, 0] = matrizIn[i];
                            matriz[i, 1] = matrizIn[i];
                        }

                        //Ordena la matriz 
                        OrdenarVector(matrizIn);

                        //Copia el vector ordenado
                        for (int i = 0; i < matrizIn.Length; i++)
                        {
                            matriz[i, 1] = matrizIn[i];
                        }

                        //mostrar la matriz en forma de matriz
                        MostrarMatriz( matriz);

                        }else Console.WriteLine("ERROR: el segundo dato no es un numero.\nEjecute: ConsoleApp14 -h");
                }else HelpText();    //se se ingreso un pedido de ayuda
            }
            else
            {
                //si no se ingreso nada por la linea de comando
                Console.Write("Ingrese la cantidad de elementos del vector: ");
                if (int.TryParse(Console.ReadLine(), out dimX))
                {
                    if (dimX > 0)
                    {
                        matriz = new int[dimX, 1];

                        for (int i = 0; i < dimX; i++)
                        {
                            Console.Write($"Ingrese vector[ {i}] = ");
                            if (int.TryParse(Console.ReadLine(), out aux))
                                    matriz[i, 0] = aux;
                                else
                                {   
                                    Console.Write("No ingreso un numero");
                                    break;
                                }
                        }

                        //Copia el vector para poder mostrar el vector orijinal y el ordenado
                        int[,] auxMat = matriz;
                        matriz = new int[dimX, 2];
                        for (int i = 0; i < dimX; i++)
                        {
                            matriz[i, 0] = auxMat[i, 0];
                            matriz[i, 1] = auxMat[i, 0];
                        }
                        

                        //mostrar la matriz en forma de matriz
                        MostrarMatriz( matriz);

                            
                    }else Console.Write("ERROR: Introdujo cero o negativo para la primer dimension.");
                }else Console.Write("ERROR: No introdujo un numero para la primer dimension.");
            }




            //mostrar la matriz en forma de matriz
            //MostrarMatriz(dimX, dimY, matriz);



            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
            Console.ReadKey();
        }
    }
}

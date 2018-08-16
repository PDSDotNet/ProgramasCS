//Examen Diplomatura dotNet
//2018-07-31
//Pablo Daniel Scuteri
//ejercicio 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
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

        //funcion que carga los datos en la matriz
        static void CargarDatos(int[,] mat)
        {
            //obtiene las dimensiones de la matris a mostrar
            int x = mat.GetLength(0);
            int y = mat.GetLength(1);
            int aux = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    do
                    {
                        Console.Clear();
                        Console.Write($"Ingrese el valor para la posicion [{i},{j}]: ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out aux));
                    mat[i, j] = aux;
                }
            }
        }

        //funcion que muestra la matriz por pantalla
        static void Buscar(int[,] mat, out int posN, out int posM)
        {
            //obtiene las dimensiones de la matris a mostrar
            int x = mat.GetLength(0);
            int y = mat.GetLength(1);
            int aux = 0;
            posN = 0;
            posM = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (aux < mat[i,j])
                    {
                        aux = mat[i, j];
                        posN = i;
                        posM = j;
                    }
                        
                }
            }
        }

        //Lee un entero por teclado
        static bool LeerIntTeclado(string str, out int val)
        {
            int _contador = 0;
            do
            {
                Console.Clear();
                Console.Write($"{_contador}:\t{str}");
                
                if (_contador == 3)
                {
                    val = 0;
                    return false;
                }
                _contador++;
            }
            while (!int.TryParse(Console.ReadLine(), out val));
            return true;
        }

        static void Main(string[] args)
        {
            int N = 0;
            int M = 0;
            int posN = 0;
            int posM = 0;

            //Ingreso del tamaño de la matriz por teclado
            if (LeerIntTeclado("Ingrese la dimension N de la matriz: ", out N) && LeerIntTeclado("Ingrese la dimension M de la matriz: ", out M))
            {
                //Creacion de la matriz
                int[,] Matriz = new int[N, M];

                //ingreso de la matriz por teclado
                CargarDatos(Matriz);

                //Muestra la matriz
                MostrarMatriz(Matriz);

                //busca el mayor
                Buscar(Matriz, out posN, out posM);

                Console.WriteLine($"\nEl valor mas grande es: {Matriz[posN, posM]} y la primer aparicion es [{posN},{posM}]");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Se cometio un error en el ingreso de N o M");
            }

            

            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}

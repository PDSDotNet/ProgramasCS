using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmbito
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

        static void Main(string[] args)
        {

            //int[,] array = { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } };
            int[,] array;

            //array = new int[,] { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } };
            //MostrarMatriz( array);
            
            if (Console.ReadKey().KeyChar == '1')
            {
                array = new int[2, 3];
                array[0, 0] = 51;
                array[0, 1] = 52;
                array[0, 2] = 53;
                array[1, 0] = 54;
                array[1, 1] = 55;
                array[1, 2] = 56;

                MostrarMatriz(array);
            }
            else
            {
                //array = new int[2, 3];
                //array[0, 0] = 551;
                //array[0, 1] = 552;
                //array[0, 2] = 553;
                //array[1, 0] = 554;
                //array[1, 1] = 555;
                //array[1, 2] = 556;

                //MostrarMatriz(array);
                return;
            }

            MostrarMatriz(array);
            Console.ReadLine();

        }
    }
}

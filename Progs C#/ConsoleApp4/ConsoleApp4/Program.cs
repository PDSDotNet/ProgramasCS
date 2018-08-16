using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ConsoleApp4
{
    class Program
    {
        //static void Swap(int a, int b) esto no funciona porque los metodos por default
        //                               pasan los valores por copia. 
        static void Swap( ref int a, ref int b)  //lo que hay que hacer es pasar por referencia
        {
            int aux = a;
            a = b;
            b = aux;

        }

        static void Suma( int a, int b, out int resultado)  
        {
            resultado = a + b;
            
        }

        static void Main(string[] args)
        {
            int miA = 10;
            int miB = 22;
            int miRes;

            Console.WriteLine($"\nA: {miA}, B: {miB}.");
            //Swap(miA, miB);
            Swap( ref miA, ref miB);
            Console.WriteLine($"\nA: {miA}, B: {miB}.");

            Suma(miA, miB, out miRes);
            Console.WriteLine($"\nA + B: {miRes}.");

            Console.WriteLine("\n\n\n\nPresione ENTER para salir.");
            Console.ReadLine();
        }
    }
}

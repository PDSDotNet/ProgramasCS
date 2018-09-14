using System;

namespace Problema1
{
    class Program
    {
        static string Fun<T>( T[] arr, int pos)
        {
            //arr[ pos].GetType();
            
            return $"el valor es: {arr[ pos]} y el tipo es: {arr[ pos].GetType()}";
        }
        


        static void Main(string[] args)
        {
            int[] ArregloInt = {10, 25, 66, 77, 2, 36};
            double[] ArregloDouble = {10.3, 25.5, 66.8, 77.99, 2.25236, 36.1};
            string[] ArregloString = {"Lola", "lalo", "Coca", "Foca", "Fito", "Tucho"};
            
            Console.WriteLine(Fun<int>( ArregloInt, 3));
            //Console.WriteLine(Fun<int>( ArregloDouble, 3)); //no se puede convertir doble to int
            Console.WriteLine(Fun<double>( ArregloDouble, 3));
            Console.WriteLine(Fun<string>( ArregloString, 3));

            Console.WriteLine($"\n\n\n\nPresione cualquier tecla para finalizar.");
            Console.Read();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write( args);
            Int32 myNumero = 666;
            //Console.WriteLine($"{args}" );
            Console.WriteLine("\nHola mundo cruel, MiNumero: " + myNumero);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHola mundo cruel, MiNumero: {0}", myNumero);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nHola mundo cruel, MiNumero: {myNumero}");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHola mundo cruel, MiNumero: {myNumero}");

            Console.ResetColor();

            Console.WriteLine("\n\n\n\nPresione ENTER para terminar");
            Console.ReadKey();
        }
    }
}

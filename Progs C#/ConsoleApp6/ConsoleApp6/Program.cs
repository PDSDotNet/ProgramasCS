using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        //Args es un array de cadenas
        static void Main(string[] args)
        {
            if( args.Length == 0)
                Console.WriteLine("Comando sin argumento.\n\n\n\n");
            else
                for( int i = 0; i <args.Length; i++)
                {
                    Console.WriteLine(args[i]);
                }
                    

            Console.WriteLine("\n\n\n\nPresione ENTER para salir.");
            Console.ReadLine();
        }
    }
}

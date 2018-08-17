using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRound
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = { 2.125, 2.135, 2.145, 3.125, 3.135, 3.145 };
            foreach (double value in values)
                Console.WriteLine("{0} --> {1}", value,
                                  Math.Round(value, 2, MidpointRounding.AwayFromZero));

            
            Console.WriteLine("\n\n");
            int ii = 3;
            double dd = 3.1;
            Console.WriteLine($"{dd} elevado a la {ii} es {Math.Pow(dd,ii)}");
            Console.WriteLine($"{dd} elevado a la {ii} es {Math.Sqrt(dd)}");

            //Finalizacion del programa
            Console.WriteLine("\a\n\n\n\nPrecione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}

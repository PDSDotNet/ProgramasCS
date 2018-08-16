using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int miEntero = 1263;
            short miShort = -65;
            bool miBoolean = false;
            long miLong = 63598587;

            Console.WriteLine($"Mi entero es: {miEntero}\n" +
                              $"Mi short es: {miShort}\n" +
                              $"Mi booleano es: {miBoolean}\n" +
                              $"Mi long es: {miLong}\n");
            Console.ReadLine();
        }
    }
}


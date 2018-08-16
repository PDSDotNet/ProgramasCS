using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCadena
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad1 = "La Coca Sarli";
            string cad2 = string.Copy(cad1);
            string cad3 = cad1;
            string cad4 = "La Coca Sarli";

            Console.WriteLine(cad1 == cad2);

            Console.WriteLine(object.ReferenceEquals(cad1, cad2));
            Console.WriteLine((object)cad1 == (object)cad2);

            Console.WriteLine(object.ReferenceEquals(cad1, cad3));
            Console.WriteLine((object)cad1 == (object)cad3);

            Console.WriteLine(object.ReferenceEquals(cad1, cad4));
            Console.WriteLine((object)cad1 == (object)cad4);

            Console.ReadKey();
        }
    }
}

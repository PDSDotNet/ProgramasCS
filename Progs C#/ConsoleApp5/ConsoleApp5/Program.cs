using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A;
using B;
//alias para reslver el conflicto de alias
using ClaseA = A.Clase;


namespace A
{
    class Clase
    { }
}

namespace B
{
    class Clase
    { }
}



namespace ConsoleApp5
{
    class Program
    {


        static void Main(string[] args)
        {
            //Clase miClase = new Clase();    //error por suplicacion en la declaracion de la clase
            ClaseA miClase1 = new ClaseA();

            Console.WriteLine("\n\n\n\nPresione ENTER para salir.");
            Console.ReadLine();
        }
    }
}

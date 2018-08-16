//Examen Diplomatura dotNet
//2018-07-31
//Pablo Daniel Scuteri
//ejercicio 3



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigurasGeometricas;

namespace ConsoleApp25
{


    class Program
    {
        static void Main(string[] args)
        {
            List< Figura> Formas = new List<Figura>();

            Triangulo Tr1 = new Triangulo(2,5, 6, 9);
            TrianguloEquilatero Tr2 = new TrianguloEquilatero(6);
            Rectangulo R1 = new Rectangulo(6, 9);
            Cuadrado C1 = new Cuadrado(11);

            Formas.Add(Tr1);
            Formas.Add(Tr2);
            Formas.Add(R1);
            Formas.Add(C1);


            foreach (Figura fig in Formas)
            {
                Console.WriteLine(fig.ToString());
            }

            Console.WriteLine("\n\n\n\nPrecione cualquier tecla finalizar.");
            Console.ReadKey();

        }
    }
}

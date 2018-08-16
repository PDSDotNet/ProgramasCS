//----------------------------------------------------------------------------------
// ConsoleApp21.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri                                 2018-07-20
//
// Ejercicios de clases y objetos 
// Plantear un modelo de Figuras que permita representar rectangulos y triangulos.
// Implementar el calculo del area.
// Implementar el calculo del perimetro.
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigurasGeometricas;

namespace ConsoleApp21
{
    class Program
    {

        static void Main(string[] args)
        {
            /*//Test de triangulos
            TrianguloEquilatero tr1 = new TrianguloEquilatero(20);
            Triangulo tr2 = new Triangulo(100, 70, 50);
            Triangulo tr3 = new Triangulo(20, 15, 38);
            TrianguloIsosceles tr4 = new TrianguloIsosceles(20, 85);

            Console.WriteLine(tr1.ToString());
            Console.WriteLine(tr2.ToString());
            Console.WriteLine(tr3.ToString());
            Console.WriteLine(tr4.ToString());
            */

            /*
            //Test de circulos
            Circulo C1 = new Circulo(new Punto(12.509, 6.535), 7);
            Circulo C2 = new Circulo(new Punto(0, 0), 8);
            
            Punto P1 = new Punto(0, 0);
            Punto P2 = new Punto(0, 0);

            C1.Interseccion(C2, out P1, out P2);
            Console.WriteLine(C1.ToString());
            Console.WriteLine(C2.ToString());
            Console.WriteLine($"Los puntos de interseccion entre C1 y C2 son:\n\t\t{P1}\n\t\t{P2}");
            */

            //Test de Cuadrilateros
            Cuadrilatero Cua1 = new Cuadrilatero(10, 7, 7, 8, 111);
            Cuadrilatero Cua2 = new Cuadrilatero(10, 7, 7, 8, 111, false);
            Caudrado Cua3 = new Caudrado( 11);
            Rectangulo Cua4 = new Rectangulo(13, 7);

            Console.WriteLine(Cua1.ToString());
            Console.WriteLine(Cua2.ToString());
            Console.WriteLine(Cua3.ToString());
            Console.WriteLine(Cua4.ToString());

            Console.WriteLine($"\n\n\n\nPresione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}

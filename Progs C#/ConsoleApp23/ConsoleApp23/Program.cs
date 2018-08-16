//Examen Diplomatura dotNet
//2018-07-31
//Pablo Daniel Scuteri
//ejercicio 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string _numCad;
            double Cotizacion = 0;
            double MontoUSA = 0;
            double MontoAR = 0;
            do
            {
                Console.Clear();
                Console.Write("Ingrese la cotizacion del dolar: ");
                _numCad = Console.ReadLine();
                if (_numCad.Contains("."))
                    _numCad = _numCad.Replace(".", ",");

            }
            while (!double.TryParse(_numCad, out Cotizacion));

            do
            {
                Console.Clear();
                Console.Write("Ingrese la cantidad de dolares a comprar: ");
                _numCad = Console.ReadLine();
                if (_numCad.Contains("."))
                    _numCad = _numCad.Replace(".", ",");
            }
            while (!double.TryParse(_numCad, out MontoUSA));

            MontoAR = (Cotizacion * MontoUSA) *1.05;
            Console.Clear();
            Console.Write($"La cantidad de pesos son: ${MontoAR}");



            Console.WriteLine("\n\n\n\nPrecione cualquier tecla finalizar.");
            Console.ReadKey();

        }
    }
}

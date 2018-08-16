//---------------------------------------------------------------------
// ConsoleApp19.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri
//
// Ejercicio de Clases y Objetos 1
//        Plantear una clase llamada Alumno y definir como campos su nombre y su edad.En el
//   constructor realizar la carga de datos.Definir otros dos métodos para imprimir los datos
//   ingresados y un mensaje si es mayor o no de edad (edad >=18).
//        Hacer un programa que al ejecutarse solicite los datos para tres alumnos, los cree e
//   imprima los datos de cada uno y si es mayor o no de edad.
//---------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> alumnado = new List<Alumno>();

            /*for ( int i = 0; i > 3; i++)
            {
                Console.Clear();
                Console.Write($"Ingrese el nombre del {i}º alumno: ");
                string nom = Console.Read();

            }*/
            alumnado.Add( new Alumno("Juan", "DeLosPalotes", 16));
            alumnado.Add(new Alumno("Amalita", "Fortava", 13));
            alumnado.Add(new Alumno("Juanita", "Otrola", 25));

            foreach(Alumno allu in alumnado)
            {
                string aux;
                if (allu.EsMayor())
                    aux = "mayor";
                else
                    aux = "menor";
                Console.WriteLine($"El Alumno {allu.ToString()} es {aux}");
            }
            

            Console.WriteLine($"\n\n\n\nPresione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
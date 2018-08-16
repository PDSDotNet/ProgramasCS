//----------------------------------------------------------------------------------
// ConsoleApp22.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri                                 2018-07-30
//
// Ejercicios de clases y objetos 
// Plantear un modelo que permita representar a los telefonos de linea, los 
// celulares y los voip(ejemplo: Skype phone).
// Implementar las siguientes capacidades de los teléfonos:
//      Llamar
//      Cortar
//      Sacar foto
//      Enviar mensaje de texto.
//      Hacer videollamada.
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfonos;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Movil M1 = new Movil();
            Telefono T1 = new Telefono();
            VoIP V1 = new VoIP();

            Console.WriteLine($"\n\nTelefono movil");
            M1.Cortar();
            M1.Llamar();
            M1.Llamar();
            M1.Cortar();
            Console.WriteLine($"\n\nTelefono de linea");
            T1.Cortar();
            T1.Llamar();
            T1.Llamar();
            T1.Cortar();
            Console.WriteLine($"\n\nTelefono IP");
            V1.Cortar();
            V1.Llamar();
            V1.Llamar();
            V1.Cortar();

            Console.WriteLine($"\n\n\n\nPresione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}

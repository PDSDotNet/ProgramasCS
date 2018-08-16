//---------------------------------------------------------------------
// ConsoleApp19.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri
//
// Ejercicio de Clases y Objetos 1
//   Plantear una clase llamada Alumno y definir como campos su nombre y su edad.
//   En el constructor realizar la carga de datos.
//   Definir otros dos métodos para imprimir los datos ingresados y un mensaje si es mayor o no de edad (edad >=18).
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Alumno
    {
        //propiedades
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        //constructores
        public Alumno(string nom, string app, int edad)
        {
            //este contructor es protected para que solo lo puedan llamar
            //solo las clases hijas
            Nombre = nom;
            Apellido = app;
            Edad = edad;
        }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre} edad: {Edad}";
        }

        public bool EsMayor()
        {
            return this.Edad > 18;
        }

    }
}



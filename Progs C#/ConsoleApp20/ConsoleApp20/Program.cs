//---------------------------------------------------------------------
// ConsoleApp18.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri
//
// Programa de clases, ejemplo del dia 17-7-2018
// Agregado de manejo de errores
//---------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        public abstract class Empleado
        {
            //constructores
            protected Empleado(string nom, string app, int dni)
            {
                //este contructor es protected para que solo lo puedan llamar
                //solo las clases hijas
                if (nom == null || nom == "")
                    throw new System.ArgumentException($"El nombre {nom} no es valido");
                if (app == null || app == "")
                    throw new System.ArgumentException($"El apelleido {app} no es valido");
                if (dni < 0 || dni > 200000000)
                    throw new System.ArgumentException($"El DNI {dni} no es valido");

                Nombre = nom;
                Apellido = app;
                DNI = dni;
            }

            //propiedades
            public int DNI { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }


            //Metodos sobreescritos (override)
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                return this.DNI == (obj as Empleado).DNI;
                //return this.DNI == (obj as Empleado).DNI;
                //return (obj is Empleado) && (GetType() != obj.GetType()) && (this.DNI == (obj as Empleado).DNI);
            }
            public override int GetHashCode()
            {
                return this.DNI;
            }
            public override string ToString()
            {
                return $"{Apellido}, {Nombre} y su DNI es: {DNI}";
            }


            //metodos abstractos 
            //(los hijos de Empleado los tienen que implementar
            //estos metodos para poder crear un objeto heredero.
            public abstract double Sueldo();
        }

        public class FullTime : Empleado
        {
            public FullTime(string nom, string app, int dni, double sueldo)
                : base(nom, app, dni)
            {
                SueldoMensual = sueldo;
            }
            private double SueldoMensual;

            public override double Sueldo()
            {
                return SueldoMensual;
            }
        }

        public class FreeLancer : Empleado
        {
            public FreeLancer(string nom, string app, int dni, double valorHoras, double horas)
                : base(nom, app, dni)
            {
                ValorHora = valorHoras;
                CantidadHoras = horas;
            }
            private double ValorHora;
            private double CantidadHoras;

            public override double Sueldo()
            {
                return ValorHora * CantidadHoras;
            }
        }




        static void Main(string[] args)
        {
            try
            {
                double gastoTotalSueldo = 0;
                FullTime Empleado1 = new FullTime("Juan", "DeLosPalotes", 23666666, 25000);
                FullTime Empleado2 = new FullTime("Amalita", "Fortava", 3222222, 35000);
                FreeLancer Empleado3 = new FreeLancer("Juanita", "Otrola", 252588258, 250, 50);
                FreeLancer Empleado4 = Empleado3;
                FreeLancer Empleado5 = new FreeLancer("Juanita", "Otrola", 24222222, 250, 50); ;

                List<Empleado> empleadosEmpresa = new List<Empleado>();
                empleadosEmpresa.Add(Empleado1);
                empleadosEmpresa.Add(Empleado2);
                empleadosEmpresa.Add(Empleado3);

                foreach (Empleado emp in empleadosEmpresa)
                {
                    Console.WriteLine($"El sueldo de {emp.ToString()} es: ${emp.Sueldo()}.");
                    gastoTotalSueldo += emp.Sueldo();
                }
                Console.WriteLine($"\n\nEl gasto total en sueldos es: ${gastoTotalSueldo}.");

                Console.WriteLine($"\nCompara Empleado1 con Empleado2 con Equals y luego con Object.ReferenceEquals:");
                Console.WriteLine($"Contenido: {Empleado1.Equals(Empleado2)}. \tPosicion de memoria: {Object.ReferenceEquals(Empleado1, Empleado2)}.");


                Console.WriteLine($"\nCompara Empleado3 con Empleado4 con Equals y luego con Object.ReferenceEquals:");
                Console.WriteLine($"Contenido: {Empleado3.Equals(Empleado4)}. \tPosicion de memoria: {Object.ReferenceEquals(Empleado3, Empleado4)}.");

                Console.WriteLine($"\nCompara Empleado3 con Empleado5 con Equals y luego con Object.ReferenceEquals:");
                Console.WriteLine($"Contenido: {Empleado3.Equals(Empleado5)}. \tPosicion de memoria: {Object.ReferenceEquals(Empleado3, Empleado5)}.");


            }
            catch( Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            finally
            {
                Console.WriteLine($"\n\n\n\nPresione cualquier tecla para finalizar.");
                Console.ReadKey();
            }
        }
    }
}

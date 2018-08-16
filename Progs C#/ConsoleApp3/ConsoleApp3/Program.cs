using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Persona
{
    public string Nombre;
    public string Apellido;
    public long NumeroIdentidad;
    public string Nacionalidad;
    public DateTime FechaNacimiento;
    public DateTime FechaMuerte;

    public void MostrarNombreApellido()
    {
        Console.WriteLine(Nombre + " " + Apellido);
    }
}



namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //instanciacion de las clases
            Persona per1 = new Persona();
            Persona per2 = new Persona();

            per1.Nombre = "Pepe";
            per1.Apellido = "Parada";
            per2.Nombre = "Juan";
            per2.Apellido = "de los Palotes";

            Console.Write("El nombre de per1 es: ");
            per1.MostrarNombreApellido();

            Console.Write($"\nEl nombre de per2 es: ");
            per2.MostrarNombreApellido();

            Console.WriteLine("\n---------------------------");

            Persona per3 = per1;

            Console.Write($"\nEl nombre de per3 es: ");
            per3.MostrarNombreApellido();

            per3.Nombre = "Patricia";
            per3.Apellido = "del Rio";

            Console.Write("\nEl nombre de per1 es: ");
            per1.MostrarNombreApellido();

            Console.WriteLine("\n\n\n\nPresione ENTER para salir.");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaProject
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }




    public class Persona
    {
        public Persona()
        {
            Nombre = "No es un nombre valido";
            DNI = -10000;
        }

        public Persona( string nombre, int dni)
        {
            //if (nombre == "")
            //if (nombre == "" || nombre == null)
            if (string.IsNullOrEmpty(nombre))
            {
                throw new PersonaNombreExeption();
            }
            if(dni == 0)
            {
                throw new PersonaDNIExeption();
            }

            if(Celular.Length !=12 && string.IsNullOrEmpty(Celular))
            {
                throw new PersonaCelularExeption();
            }

            

            this.Nombre = nombre;
            this.DNI = dni;
            this.Celular = celular;
        }

        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Celular { get; set; }
    }


    public class PersonaNombreExeption: Exception
    {
    }

    public class PersonaDNIExeption : Exception
    {
    }

    public class PersonaCelularExeption : Exception
    {
    }
}



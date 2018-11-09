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
            //Nombre = "No es un nombre valido";
            Nombre = null;
            //DNI = -10000;
            DNI = 0;
            Celular = null;
        }

        public Persona( string nombre, int dni, string celular=null)
        {
            //if (nombre == "")
            //if (nombre == "" || nombre == null)
            if (string.IsNullOrEmpty(nombre))
            {
                throw new PersonaNombreExeption();
            }
            if(dni <= 0)
            {
                throw new PersonaDNIExeption();
            }
            this.Nombre = nombre;
            this.DNI = dni;

            //if(celular.Length !=12 && string.IsNullOrEmpty(celular))
            if (celular.Length ==12)
            {
                this.Celular = celular;
                //throw new PersonaCelularExeption();
            }
            else
            {
                throw new PersonaCelularExeption();
            }
            //this.Celular = celular;
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



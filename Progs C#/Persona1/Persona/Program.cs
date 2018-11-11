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
            /*
             * PERSONA
             *  Nombre - obligatorio
             *  Apellido - obligatorio
             *  DNI - obligatorio y numérico
             *  CELULAR - opcional y format NN-NNNN-NNNN
             */
        }
    }




    public class Persona
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
            Nombre = null;
            Apellido = null;
            DNI = 0;
            Celular = null;
        }

        /// <summary>
        /// Constructor especial para realizar los test.
        /// </summary>
        /// <param name="test"></param>
        public Persona(bool test = false)
        {
            if (test)
            {
                Nombre = "No es un nombre valido";
                Apellido = "No es un apellido valido";
                DNI = -10000;
                Celular = "No es un celular valido";
            }
        }


        /// <summary>
        /// Constructor por valor.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="dni"></param>
        /// <param name="celular"></param>
        public Persona( string nombre, string apellido, int dni, string celular = null)
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
            if (string.IsNullOrEmpty(apellido))
            {
                throw new PersonaApellidoExeption();
            }
            this.Nombre = nombre;
            this.DNI = dni;
            this.Apellido = apellido;


            if(!string.IsNullOrEmpty(celular) && celular.Length ==12)
            {
                string[] numTel = celular.Split('-');
                int telCaracteristica =  0;
                int telPrimerNum = 0;
                int telSegundoNum = 0;

                if ( numTel.Count() == 3 && 
                    int.TryParse(numTel[0], out telCaracteristica) && 
                    int.TryParse(numTel[1], out telPrimerNum) && 
                    int.TryParse(numTel[2], out telSegundoNum))
                {
                    this.Celular = celular;
                }
            }
            else
            {
                //throw new PersonaCelularExeption();
            }


        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Celular { get; set; }
    }


    public class PersonaNombreExeption: Exception
    {
    }
    public class PersonaApellidoExeption : Exception
    {
    }

    public class PersonaDNIExeption : Exception
    {
    }

    public class PersonaCelularExeption : Exception
    {
    }
}



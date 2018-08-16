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

namespace Interfonos
{
    public abstract class Interfono
    {
        //constructores
        protected Interfono()
        {
            Hablando = false;
        }
        //propiedades
        //Metodos
        public bool Hablando { get; set; }
        //Metodos sobreescritos (override)
        public abstract bool Llamar();
        public abstract bool Cortar();
    }

    public class Telefono: Interfono
    {
        //constructores
        public Telefono()
        {
            Tono = true;
            Hablando = false;
        }
        //propiedades
        //Metodos
        public bool Tono { get; set; }
        
        //Metodos sobreescritos (override)
        public override bool Llamar()
        {
            if (Tono)
            {
                Console.WriteLine("Tono verificado. Discar numero");
                Tono = false;
                Hablando = true;
                return true;
            }
            else
            {
                Console.WriteLine("No hay Tono. Intentar mas tarde");
                return false;
            }
                
        }

        public override bool Cortar()
        {
            if (Hablando)
            {
                Console.WriteLine("Cortando comunicacion");
                Hablando = false;
                Tono = true;
                return true;
            }
            else
            {
                Console.WriteLine("No hay nadie hablando");
                return false;
            }

        }

    }

    public class Movil : Interfono
    {
        public Movil()
        {
            Señal = true;
            Hablando = false;
        }
        //propiedades
        public bool Señal { get; set; }

        //Metodos
        public void TomatFoto()
        {
            Console.WriteLine("Tomando una foto.");
        }
        public void EnviarMensaja()
        {
            Console.WriteLine("Enviando mensaje de texto");
        }

        //Metodos sobreescritos (override)
        public override bool Llamar()
        {
            if (Señal)
            {
                if( !Hablando)
                {
                    Console.WriteLine("Hay señal. Discar numero");
                    Hablando = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Que raro que no se da cuenta de que ya esta hablando!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No hay señal. Intentar mas tarde");
                return false;
            }

        }

        public override bool Cortar()
        {
            if (Hablando)
            {
                Console.WriteLine("Cortando comunicacion");
                Hablando = false;
                return true;
            }
            else
            {
                Console.WriteLine("No hay nadie hablando");
                return false;
            }

        }
    }

    public class VoIP : Interfono
    {
        public VoIP()
        {
            VoIPready = true;
            Hablando = false;
        }
        //propiedades
        public bool VoIPready { get; set; }

        //Metodos
        public void TomatFoto()
        {
            Console.WriteLine("Tomando una foto.");
        }
        public void EnviarMensaja() => Console.WriteLine("Enviando mensaje de texto");

        //Metodos sobreescritos (override)
        public override bool Llamar()
        {
            if (VoIPready)
            {
                Console.WriteLine("Hay conexion IP.");
                if (!Hablando)
                {
                    Console.WriteLine("Conectando con IP");
                    Hablando = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Que raro que no se da cuenta de que ya esta hablando!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No hay conexion IP. Intentar mas tarde");
                return false;
            }

        }

        public override bool Cortar()
        {
            if (Hablando)
            {
                Console.WriteLine("Cortando comunicacion");
                Hablando = false;
                return true;
            }
            else
            {
                Console.WriteLine("No hay nadie hablando");
                return false;
            }

        }
    }


}

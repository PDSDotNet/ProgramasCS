using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp17
{
    class Policia
    {
        public bool Validar( Coche coche)
        {
            if( coche.Motor == "GeneralElectricCompani")
                return true;
            else
                return false;

        }
    }


    class Program
    {


       static void Main(string[] args)
        {
            //Coche miCoche = new Coche("Zetec", "Ford", "CDO128");
            //CocheElectrico miCoche = new CocheElectrico("GeneralElectricCompani", "Tesla", "AD 365 DF");
            Coche miCoche = new CocheElectrico("GeneralElectricCompani", "Tesla", "AD 365 DF");

            miCoche.Arrancar();
            miCoche.Ascelerar(20);
            miCoche.Consume(4);
            //(miCoche as Coche).Consume(4);
            miCoche.Doblar(45);
            miCoche.Frena();


            Console.WriteLine("\n\n\n");
            Policia policia = new Policia();
            if( policia.Validar(miCoche))
                Console.WriteLine("Mi coche es legal.");
            else
                Console.WriteLine("Mi coche es trucho.");

            Console.ReadKey();
        }
    }
}

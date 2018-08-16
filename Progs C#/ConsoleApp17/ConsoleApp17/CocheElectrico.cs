using System;

namespace ConsoleApp17
{
    public class CocheElectrico : Coche
    {
        public CocheElectrico(string motor, string marca, string patente)
            :base(motor, marca, patente) { }


        override public void Consume(int convustible)
        {
            Combustible -= convustible;
            Console.WriteLine($"Consumiendo electricidad, combustible restante: {Combustible}");
        }

    }


}

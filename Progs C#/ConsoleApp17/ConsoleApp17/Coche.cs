using System;

namespace ConsoleApp17
{
    public class Coche
    {
        public string Motor;
        public string Marca;
        public string Patente;
        //public int Velocidad;
        private int velocidad;
        public int Velocidad
        {
            get;
            protected set; 
        }
        public int Direccion;
        public int Combustible;


        public Coche(string motor, string marca, string patente)
        {
            Motor = motor;
            Marca = marca;
            Patente = patente;
            Velocidad = 0;
            Direccion = 0;
            Combustible = 100;
        }

        public void Arrancar()
        {
            Console.WriteLine("Arranca");
        }

        public void Ascelerar(int kilometros)
        {
            Velocidad += kilometros;
            Console.WriteLine($"Mi velocidad actual es: {Velocidad}");
        }

        public void Doblar(int grados)
        {
            Direccion += grados;
            Console.WriteLine($"Mi direccion actual es: {Direccion}");
        }

        public void Frena()
        {
            Velocidad += 0;
            Console.WriteLine($"Frene, Mi velocidad actual es: {Velocidad}");
        }

        virtual public void Consume( int convustible)
        {
            Combustible -= convustible;
            Console.WriteLine($"Consumiendo nafta, combustible restante: {Combustible}");
        }

    }


}

//----------------------------------------------------------------------------------
// Figuras.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri                                 2018-07-20
//
// Ejercicios de clases y objetos 
// Plantear un modelo de Figuras que permita representar rectangulos y triangulos.
// Implementar el calculo del area.
// Implementar el calculo del perimetro.
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Punto
    {
        //constructores
        public Punto(double x, double y)
        {
            X = x;
            Y = y;
        }

        //propiedades
        public double X { get; set; }
        public double Y { get; set; }

        //Metodos sobreescritos (override)
        public override string ToString()
        {
            string _x = string.Format("{0,2:F}", this.X);
            string _y = string.Format("{0,2:F}", this.Y);

            return ($"({_x}, {_y})");
        }
    }

    public class Recta
    {
        //constructores
        public Recta(double p, double o)
        {
            Pendiente = p;
            Ordenada = o;
        }

        //propiedades
        public double Pendiente { get; protected set; }
        public double Ordenada { get; protected set; }

        //Metodos sobreescritos (override)

    }



    public abstract class Figura
    {
        //constructores
        protected Figura(double rot)
        {
            Rotacion = rot;
        }

        //propiedades
        public double Rotacion { get; set; }
        //public Color Color { get; set; }
        //public double TipoTrazo { get; set; }
        //public double EspesorTrazo { get; set; }

        //metodos abstractos 
        //(los hijos de Empleado los tienen que implementar
        //estos metodos para poder crear un objeto heredero.
        public abstract double Area();
        public abstract double Perimetro();
        
    }




    public class Segmento:Figura
    {
        //constructores
        public Segmento(Punto a, Punto b, double rot = 0)
            :base( rot)
        {
            A = a;
            B = b;
        }

        //propiedades
        public Punto A { get; protected set; }
        public Punto B { get; protected set; }

        //Metodos sobreescritos (override)
        public double Distancia()
        {
            return Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
        }
        
        public override double Perimetro()
        {
            return this.Distancia();
        }

        public override double Area()
        {
            return 0;
        }
        
    }
}

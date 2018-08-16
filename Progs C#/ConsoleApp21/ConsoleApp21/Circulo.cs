//----------------------------------------------------------------------------------
// Circulo.cs                                               Diplomatura dotNet
// Ing Pablo Daniel Scuteri                                 2018-07-20
//
// Implementacion de la clase circulo.
//----------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Circulo : Figura
    {
        //constructores
        public Circulo(Punto c, double r, double rot = 0)
            :base( rot)
        {
            Centro = c;
            Radio = r;
        }

        //propiedades
        Punto Centro;
        double Radio;

        //Metodos
        public bool Interseccion(Recta t, out Punto p1, out Punto p2)
        {
            double _a = 1 + Math.Pow(t.Pendiente, 2);
            double _b = 2 * (- this.Centro.X - this.Centro.Y * t.Pendiente + t.Pendiente * t.Ordenada);
            double _c = Math.Pow(this.Centro.X, 2) + Math.Pow(this.Centro.Y, 2) - 2 * this.Centro.Y * t.Ordenada + Math.Pow(t.Ordenada, 2) - Math.Pow(this.Radio, 2);

            double _4ac = 4 * _a * _c;
            double _b2 = Math.Pow(_b, 2);

            if( _b < _4ac)
            {
                Punto _P1 = new Punto(0, 0);
                _P1.X = (-_b + Math.Sqrt(_b2 - _4ac)) / (2 * _a);
                _P1.Y = t.Pendiente * _P1.X + t.Ordenada;
                p1  = _P1;

                Punto _P2 = new Punto(0, 0);
                _P2.X = (-_b - Math.Sqrt(_b2 - _4ac)) / (2 * _a);
                _P2.Y = t.Pendiente * _P2.X + t.Ordenada;
                p2 = _P2;
                return true;    //existe interseccion
            }
            else
            {
                p1 = p2 = new Punto(0, 0);
                return false;   //no existe interseccion
            }              
        }

        public bool Interseccion(Circulo t, out Punto p1, out Punto p2)
        {
            double m = (this.Centro.X + t.Centro.X) / (t.Centro.Y - this.Centro.Y);
            double r = (-Math.Pow(this.Centro.X, 2) - Math.Pow(this.Centro.Y, 2) + Math.Pow(t.Centro.X, 2) + Math.Pow(t.Centro.Y, 2) + Math.Pow(this.Radio, 2) - Math.Pow(t.Radio, 2)) / (2 * (t.Centro.Y - this.Centro.Y));
            Recta EjeRadial = new Recta( m, r);

            return Interseccion( EjeRadial, out p1, out p2);
        }

        //Metodos sobreescritos (override)
        public override double Perimetro()
        {
            return 2 * Math.PI * Radio;
        }

        public override double Area()
        {
            return Math.PI  * Math.Pow( Radio, 2);
        }
        public override string ToString()
        {
            string _centro = string.Format("{0,2:F}", Centro);
            string _radio = string.Format("{0,2:F}", Radio);

            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Circunferencia de centro= {Centro}[mm] x {_radio}[mm] tiene:" +
                $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }
}

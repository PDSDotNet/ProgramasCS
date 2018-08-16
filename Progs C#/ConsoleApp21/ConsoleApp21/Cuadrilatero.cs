//----------------------------------------------------------------------------------
// Cuadrilatero.cs                                          Diplomatura dotNet
// Ing Pablo Daniel Scuteri                                 2018-07-20
//
// Implementacion de la clase circulo.
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Math;

namespace FigurasGeometricas
{
    class Cuadrilatero:Figura
    {
        //constructores
        public Cuadrilatero(double ab, double bc, double cd, double da, double ang, bool conv = true, double rot = 0)
            : base(rot)
        {
            AB = ab;
            BC = bc;
            CD = cd;
            DA = da;
            AnguloDerechoBase = ang;
            Convexo = conv;

            //se ubica el primer segmento en forma horizontal para 
            //comenzar el calculo de los demas puntos
            A = new Punto(0, 0);
            B = new Punto(ab, 0);

            //-------------------------------------------------------------------------
            //Calculo del punto C, se traza una recta por el punto B con pendiente
            //tg(AnguloDerechoBase). Y con un radio BC se halla el punto C.
            C = new Punto(0, 0);
            C.X = B.X - BC * Math.Cos(Math.PI * AnguloDerechoBase / 180);
            C.Y = BC * Math.Sin(Math.PI * AnguloDerechoBase / 180);


            //-------------------------------------------------------------------------
            //Calculo del punto D, se halla con la interseccion de dos circunferencias.
            //Una con radio DA y centro en A, y la otra con radio CD y centro en C.

            //Calculo de la distancia (_diagona) entra A y C.
            double _disDiag1 = new Segmento(A, C).Distancia();

            //Verificamos que los segmentor restantes (CD y DA) sean mas largos
            //que _diagonal para ascegurar que las circunferencias se cruzen.
            if (_disDiag1 < (CD + DA))
            {
                D = new Punto(0, 0);
                Circulo _cir1 = new Circulo(C, CD);
                Circulo _cir2 = new Circulo(A, DA);
                Punto _p1;
                Punto _p2;
                _cir1.Interseccion(_cir2, out _p1, out _p2);

                _disDiag1 = new Segmento(_p1, B).Distancia();
                double _disDiag2 = new Segmento(_p2, B).Distancia();
                if(Convexo)
                    if (_disDiag1 > _disDiag2)
                        D = _p1;
                    else
                        D = _p2;
                else
                    if (_disDiag1 < _disDiag2)
                        D = _p1;
                    else
                        D = _p2;

            }
            else
            {
                throw new System.ArgumentException($"Los segmentos CD y DA son cortos");
            }

        }

        //Campos
        protected Punto A;
        protected Punto B;
        protected Punto C;
        protected Punto D; 

        //propiedades
        public double AB { get; protected set; }  //podriamos deceir que es la base
        public double BC { get; protected set; }  //la altura
        public double CD { get; protected set; }
        public double DA { get; protected set; }
        public double Altura { get; protected set; }
        public double AnguloDerechoBase { get; protected set; }
        public double AnguloIzquierdoBase { get; protected set; }
        public bool Convexo { get; protected set; }

        //Metodos sobreescritos (override)
        public override double Area()
        {
            double CA = new Segmento(A, C).Distancia();
            if(Convexo)
                return (new Triangulo(AB,BC,CA).Area() + new Triangulo(CD, DA, CA).Area());
            else
                return (new Triangulo(AB, BC, CA).Area() - new Triangulo(CD, DA, CA).Area());
        }
        public override double Perimetro()
        {
            return (AB + BC + CD + DA);
        }
        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());
            string _ang = string.Format("{0,2:F}", AnguloDerechoBase);
            

            return ($"Cuadrilatero de= ({AB} x {BC} x {CD} x {DA}) [mm] y AnguloDerecho= {_ang}º tiene:" +
                $"\n\t\t A={A} B={B} C={C} D={D}" +
                $"\n\t\t area= {_area}[mm]2" +
                $"\n\t\t perimetro= {_perimetro}[mm]\n");
        }


    }



    class Caudrado : Cuadrilatero
    {
        public Caudrado( double lado, double rot = 0)
            :base( lado, lado, lado, lado, 90, true,rot)
        {

        }
        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Cuadrado de lado = {AB} [mm] tiene:" +
                $"\n\t\t area= {_area}[mm]2" +
                $"\n\t\t perimetro= {_perimetro}[mm]\n");
        }
    }

    class Rectangulo : Cuadrilatero
    {
        public Rectangulo(double bas, double lado, double rot = 0)
            : base(bas, lado, bas, lado, 90, true, rot)
        {

        }
        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Cuadrado de lado = ({AB} x {BC})[mm] tiene:" +
                $"\n\t\t area= {_area}[mm]2" +
                $"\n\t\t perimetro= {_perimetro}[mm]\n");
        }
    }
}

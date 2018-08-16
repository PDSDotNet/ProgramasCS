using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public abstract class Figura
    {
        //constructores
        protected Figura(double rot)
        {
            Rotacion = rot;
        }

        //propiedades
        public double Rotacion { get; set; }


        //metodos abstractos 
        //(los hijos de Empleado los tienen que implementar
        //estos metodos para poder crear un objeto heredero.
        public abstract double Area();
        public abstract double Perimetro();

    }


    public class Triangulo : Figura
    {
        //constructores
        public Triangulo(double ab, double bc, double ca, double rot = 0)
            : base(rot)
        {
            SegmentoAB = ab;
            SegmentoBC = bc;
            SegmentoCA = ca;

            double _X = (Math.Pow(SegmentoCA, 2) - Math.Pow(SegmentoBC, 2) + Math.Pow(SegmentoAB, 2)) / (2 * SegmentoAB);
            Altura = Math.Sqrt(Math.Pow(SegmentoCA, 2) - Math.Pow(_X, 2));

        }

        public double SegmentoAB { get; protected set; }   //Base del triangulo
        public double SegmentoBC { get; protected set; }   //Segmento lado derecho
        public double SegmentoCA { get; protected set; }   //Segmento lado izquierdo

        public double Altura { get; protected set; }

        public double AnguloDerechoBase { get; protected set; }
        public double AnguloSuperior { get; protected set; }
        public double AnguloIzquierdoBase { get; protected set; }


        public override double Area()
        {
            return (SegmentoAB * Altura) / 2;
        }
        public override double Perimetro()
        {
            return (SegmentoAB + SegmentoBC + SegmentoCA);
        }
        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());


            return ($"Triangulo de base= {SegmentoAB}[mm] x {SegmentoBC}[mm] x {SegmentoCA}[mm] tiene:" +
                 $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }




    public class TrianguloEquilatero : Triangulo
    {
        //constructores
        public TrianguloEquilatero(double ab, double rot = 0)
            : base(ab, ab, ab, rot) { }

        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Triangulo equilátero de lados= {SegmentoAB}[mm] tiene:" +
                 $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }


    public class TrianguloIsosceles : Triangulo
    {
        //constructores
        public TrianguloIsosceles(double ab, double bc, double rot = 0)
            : base(ab, bc, bc, rot) { }


        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Triangulo isósceles de base= {SegmentoAB}[mm] y lados= {SegmentoBC} tiene:" +
                 $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }



    public class Rectangulo : Figura
    {
        //constructores
        public Rectangulo(double ab, double bc, double rot = 0)
            : base(rot)
        {
            SegmentoAB = ab;
            SegmentoBC = bc;


        }

        public double SegmentoAB { get; protected set; }   //Base del triangulo
        public double SegmentoBC { get; protected set; }   //Segmento lado derecho



        public override double Area()
        {
            return (SegmentoAB * SegmentoBC) ;
        }
        public override double Perimetro()
        {
            return (2 * SegmentoAB + 2 * SegmentoBC );
        }
        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());


            return ($"Rectangulo de = ({SegmentoAB} x {SegmentoBC})[mm]  tiene:" +
                 $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }




    public class Cuadrado : Triangulo
    {
        //constructores
        public Cuadrado(double ab, double rot = 0)
            : base(ab, ab, rot) { }

        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Cuadrado de= {SegmentoAB}[mm] tiene:" +
                 $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }










}

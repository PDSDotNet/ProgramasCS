//----------------------------------------------------------------------------------
// Triangulo.cs                                             Diplomatura dotNet
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
    public class Triangulo : Figura
    {
        //constructores
        public Triangulo(double ab, double bc, double ca, double rot = 0)
            : base(rot)
        {
            SegmentoAB = ab;
            SegmentoBC = bc;
            SegmentoCA = ca;

            double _X = (Math.Pow(SegmentoCA, 2)- Math.Pow(SegmentoBC, 2)+ Math.Pow(SegmentoAB, 2)) / (2* SegmentoAB);
            Altura = Math.Sqrt(Math.Pow(SegmentoCA, 2)- Math.Pow(_X, 2));

            AnguloDerechoBase   = (180 * Math.Acos((SegmentoAB - _X) / SegmentoBC)) /Math.PI;
            AnguloSuperior      = (180 * Math.Acos((Altura) / SegmentoBC)) / Math.PI + (180 * Math.Acos((Altura) / SegmentoCA)) / Math.PI;
            AnguloIzquierdoBase = (180 * Math.Acos(_X / SegmentoCA)) / Math.PI;
        }
        /*        public Triangulo(double ab, double h, double ang, double rot = 0)
            : base(rot)
        {
            SegmentoAB = ab;
            Altura = h;
            AnguloDerechoBase = ang;

            SegmentoBC = Altura / Math.Sin(Math.PI * AnguloDerechoBase / 180);
            SegmentoCA = Math.Sqrt(Math.Pow(SegmentoAB, 2) + Math.Pow(SegmentoBC, 2));
        }*/
        //propiedades
        public double SegmentoAB { get; protected set; }   //Base del triangulo
        public double SegmentoBC { get; protected set; }   //Segmento lado derecho
        public double SegmentoCA { get; protected set; }   //Segmento lado izquierdo

        public double Altura { get; set; }

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
            string _h = string.Format("{0,2:F}", Altura);
            string _perimetro = string.Format("{0,2:F}", Perimetro());
            string _angDB = string.Format("{0,2:F}", AnguloDerechoBase);
            string _angSup = string.Format("{0,2:F}", AnguloSuperior);
            string _angIB = string.Format("{0,2:F}", AnguloIzquierdoBase);


            return ($"Triangulo de base= {SegmentoAB}[mm] x {SegmentoBC}[mm] x {SegmentoCA}[mm] tiene:" +
                $"\n\t\t Altura= {_h}" +
                $"\n\t\t Angulos= {_angDB} + {_angSup} + {_angIB} = {AnguloDerechoBase+ AnguloSuperior + AnguloIzquierdoBase}" +
                $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }




    public class TrianguloEquilatero : Triangulo
    {
        //constructores
        public TrianguloEquilatero(double ab, double rot = 0)
            : base(ab, ab, ab, rot){        }
        /*        public TrianguloEquilatero(double ab, double rot = 0)
            : base(ab, 0, 60, rot)
        {
            //Base = bas;
            //AnguloDerechoBase = 60;
            Altura = (SegmentoAB * (Math.Tan((Math.PI * AnguloDerechoBase) / 180)) / 2);
            SegmentoCA = SegmentoBC = ab;
            //SegmentoCA = SegmentoBC = Math.Sqrt(Math.Pow(SegmentoAB / 2, 2) + Math.Pow(Altura, 2));
        }*/

        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _h = string.Format("{0,2:F}", Altura);
            string _angDB = string.Format("{0,2:F}", AnguloDerechoBase);
            string _perimetro = string.Format("{0,2:F}", Perimetro());

            return ($"Triangulo equilátero de lados= {SegmentoAB}[mm] tiene:" +
                $"\n\t\t Altura= {_h}[mm]" +
                $"\n\t\t Angulo= 3 * {_angDB} = {AnguloDerechoBase + AnguloSuperior + AnguloIzquierdoBase}º" +
                $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }


    public class TrianguloIsosceles : Triangulo
    {
        //constructores
        public TrianguloIsosceles(double ab, double bc, double rot = 0)
            : base(ab, bc, bc, rot) {        }
        /*        public TrianguloIsosceles(double ab, double ang, double rot = 0)
            : base(ab, 0, ang, rot)
        {
            //Base = bas;
            //AnguloDerechoBase = 60;
            Altura = (SegmentoAB * (Math.Tan((Math.PI * AnguloDerechoBase) / 180)) / 2);
            SegmentoCA = SegmentoBC = Math.Sqrt(Math.Pow(SegmentoAB / 2, 2) + Math.Pow(Altura, 2));
        }*/

        public override string ToString()
        {
            string _area = string.Format("{0,2:F}", Area());
            string _h = string.Format("{0,2:F}", Altura);
            string _perimetro = string.Format("{0,2:F}", Perimetro());
            string _angDB = string.Format("{0,2:F}", AnguloDerechoBase);
            string _angSup = string.Format("{0,2:F}", AnguloSuperior);

            return ($"Triangulo isósceles de base= {SegmentoAB}[mm] y lados= {SegmentoBC} tiene:" +
                $"\n\t\t Altura= {_h}[mm]" +
                $"\n\t\t Angulo= 2 * {_angDB} + {_angSup} = {AnguloDerechoBase + AnguloSuperior + AnguloIzquierdoBase}º" +
                $"\n\t\t Area= {_area}[mm]2" +
                $"\n\t\t Perimetro= {_perimetro}[mm]\n");
        }
    }

}

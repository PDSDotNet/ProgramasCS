//---------------------------------------------------------------------
// ConsoleApp16.cs                                  Diplomatura dotNet
// Ing Pablo Daniel Scuteri
//
// Programa ordena un vector ingresado por por linea de 
// comando o por teclado, y luego muestra por pantalla ambos vectores.
//
// 2018-07-05   Se implemento el ingreso por teclado y se mostro la matriz.ConsoleApp14
// 2018-07-05   Se implemento la linea de comando.ConsoleApp14
// 2018-07-05   
//---------------------------------------------------------------------
/*
 * 1  
 * 2  
 * 3 
 * 4  
 * 5  
 * 6  
 * 7  
 * 8 
 * //cadena ordenada
 * Brasil 1958 1962 1970 1994 2002 0 Italia 1934 1938 1982 2006 0 Alemania 1954 1974 1990 2014 0 Uruguay 1930 1950 0 Argentina 1978 1986 0 Inglaterra 1966 0 Francia 1998 0 España 2010 0
 * //Cadena desordenada
 * España 2010 0 Argentina 1978 1986 0 Alemania 1954 1974 1990 2014 0 Brasil 1958 1962 1970 1994 2002 0 Francia 1998 0 Uruguay 1930 1950 0 Italia 1934 1938 1982 2006 0 Inglaterra 1966 0 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        //funcion que muestra el help
        static void HelpText()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Ejecute: ConsoleApp16 ENTER: el programa pide que se ingrese los ");
            Console.WriteLine("         paices campeones separados por año.\n\n");
            Console.WriteLine("Ejecute: ConsoleApp16 Brazil 55 66 33 0 Argenina 22 55 ENTER el");
            Console.WriteLine("         programa ingresara el nombre del pais campeon y luego los ");
            Console.WriteLine("         años donde salio campeon, para finalizar el ingreso de años .");
            Console.WriteLine("         ingresar cero. Continuar con otros paices");
            Console.WriteLine("         NOTA1: entre los numeros hay un espacio.\n\n");
            Console.WriteLine("Ejecute: ConsoleApp16 -h ENTER esta auda");
            Console.WriteLine("----------------------------------------------------------------------");
        }

        //funcion que muestra la informacion por pantalla
        static void IngresoDeDatos(string[] strIn, out string[] pais, out int[][] años)
        {
            int _numPaises = 0;
            //primero hallamos la cantidad de paices campeones
            for(int i = 0; i < strIn.Length; i++)
                if (strIn[i] == "0")
                    _numPaises++;

            //llena el array de paises campeones
            pais = new string[ _numPaises];
            años = new int[_numPaises][];
            int _aux = 0;
            int _indicePais = 0;
            int _indiceAño = 0;
            int _cantidadCampeonatos = 0;

            for (int i = 0; i < strIn.Length; i++)
                if( int.TryParse(strIn[i], out _aux))
                {
                    if (_aux != 0)
                    {
                        años[_indicePais][_indiceAño] = _aux;
                        _indiceAño++;
                    }
                    else
                    {
                        _indiceAño = 0;
                        _indicePais++;
                    }
                       
                }
                else
                {
                    //Guarda el nombre del pais en la Array de Strings
                    pais[ _indicePais] = string.Copy(strIn[i]);

                    //halla la cantidad de campeonatos ganados por un pais
                    _cantidadCampeonatos = 0;
                    while (strIn[i + 1 + _cantidadCampeonatos] != "0")
                        _cantidadCampeonatos++;
                    años[_indicePais] = new int[_cantidadCampeonatos];
                }
        }

        //funcion que muestra la informacion por pantalla
        static void Display(string[] pais, int[][] años)
        {
            string aux, aux1;
            int maxLen = 0;

            //encuentra la cantidad de caracteres del pais que mas caracteres tiene.
            for (int i = 0; i < pais.Length; i++)
                if (maxLen < pais[i].Length)
                    maxLen = pais[i].Length;
            
            //muestra los paices y los años donde fueron campeones
            Console.Clear();
            for (int i = 0; i < pais.Length; i++)
            {
                //formatea el numero de pais
                aux = string.Format("{0,2:D}", i + 1);
                //crea una cadena con la diferencia de espacios
                aux1 = new string(' ', (maxLen - pais[i].Length));
                Console.Write($"{aux}_ {pais[i]}{aux1} años:  ");

                for (int j = 0; j < años[i].GetLength(0); j++)
                {
                    aux = string.Format("{0,4:D}", años[i][j]);
                    if (j == 0)
                        Console.Write($"{aux}");
                    else
                        Console.Write($", {aux}");
                }
                Console.Write(".\n");
            }
        }

        //funcion que ordena el array de campeonatosPorCampeon de mayor cantidad de campeonatos 
        //a menor cantidad de campeonatos, y lo aparea al array de paises.
        static void OrdenarArrays(string[] paises, int[][]años)
        {
            int _numPaises = 0;
            _numPaises = paises.Length;

            for (int indExt = 0; indExt < _numPaises - 1; indExt++)
                for (int indInt = indExt + 1; indInt < _numPaises; indInt++)
                    if(años[indExt].GetLength(0) < años[indInt].GetLength(0))
                    {
                        //aux = vector[indInt];
                        int[] _aux = new int[años[indInt].GetLength(0)];
                        años[indInt].CopyTo(_aux, 0);
                                                
                        //vector[indInt] = vector[indExt];
                        años[indInt] = new int[años[indExt].GetLength(0)];
                        años[indExt].CopyTo(años[indInt], 0);
                        
                        //vector[indExt] = aux;
                        años[indExt] = new int[_aux.GetLength(0)];
                        _aux.CopyTo(años[indExt], 0);


                        string _strAux;
                        _strAux = paises[indInt];
                        paises[indInt] = paises[indExt];
                        paises[indExt] = _strAux;
                    }

        }



        static void Main(string[] args)
        {
            string inputStr;
            string[] campeones = { "F", "G" }, aux1;
            int[][] campeonatosPorCampeon = { new int[]{ 1, 3 }, new int[]{ 3, 4, 6 } };
            


            if (args.Length != 0)
            {
                //averigua si se ingreso algo por la linea de comando
                if ((args[0] == "-h") || (args[0] == "-H") || (args[0] == "-help") ||
                (args[0] == "?") || (args[0] == "-?") || (args[0] == "-Help") || (args[0] == "-HELP"))
                {
                    //se ingreso informacion por linea de comando
                    if (args.Length > 0)
                    {
                        //se ingreso un pedido de ayuda
                        HelpText();    
                        //Finalizacion del programa
                        Console.WriteLine("\n\n\n\nPrecione ENTER para finalizar.");
                        Console.ReadKey();
                        return;
                    }

                }
                else
                {
                    //se ingreso informacion
                    IngresoDeDatos(args, out campeones, out campeonatosPorCampeon);
                }
            }
            else
            {
                //si no se ingreso nada por la linea de comando
                Console.Write("Ingrese los campeones separados por espacios:\n");
                inputStr = Console.ReadLine();
                if (inputStr[inputStr.Length - 1] == ' ')
                    inputStr = inputStr.Trim();
                campeones = inputStr.Split(' ');

                //declaracion del array de los años en que los campeones ganaron
                campeonatosPorCampeon = new int[campeones.Length][];

                for (int i = 0; i < campeones.Length; i++)
                {
                    Console.Write($"Ingrese los años cuando {campeones[i]} fueron campeones,\n separados por espacio: ");
                    
                    inputStr = Console.ReadLine();
                    if (inputStr[inputStr.Length - 1] == ' ')
                        inputStr = inputStr.Trim();
                    aux1 = inputStr.Split(' ');
                    campeonatosPorCampeon[i] = new int[aux1.Length];

                    for(int j =0; j < aux1.Length; j++)
                        campeonatosPorCampeon[i][j] = int.Parse(aux1[j]);
                }

            }

            //mostrar la matriz en forma de matriz
            Display(campeones, campeonatosPorCampeon);

            char car;
            Console.WriteLine("\n\n\n\npresione x para salir \no cualquier tecla para ver la lista ordenada.");
            car = Console.ReadKey().KeyChar;

            if( car != 'x' || car != 'X')
            {
                Console.Clear();
                OrdenarArrays( campeones, campeonatosPorCampeon);
                Display(campeones, campeonatosPorCampeon);
            }
            //mostrar la matriz en forma de matriz
            





            //Finalizacion del programa
            Console.WriteLine("\n\n\n\nPrecione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}

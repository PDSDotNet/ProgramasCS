using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TestSEH
{
    class Program
    {
        static string[] eTypes = { "none", "simple", "index", "nested index", "filter" };

        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    WriteLine("Main() try block reached."); //Line 21
                    Console.Write("ThrowException(\""); Console.Write(eType); Console.Write("\") called.\n");
                    ThrowException(eType);
                    Console.WriteLine("Main() try block continues."); //Line 23
                }

                catch (System.IndexOutOfRangeException e) when (eType == "filter")            // Line 26
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    //WriteLine($"Main() FILTERED System.IndexOutOfRangeException catch block reached. Message:\n\"{e.Message}\"");
                    Console.Write("Main() FILTERED System.IndexOutOfRangeException catch block reached. Message:\n\""); Console.Write(e.Message); Console.Write("\"\n");
                    Console.ResetColor();
                }
                catch (System.IndexOutOfRangeException e)              // Line 32
                {
                    //WriteLine($"Main() System.IndexOutOfRangeException catch block reached. Message:\n\"{e.Message}\"");
                    Console.Write("Main() System.IndexOutOfRangeException catch block reached. Message:\n"); Console.Write(e.Message); Console.Write("\"\n");
                }
                catch                                                    // Line 36
                {
                    Console.WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    Console.WriteLine("Main() finally block reached.\n");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }



        static void ThrowException(string exceptionType)
        {
            //WriteLine($"ThrowException(\"{exceptionType}\") reached.");
            Console.Write("\tThrowException(\""); Console.Write(exceptionType); Console.Write("\") reached.\n");

            switch (exceptionType)
            {
                case "none":
                    Console.WriteLine("\tNot throwing an exception.");
                    break;                                               // Line 57
                case "simple":
                    Console.WriteLine("\tThrowing System.Exception.");
                    throw new System.Exception();                        // Line 60
                    //break;
                case "index":
                    Console.WriteLine("\t\tThrowing System.IndexOutOfRangeException.");
                    eTypes[5] = "error";                                 // Line 63
                    break;
                case "nested index":
                    try                                                  // Line 66
                    {
                        Console.WriteLine("\tThrowException(\"nested index\") " + "try block reached.");
                        Console.WriteLine("\tThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 71
                    }
                    catch                                                // Line 66
                    {
                        Console.WriteLine("\tThrowException(\"nested index\") general" + " catch block reached.");
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine("\tThrowException(\"nested index\") finally" + " block reached.");
                    }
                    break;
                case "filter":
                    try                                                  // Line 86
                    {
                        Console.WriteLine("\tThrowException(\"filter\") " + "try block reached.");
                        Console.WriteLine("\tThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 91
                    }
                    catch                                                // Line 93
                    {
                        WriteLine("\tThrowException(\"filter\") general" + " catch block reached.");
                        throw;
                    }
                    break;
            }
        }



    }
}

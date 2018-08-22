using System;

namespace CSharpHelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello World!");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}

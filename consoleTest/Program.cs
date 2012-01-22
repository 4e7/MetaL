using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaLSyntaxAnalizator;
namespace consoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Analizator analizator = new Analizator();
            Console.WriteLine("Введите строку :");
            string s=Console.ReadLine();
            Console.WriteLine("Код на языке ассемблера:");
            Console.Write(analizator.parse(s) + "\n");
            List<string> errors = analizator.errorMessages();
            foreach (string error in errors)
            {
                Console.Write(error);
                Console.Write("\n");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using CapaNegocio;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            NegocioCN ng = new NegocioCN();
            List<string> lista = ng.GetCategories();
            foreach (string li in lista)
            {
                Console.WriteLine(li);
            }
            Console.Read();
        }
    }
}

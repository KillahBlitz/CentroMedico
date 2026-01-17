using System;
using System.Linq;
using CentroMedico.models;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("hello World");
                Console.WriteLine("Database initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
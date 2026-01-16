using System;
using System.Linq;
using CentroMedico.models;
using CentroMedico.presenters;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                principalPresenter.initDataBase();
                Console.ForegroundColor = ConsoleColor.Green;
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
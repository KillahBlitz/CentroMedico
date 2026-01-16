using Microsoft.EntityFrameworkCore;
using CentroMedico.models;
using System.IO;
using System;

namespace CentroMedico.Database
{
    public class ConsultorioContext : DbContext
    {
        public DbSet<patientModel> Patients { get; set; }
        public DbSet<historyModel> Histories { get; set; }
        public DbSet<consulationModel> Consultations { get; set; }

        private static string RutaDestino => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "consultorio_reynoso.db");

        public ConsultorioContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={RutaDestino}");
            }
        }

        public static void PrepararBaseDeDatos()
        {
            string destino = RutaDestino;


            if (!File.Exists(destino))
            {
                Console.WriteLine("Inicializando base de datos por primera vez...");

                string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
                string rutaOriginal = "";

                string intentoConsola = Path.GetFullPath(Path.Combine(directorioBase, @"..\..\..\..\CentroMedico\database\consultorio_reynoso.db"));

                string intentoWPF = Path.GetFullPath(Path.Combine(directorioBase, @"..\..\..\database\consultorio_reynoso.db"));

                if (File.Exists(intentoConsola))
                {
                    rutaOriginal = intentoConsola;
                }
                else if (File.Exists(intentoWPF))
                {
                    rutaOriginal = intentoWPF;
                }

                if (File.Exists(rutaOriginal))
                {
                    File.Copy(rutaOriginal, destino);
                    Console.WriteLine($"Base de datos copiada exitosamente a: {destino}");
                }
                else
                {
                    Console.WriteLine("⚠️ No se encontró la plantilla original. Creando base de datos vacía.");
                    using (var db = new ConsultorioContext())
                    {
                        db.Database.EnsureCreated();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Base de datos encontrada en: {destino}");
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using CentroMedico.models;
using System;
using System.IO;

namespace CentroMedico.Database
{
    public class ConsultorioContext : DbContext
    {
        public DbSet<patientModel> Patients { get; set; }
        public DbSet<historyModel> Histories { get; set; }
        public DbSet<consulationModel> Consulations { get; set; }

        private const string DbFileName = "consultorio_reynoso.db";

        private static readonly string RutaDestino =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbFileName);

        private static readonly string RutaOrigen =
            Path.Combine(AppContext.BaseDirectory, DbFileName);

        public ConsultorioContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite($"Data Source={RutaDestino}");
        }

        public static void PrepareDatBase()
        {
            if (File.Exists(RutaDestino))
            {
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(RutaDestino)!);

            if (File.Exists(RutaOrigen))
            {
                File.Copy(RutaOrigen, RutaDestino, overwrite: false);
                return;
            }

            using (var db = new ConsultorioContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}

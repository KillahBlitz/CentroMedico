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

        public ConsultorioContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                string dbName = "consultorio_reynoso.db";
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                string dbPath = Path.Combine(folderPath, dbName);

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
    }
}
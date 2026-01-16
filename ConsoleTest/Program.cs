using System;
using System.Linq;
using CentroMedico.Database; // Referencia a tu proyecto WPF
using CentroMedico.models;   // Referencia a tus modelos

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   INICIANDO TEST DE BASE DE DATOS      ");
            Console.WriteLine("========================================");

            try
            {
                // 1. Instanciamos el contexto (la conexión)
                // Al ser el mismo código que en WPF, buscará la DB en AppData/Local
                using (var db = new ConsultorioContext())
                {
                    // Asegura que la DB exista. Si no existe, la crea.
                    Console.WriteLine("Verificando existencia de la base de datos...");
                    db.Database.EnsureCreated();
                    Console.WriteLine("Base de datos verificada/creada correctamente.");

                    // 3. LEER (SELECT) - Listar todos los pacientes
                    Console.WriteLine("\n--- Listado Actual de Pacientes en DB ---");

                    var listaPacientes = db.Patients.ToList();

                    if (listaPacientes.Count > 0)
                    {
                        foreach (var p in listaPacientes)
                        {
                            Console.WriteLine($"ID: {p.id} | Nombre: {p.name} | Tipo: {p.type_patient}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron pacientes.");
                    }

                    // 4. (Opcional) CONTEO RAPIDO
                    var total = db.Patients.Count();
                    Console.WriteLine($"\nTotal de registros en la tabla Patients: {total}");

                    //consultar la tabla de consulations
                    Console.WriteLine("\n--- Listado Actual de Consultas en DB ---");
                    var listaConsultas = db.Consulations.ToList();
                    if (listaConsultas.Count > 0)
                    {
                        foreach (var c in listaConsultas)
                        {
                            Console.WriteLine($"ID: {c.id} | Fecha: {c.date} | Motivo: {c.observations}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron consultas.");
                    }

                    var total2 = db.Consulations.Count();
                    Console.WriteLine($"\nTotal de registros en la tabla Consultations: {total2}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR FATAL:");
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Detalle interno: " + ex.InnerException.Message);
                }
                Console.ResetColor();
            }
        }
    }
}
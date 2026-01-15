# Centro Médico - Conexión SQLite

## 📋 Descripción

Este proyecto incluye una conexión a base de datos SQLite usando Entity Framework Core. La base de datos incluye tres tablas principales: Pacientes, Consultas e Historial.

## 🗄️ Estructura de la Base de Datos

### Tablas

1. **Patients** (Pacientes)
   - Id (int, primary key)
   - Nombre (string)
   - Apellido (string)
   - Telefono (string)
   - Email (string)
   - Direccion (string)
   - FechaNacimiento (DateTime)
   - FechaRegistro (DateTime)

2. **Consultations** (Consultas)
   - Id (int, primary key)
   - PatientId (int, foreign key)
   - FechaConsulta (DateTime)
   - Motivo (string)
   - Diagnostico (string)
   - Tratamiento (string)
   - Observaciones (string)

3. **Histories** (Historial)
   - Id (int, primary key)
   - PatientId (int, foreign key)
   - Fecha (DateTime)
   - TipoRegistro (string)
   - Descripcion (string)
   - RegistradoPor (string)

## 🚀 Uso Básico

### Inicializar la Base de Datos

```csharp
using centro_medico.db;

// Crear la base de datos y las tablas
DatabaseHelper.InitializeDatabase();
```

### Agregar un Paciente

```csharp
using centro_medico.db;
using centro_medico.models;

using (var context = new CentroMedicoContext())
{
    var paciente = new Patient
    {
        Nombre = "María",
        Apellido = "García",
        Telefono = "555-5678",
        Email = "maria.garcia@email.com",
        Direccion = "Avenida Central 456",
        FechaNacimiento = new DateTime(1985, 8, 20)
    };

    context.Patients.Add(paciente);
    context.SaveChanges();
}
```

### Consultar Pacientes

```csharp
using centro_medico.db;

// Obtener todos los pacientes
var pacientes = DatabaseHelper.ObtenerTodosPacientes();

// Buscar un paciente específico
var paciente = DatabaseHelper.BuscarPacientePorId(1);
```

### Agregar una Consulta

```csharp
using centro_medico.db;

DatabaseHelper.AgregarConsulta(
    pacienteId: 1,
    motivo: "Dolor de cabeza",
    diagnostico: "Migraña"
);
```

### Actualizar un Paciente

```csharp
using centro_medico.db;

DatabaseHelper.ActualizarPaciente(
    id: 1,
    nuevoTelefono: "555-9999",
    nuevoEmail: "nuevo@email.com"
);
```

### Obtener Consultas de un Paciente

```csharp
using centro_medico.db;

var consultas = DatabaseHelper.ObtenerConsultasPorPaciente(pacienteId: 1);
foreach (var consulta in consultas)
{
    Console.WriteLine($"{consulta.FechaConsulta}: {consulta.Motivo}");
}
```

## 🔧 Uso Avanzado con Entity Framework

### Operaciones LINQ

```csharp
using centro_medico.db;
using Microsoft.EntityFrameworkCore;

using (var context = new CentroMedicoContext())
{
    // Buscar pacientes por nombre
    var pacientes = context.Patients
        .Where(p => p.Nombre.Contains("Juan"))
        .ToList();

    // Obtener pacientes con sus consultas
    var pacientesConConsultas = context.Patients
        .Include(p => p.Consultas)
        .ToList();

    // Contar consultas por paciente
    var totalConsultas = context.Consultations
        .Where(c => c.PatientId == 1)
        .Count();
}
```

### Transacciones

```csharp
using centro_medico.db;
using Microsoft.EntityFrameworkCore;

using (var context = new CentroMedicoContext())
{
    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            // Agregar paciente
            var paciente = new Patient { Nombre = "Test", Apellido = "Test" };
            context.Patients.Add(paciente);
            context.SaveChanges();

            // Agregar consulta
            var consulta = new Consultation 
            { 
                PatientId = paciente.Id, 
                Motivo = "Chequeo" 
            };
            context.Consultations.Add(consulta);
            context.SaveChanges();

            // Confirmar transacción
            transaction.Commit();
        }
        catch
        {
            // Revertir en caso de error
            transaction.Rollback();
            throw;
        }
    }
}
```

## 📦 Paquetes NuGet Instalados

- `Microsoft.EntityFrameworkCore.Sqlite` (8.0.11)
- `Microsoft.EntityFrameworkCore.Design` (8.0.11)

## 📝 Ubicación de la Base de Datos

La base de datos SQLite (`centromedico.db`) se crea automáticamente en la carpeta del ejecutable:
- Durante desarrollo: `bin/Debug/net8.0-windows/centromedico.db`
- En producción: En la carpeta donde se ejecute la aplicación

## 🛠️ Comandos Útiles

### Crear Migraciones (opcional)

Si prefieres usar migraciones en lugar de `EnsureCreated()`:

```bash
# Instalar herramientas EF Core (si no está instalado)
dotnet tool install --global dotnet-ef

# Crear una migración
dotnet ef migrations add InitialCreate

# Aplicar migraciones
dotnet ef database update
```

## ⚠️ Notas Importantes

1. La base de datos se crea automáticamente al llamar `context.Database.EnsureCreated()`
2. Usa `using` statements para asegurar que las conexiones se cierren correctamente
3. Las relaciones entre tablas están configuradas con eliminación en cascada
4. Los campos opcionales están marcados con `?` (nullable)

## 📚 Recursos Adicionales

- [Documentación Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [SQLite con EF Core](https://docs.microsoft.com/ef/core/providers/sqlite/)
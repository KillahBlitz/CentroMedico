# 🏥 Centro Médico - Sistema de Gestión de Consultorio

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge)

### 💊 Sistema completo para la gestión de pacientes y consultas médicas

</div>

---

## 📋 Tabla de Contenidos

- [Descripción General](#-descripción-general)
- [Características Principales](#-características-principales)
- [Tecnologías Utilizadas](#-tecnologías-utilizadas)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Requisitos del Sistema](#-requisitos-del-sistema)
- [Instalación](#-instalación)
- [Configuración de Base de Datos](#-configuración-de-base-de-datos)
- [Modelos de Datos](#-modelos-de-datos)
- [Uso](#-uso)
- [Contribuir](#-contribuir)

---

## 🎯 Descripción General

**Centro Médico** es una aplicación de escritorio desarrollada en **WPF (.NET 8.0)** diseñada para facilitar la gestión integral de un consultorio médico. Permite el registro de pacientes, seguimiento de consultas médicas y mantenimiento del historial clínico de forma organizada y eficiente.

### 🌟 Objetivo

Proporcionar una herramienta robusta y fácil de usar para profesionales de la salud, optimizando el manejo de información de pacientes y consultas.

---

## ✨ Características Principales

| Característica | Descripción | Ícono |
|:--------------|:-----------|:-----:|
| **Gestión de Pacientes** | Registro completo de datos del paciente incluyendo edad, peso, altura y tipo de sangre | 👥 |
| **Control de Consultas** | Seguimiento detallado de cada consulta médica realizada | 📝 |
| **Historial Clínico** | Mantenimiento completo del historial médico de cada paciente | 📊 |
| **Base de Datos Local** | Almacenamiento seguro usando SQLite con Entity Framework Core | 💾 |
| **Interfaz Intuitiva** | Diseño amigable desarrollado con WPF para Windows | 🖥️ |

---

## 🛠️ Tecnologías Utilizadas

<table>
<tr>
<td width="50%">

### 🔧 Framework & Lenguaje
- **.NET 8.0** - Framework principal
- **C#** - Lenguaje de programación
- **WPF** - Windows Presentation Foundation

</td>
<td width="50%">

### 📦 Paquetes NuGet
- **Microsoft.EntityFrameworkCore.Sqlite** `v8.0.11`
- **Microsoft.EntityFrameworkCore.Tools** `v8.0.11`

</td>
</tr>
</table>

---

## 📁 Estructura del Proyecto

```
📦 CentroMedico/
├── 📂 CentroMedico/              # Proyecto principal de la aplicación
│   ├── 📂 database/              # Contexto y scripts de base de datos
│   │   ├── ConsultorioContext.cs
│   │   └── campos_agregados.sql
│   ├── 📂 models/                # Modelos de datos
│   │   ├── patientModel.cs       # 👤 Modelo de paciente
│   │   ├── consultationModel.cs  # 📋 Modelo de consulta
│   │   └── historyModel.cs       # 📜 Modelo de historial
│   ├── 📂 presenters/            # Capa de presentación (MVP)
│   ├── App.xaml                  # Configuración de la aplicación
│   ├── MainWindow.xaml           # Ventana principal
│   └── CentroMedico.csproj       # Archivo del proyecto
├── 📂 ConsoleTest/               # Proyecto de pruebas de consola
├── 📄 CentroMedico.sln           # Solución de Visual Studio
└── 📄 README.md                  # Este archivo
```

---

## 💻 Requisitos del Sistema

| Requisito | Especificación |
|:----------|:---------------|
| 🖥️ **Sistema Operativo** | Windows 10 o superior |
| 🔷 **.NET Runtime** | .NET 8.0 SDK o superior |
| 💾 **Espacio en Disco** | Mínimo 100 MB |
| 🧠 **RAM** | Mínimo 4 GB (recomendado 8 GB) |
| 🔧 **IDE Recomendado** | Visual Studio 2022 o Visual Studio Code |

---

## 🚀 Instalación

### Paso 1️⃣: Clonar el Repositorio

```bash
git clone <url-del-repositorio>
cd CentroMedico
```

### Paso 2️⃣: Restaurar Paquetes NuGet

```bash
dotnet restore
```

### Paso 3️⃣: Compilar el Proyecto

```bash
dotnet build
```

### Paso 4️⃣: Ejecutar la Aplicación

```bash
dotnet run --project CentroMedico/CentroMedico.csproj
```

---

## 🗄️ Configuración de Base de Datos

### ⚠️ IMPORTANTE - Configuración Manual Requerida

La aplicación utiliza una base de datos SQLite local. Para que funcione correctamente, debes realizar lo siguiente:

#### 📍 Ubicación de la Base de Datos

El archivo de base de datos **`consultorio_reynoso.db`** debe estar ubicado en la carpeta de datos locales de la aplicación:

```
%LocalAppData%\
```

Para acceder a esta carpeta:
1. Presiona `Windows + R`
2. Escribe `%LocalAppData%` y presiona Enter
3. Copia el archivo `consultorio_reynoso.db` en esta ubicación

#### 📋 Pasos de Configuración

| Paso | Acción |
|:----:|:-------|
| 1️⃣ | Localiza el archivo `consultorio_reynoso.db` en el proyecto |
| 2️⃣ | Abre el Explorador de Archivos de Windows |
| 3️⃣ | En la barra de direcciones, escribe `%LocalAppData%` y presiona Enter |
| 4️⃣ | Copia el archivo `consultorio_reynoso.db` a esta carpeta |
| 5️⃣ | Verifica que el archivo esté en la ubicación correcta |

#### 🔍 Ruta Completa de Ejemplo

```
C:\Users\[TuUsuario]\AppData\Local\consultorio_reynoso.db
```

> 💡 **Nota**: La carpeta `AppData` es una carpeta oculta. Asegúrate de tener habilitada la opción de "Mostrar archivos ocultos" en el Explorador de Windows.

---

## 📊 Modelos de Datos

### 👤 Modelo de Paciente (`patientModel`)

| Campo | Tipo | Descripción |
|:------|:-----|:------------|
| `id` | `int` | 🔑 Identificador único (Clave primaria) |
| `name` | `string` | 📝 Nombre completo del paciente |
| `age` | `string` | 🎂 Edad del paciente |
| `type_patient` | `string` | 🏷️ Tipo de paciente (adulto, pediátrico, etc.) |
| `weight` | `float` | ⚖️ Peso del paciente (kg) |
| `height` | `float` | 📏 Altura del paciente (cm) |
| `total_consulation` | `int` | 📋 Total de consultas realizadas |
| `birthdate` | `DateTime` | 🎂 Fecha de nacimiento |
| `apgar` | `string` | 👶 Puntuación APGAR (para pacientes pediátricos) |
| `blood_type` | `string` | 🩸 Tipo de sangre |

### 📋 Modelo de Consulta (`consultationModel`)

Almacena información detallada de cada consulta médica realizada a un paciente.

### 📜 Modelo de Historial (`historyModel`)

Mantiene un registro cronológico de todos los eventos médicos del paciente.

---

## 🎮 Uso

### Inicio de la Aplicación

1. **Ejecutar** la aplicación desde Visual Studio o mediante el ejecutable compilado
2. La **ventana principal** (`MainWindow.xaml`) se abrirá automáticamente
3. Desde allí podrás acceder a todas las funcionalidades del sistema

### Funcionalidades Disponibles

```
┌─────────────────────────────────────────┐
│      🏥 Centro Médico - Menu Principal     │
├─────────────────────────────────────────┤
│  👥 Gestión de Pacientes                │
│    ├── ➕ Agregar nuevo paciente         │
│    ├── ✏️ Editar paciente existente      │
│    ├── 🔍 Buscar paciente                │
│    └── 🗑️ Eliminar registro              │
│                                         │
│  📋 Gestión de Consultas                │
│    ├── ➕ Nueva consulta                 │
│    ├── 📊 Ver historial de consultas    │
│    └── 📝 Detalles de consulta          │
│                                         │
│  📜 Historial Clínico                   │
│    ├── 📖 Ver historial completo        │
│    └── 🔍 Buscar en historial           │
└─────────────────────────────────────────┘
```

---

## 👨‍💻 Contribuir

¿Deseas contribuir al proyecto? ¡Todas las contribuciones son bienvenidas!

### Proceso de Contribución

1. 🍴 Haz un Fork del proyecto
2. 🌿 Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. 💾 Haz commit de tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. 📤 Push a la rama (`git push origin feature/AmazingFeature`)
5. 🔃 Abre un Pull Request

---

## 📝 Notas Adicionales

### 🔒 Seguridad

- La base de datos se almacena localmente en el equipo del usuario
- No se requiere conexión a Internet para el funcionamiento básico
- Se recomienda realizar copias de seguridad periódicas de la base de datos

### 🐛 Reporte de Errores

Si encuentras algún error o tienes sugerencias de mejora, por favor:
- Abre un Issue en el repositorio
- Describe detalladamente el problema
- Incluye capturas de pantalla si es posible

### 📚 Documentación Adicional

Para más información sobre la estructura de la base de datos, consulta:
- 📄 [README_DATABASE.md](README_DATABASE.md) - Documentación detallada de la base de datos

---

<div align="center">

### 💙 Desarrollado con amor para el Consultorio Reynoso

**¿Preguntas o Sugerencias?**  
No dudes en contactar al equipo de desarrollo

---

⭐ Si este proyecto te resulta útil, considera darle una estrella en GitHub

</div>

---

## 📅 Información del Proyecto

| | |
|:---|:---|
| 📆 **Última actualización** | Enero 2026 |
| 🏷️ **Versión** | 1.0.0 |
| 📜 **Licencia** | Por definir |
| 🏢 **Organización** | Consultorio Reynoso |

---

<div align="center">

**[⬆️ Volver arriba](#-centro-médico---sistema-de-gestión-de-consultorio)**

</div>

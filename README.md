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

### 👥 Gestión de Pacientes

| Característica | Descripción | Estado |
|:--------------|:-----------|:-----:|
| **Registro de Pacientes** | Formulario completo con validaciones para crear nuevos expedientes | ✅ |
| **Edición de Datos** | Actualización de información del paciente con validación en tiempo real | ✅ |
| **Búsqueda Inteligente** | Sistema de búsqueda por nombre del paciente | ✅ |
| **Eliminación Segura** | Eliminación con confirmación de pacientes y sus registros relacionados | ✅ |
| **Vista Detallada** | Panel completo con toda la información clínica del paciente | ✅ |

### 📋 Información del Paciente

- **Datos Básicos**: Nombre completo, fecha de nacimiento, edad (años y meses)
- **Datos Médicos**: Tipo de paciente, grupo sanguíneo y Rh, puntuación APGAR
- **Mediciones**: Peso, altura, perímetro cefálico
- **Signos Vitales**: Temperatura, frecuencia cardíaca, frecuencia respiratoria
- **Historial**: Antecedentes de importancia y consultas previas

### 🎨 Interfaz de Usuario

| Componente | Características | Tecnología |
|:-----------|:---------------|:-----------|
| **Diseño Moderno** | Interfaz limpia con esquema de colores azul profesional | WPF + XAML |
| **Modales Personalizados** | Ventanas flotantes sin bordes con animaciones suaves | Custom Window Templates |
| **Validación en Tiempo Real** | Feedback inmediato en formularios (campos obligatorios, formatos) | Event Handlers |
| **Búsqueda Dinámica** | Filtrado instantáneo de pacientes mientras se escribe | TextChanged Events |
| **Responsive Design** | Layouts adaptativos con Grid y StackPanel | WPF Layout System |

### 🔧 Funcionalidades Técnicas

- **Actualización Automática**: Las vistas se actualizan automáticamente después de crear o editar pacientes usando eventos
- **Conversión Automática**: Los nombres se convierten a mayúsculas automáticamente
- **Validación de Entrada**: Solo números en campos numéricos, validación de formatos
- **Cálculo de Edad**: Cálculo automático de edad en años y meses desde la fecha de nacimiento
- **Historial Ordenado**: Las consultas se muestran en orden cronológico descendente

### 💾 Base de Datos

- **ORM**: Entity Framework Core para gestión de datos
- **SQLite**: Base de datos local sin necesidad de servidor
- **Migraciones**: Sistema de migraciones para actualizar esquema
- **Relaciones**: Relaciones uno a muchos entre pacientes, consultas e historiales

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
├── 📂 CentroMedico/                    # Proyecto principal de la aplicación
│   ├── 📂 database/                    # Contexto y scripts de base de datos
│   │   ├── ConsultorioContext.cs       # 🔧 Contexto de Entity Framework
│   │   └── campos_agregados.sql        # 📝 Script de actualización de BD
│   ├── 📂 models/                      # Modelos de datos (Entities)
│   │   ├── patientModel.cs             # 👤 Modelo de paciente
│   │   ├── consulationModel.cs         # 📋 Modelo de consulta
│   │   └── historyModel.cs             # 📜 Modelo de historial médico
│   ├── 📂 viewers/                     # Vistas de la aplicación (UI)
│   │   ├── PrincipalViewer.xaml        # 🏠 Vista principal - Lista de pacientes
│   │   ├── PrincipalViewer.xaml.cs     # 🔧 Lógica de vista principal
│   │   ├── CreatePatientViewer.xaml    # ➕ Modal para crear paciente
│   │   ├── CreatePatientViewer.xaml.cs # 🔧 Lógica de creación
│   │   ├── UpdatePatientViewer.xaml    # ✏️ Modal para editar paciente
│   │   ├── UpdatePatientViewer.xaml.cs # 🔧 Lógica de actualización
│   │   ├── DetailsViewer.xaml          # 📊 Vista de detalles del paciente
│   │   └── DetailsViewer.xaml.cs       # 🔧 Lógica de vista de detalles
│   ├── 📄 App.xaml                     # ⚙️ Configuración de la aplicación
│   ├── 📄 App.xaml.cs                  # 🔧 Lógica de aplicación
│   ├── 📄 MainWindow.xaml              # 🪟 Ventana principal
│   ├── 📄 MainWindow.xaml.cs           # 🔧 Lógica ventana principal
│   ├── 📄 AssemblyInfo.cs              # ℹ️ Información del ensamblado
│   └── 📄 CentroMedico.csproj          # 📦 Archivo del proyecto
├── 📂 ConsoleTest/                     # Proyecto de pruebas de consola
│   ├── Program.cs                      # 🧪 Pruebas y testing
│   └── ConsoleTest.csproj              # 📦 Proyecto de pruebas
├── 📄 CentroMedico.sln                 # 🎯 Solución de Visual Studio
├── 📄 README.md                        # 📖 Documentación principal
└── 📄 README_DATABASE.md               # 📊 Documentación de base de datos
```

### 🎨 Componentes de la UI

| Archivo | Propósito | Características |
|:--------|:----------|:----------------|
| **PrincipalViewer** | Vista principal de la app | Lista de pacientes, búsqueda, navegación |
| **CreatePatientViewer** | Modal de registro | Formulario completo, validaciones, ComboBox para Apgar |
| **UpdatePatientViewer** | Modal de edición | Pre-carga de datos, actualización reactiva |
| **DetailsViewer** | Vista de detalles | Información completa, historial, antecedentes |

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

| Campo | Tipo | Descripción | Validación |
|:------|:-----|:------------|:-----------|
| `id` | `int` | 🔑 Identificador único (Clave primaria, auto-incremental) | Requerido |
| `name` | `string` | 📝 Nombre completo del paciente (Mayúsculas automáticas) | Requerido |
| `age` | `int` | 🎂 Edad del paciente en años completos | Auto-calculado |
| `age_mounth` | `int` | 📅 Meses adicionales de edad | Auto-calculado |
| `type_patient` | `string` | 🏷️ Tipo de paciente (General, Pediátrico, etc.) | Default: "General" |
| `weight` | `float` | ⚖️ Peso del paciente en kilogramos | Numérico |
| `height` | `float` | 📏 Altura del paciente en centímetros | Numérico |
| `total_consulation` | `int` | 📋 Total de consultas realizadas | Auto-calculado |
| `birthdate` | `DateTime` | 🎂 Fecha de nacimiento | Requerido |
| `apgar` | `string` | 👶 Puntuación APGAR (formato: "X de Y") | ComboBox (0-10 o "-") |
| `blood_type` | `string` | 🩸 Tipo de sangre y factor Rh | ComboBox (A+, A-, B+, B-, AB+, AB-, O+, O-, Por definir) |
| `ultimateDate` | `DateOnly?` | 📅 Fecha de última consulta (No mapeado) | Calculado |

### 📋 Modelo de Consulta (`consulationModel`)

| Campo | Tipo | Descripción |
|:------|:-----|:------------|
| `id` | `int` | 🔑 Identificador único |
| `patient_id` | `int` | 🔗 Referencia al paciente (Foreign Key) |
| `date` | `DateTime` | 📅 Fecha de la consulta |
| `type_consultation` | `string` | 📝 Tipo de consulta |
| `weight` | `float` | ⚖️ Peso registrado en la consulta |
| `height` | `float` | 📏 Altura registrada en la consulta |
| `pc` | `float` | 📏 Perímetro cefálico (cm) |
| `temperature` | `float` | 🌡️ Temperatura corporal (°C) |
| `heart_rate` | `int` | ❤️ Frecuencia cardíaca (lpm) |
| `respiratory_rate` | `int` | 🫁 Frecuencia respiratoria (rpm) |

### 📜 Modelo de Historial (`historyModel`)

| Campo | Tipo | Descripción |
|:------|:-----|:------------|
| `id` | `int` | 🔑 Identificador único |
| `patient_id` | `int` | 🔗 Referencia al paciente (Foreign Key) |
| `name` | `string` | 📝 Nombre del paciente |
| `type_history` | `string` | 🏷️ Tipo de antecedente |
| `history` | `string` | 📋 Descripción del antecedente médico |

### 🔗 Relaciones entre Modelos

```
patientModel (1) ──┬── (N) consulationModel
                   │
                   └── (N) historyModel
```

Cada paciente puede tener múltiples consultas y múltiples registros de historial.

---

## 🎮 Uso

### 🏠 Vista Principal (PrincipalViewer)

La vista principal muestra la lista completa de pacientes registrados con opciones de gestión.

#### Características:
- **📋 Lista de Pacientes**: Tarjetas con información resumida de cada paciente
  - Avatar con inicial del nombre
  - Nombre completo
  - Total de consultas realizadas
  - Fecha de última visita
  
- **🔍 Búsqueda en Tiempo Real**: Cuadro de búsqueda que filtra pacientes mientras escribes
  
- **➕ Botón "Nuevo Paciente"**: Abre el modal de registro

- **👆 Doble Clic**: En cualquier paciente abre su vista de detalles

### ➕ Crear Nuevo Paciente (CreatePatientViewer)

Modal flotante para registrar un nuevo paciente en el sistema.

#### Campos del Formulario:

| Sección | Campos | Formato |
|:--------|:-------|:--------|
| **Información Personal** | • Nombre Completo (Mayúsculas automáticas)<br>• Tipo de Paciente (General por defecto) | Obligatorio<br>Opcional |
| **Datos de Nacimiento** | • Fecha de Nacimiento<br>• Grupo y Rh (ComboBox) | Obligatorio<br>ComboBox con 8 opciones + "Por definir" |
| **Mediciones Iniciales** | • Peso (kg)<br>• Altura (cm)<br>• Apgar (1' / 5') | Numérico obligatorio<br>Numérico obligatorio<br>ComboBox (0-10 o "-") |
| **Historial** | • Antecedentes de Importancia | TextArea multilínea opcional |

#### Validaciones:
- ✅ Nombre completo es obligatorio
- ✅ Peso y altura son obligatorios y solo números
- ✅ Fecha de nacimiento es obligatoria
- ✅ Conversión automática de nombre a mayúsculas

#### Acciones:
- **Guardar Paciente**: Crea el registro y actualiza la lista principal automáticamente
- **Cancelar**: Cierra el modal sin guardar

### ✏️ Editar Paciente (UpdatePatientViewer)

Modal para actualizar información de un paciente existente.

#### Características:
- **Pre-carga de Datos**: Todos los campos se llenan con la información actual del paciente
- **Campos Editables**:
  - Nombre completo
  - Tipo de paciente
  - Fecha de nacimiento
  - Grupo sanguíneo (ComboBox)
  - Apgar (ComboBox con valores de 0-10)

#### Funcionalidad Especial:
- **Actualización Reactiva**: Después de guardar, la vista de detalles se actualiza automáticamente mediante eventos
- **Sincronización con Base de Datos**: Los cambios se reflejan inmediatamente

### 📊 Vista de Detalles (DetailsViewer)

Vista completa con toda la información clínica del paciente.

#### Secciones:

**1️⃣ Encabezado del Paciente**
- Nombre completo en grande
- Edad detallada (años y meses)
- Fecha de nacimiento
- Último peso y altura registrados

**2️⃣ Panel Informativo Azul**
- 🏷️ Tipo de Paciente
- 👶 Puntuación APGAR
- 🩸 Tipo de Sangre

**3️⃣ Antecedentes de Importancia**
- Lista de antecedentes médicos
- Tipo de antecedente destacado
- Descripción completa
- Mensaje "No hay antecedentes" si está vacío

**4️⃣ Historial de Consultas**
- Fecha de cada consulta
- Tipo de consulta
- Signos vitales registrados:
  - Peso (kg)
  - Talla (cm)
  - Perímetro Cefálico (cm)
  - Temperatura (°C)
  - Frecuencia Cardíaca (lpm)
  - Frecuencia Respiratoria (rpm)

#### Botones de Acción:
- **✏️ Editar**: Abre modal de edición
- **🗑️ Eliminar**: Elimina paciente con confirmación
- **➕ Agregar Nota de Evolución**: (Próximamente)
- **← Regresar**: Vuelve a la lista principal

### 🎨 Elementos de Diseño

```
┌─────────────────────────────────────────┐
│  🏥 Consultorio Dra. Reynoso           │ ← Header azul (#2563EB)
├─────────────────────────────────────────┤
│                                         │
│  [🔍 Buscar...]  [➕ Nuevo Paciente]   │
│                                         │
│  ┌─────────────────────────────────┐   │
│  │ 👤  Juan Pérez García           │   │ ← Tarjetas de pacientes
│  │     Total Consultas: 5          │   │   con hover azul
│  │     Última Visita: 15/01/2026   │→  │
│  └─────────────────────────────────┘   │
│                                         │
│  ┌─────────────────────────────────┐   │
│  │ 👤  María López Rodríguez       │   │
│  │     Total Consultas: 3          │   │
│  │     Última Visita: 10/01/2026   │→  │
│  └─────────────────────────────────┘   │
│                                         │
└─────────────────────────────────────────┘
```

### ⌨️ Atajos y Controles

| Acción | Control |
|:-------|:--------|
| Abrir detalles de paciente | Doble clic en tarjeta |
| Cerrar modales | Botón X o Cancelar |
| Buscar paciente | Escribir en cuadro de búsqueda |
| Guardar formulario | Click en botón azul "Guardar" |

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

### 🏗️ Arquitectura del Proyecto

El proyecto sigue una arquitectura en capas con separación de responsabilidades:

- **UI Layer (Views)**: Archivos XAML con diseño de interfaz
- **Code-Behind**: Archivos .cs con lógica de presentación
- **Data Layer (Models)**: Entidades de base de datos
- **Database Layer**: Context de Entity Framework

### 🎨 Patrones de Diseño Implementados

| Patrón | Uso | Beneficio |
|:-------|:----|:----------|
| **Event-Driven** | Eventos para actualización de vistas | Desacoplamiento entre componentes |
| **Repository** | ConsultorioContext como repositorio | Abstracción de acceso a datos |
| **MVVM parcial** | Separación UI y lógica en Code-Behind | Mantenibilidad del código |

### 🔄 Sistema de Eventos

```csharp
// Ejemplo de evento implementado
public event EventHandler PatientUpdated;
public event EventHandler PatientCreated;

// Suscripción al evento
updateModal.PatientUpdated += (s, args) => {
    ReloadPatientData();
    LoadVisualDesign();
};
```

### 🎯 Validaciones Implementadas

**En CreatePatientViewer:**
- Nombre completo (obligatorio)
- Peso en kg (obligatorio, solo números)
- Altura en cm (obligatorio, solo números)
- Fecha de nacimiento (obligatoria)

**En UpdatePatientViewer:**
- Nombre completo (obligatorio)
- Fecha de nacimiento (obligatoria)

**Validación en Tiempo Real:**
- Conversión automática a mayúsculas en campos de nombre
- Restricción de caracteres en campos numéricos
- Prevención de entrada de letras en campos de peso/altura

### 💡 Características Técnicas Destacadas

1. **ComboBox Personalizados**: 
   - Grupo sanguíneo con 8 opciones + "Por definir"
   - APGAR con valores 0-10 + "-" como predeterminado
   - Styling personalizado con bordes redondeados

2. **Auto-actualización de Vistas**:
   - Uso de eventos `PatientCreated` y `PatientUpdated`
   - Recarga automática de datos desde base de datos
   - Sincronización entre vistas principal y detalles

3. **Búsqueda Dinámica**:
   - Filtrado en tiempo real con LINQ
   - Búsqueda case-insensitive
   - Actualización instantánea de la lista

4. **Modales Sin Bordes**:
   - WindowStyle="None" para diseño personalizado
   - AllowsTransparency="True" para efectos visuales
   - DropShadowEffect para profundidad

### 🔒 Seguridad

- ✅ La base de datos se almacena localmente en el equipo del usuario
- ✅ No se requiere conexión a Internet para el funcionamiento básico
- ✅ Validación de entrada para prevenir datos incorrectos
- ⚠️ Se recomienda realizar copias de seguridad periódicas de la base de datos
- 📍 Ubicación de BD: `%LocalAppData%\consultorio_reynoso.db`

### 🐛 Manejo de Errores

El sistema implementa try-catch en operaciones críticas:
- Operaciones de base de datos
- Carga de vistas
- Eliminación de registros
- Actualización de datos

Mensajes de error informativos con `MessageBox.Show()` para feedback al usuario.

### 🚀 Mejoras Futuras Planeadas

- [ ] Módulo de generación de reportes PDF
- [ ] Sistema de respaldo automático de base de datos
- [ ] Gráficas de crecimiento para pacientes pediátricos
- [ ] Funcionalidad "Agregar Nota de Evolución"
- [ ] Sistema de recordatorios de citas
- [ ] Exportación de datos a Excel
- [ ] Impresión de recetas médicas
- [ ] Dashboard con estadísticas del consultorio

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
| 🛠️ **Framework** | .NET 8.0 / WPF |
| 🗄️ **Base de Datos** | SQLite con Entity Framework Core 8.0.11 |
| 🎨 **UI Framework** | Windows Presentation Foundation (WPF) |
| 💻 **Lenguaje** | C# 12 |

### 📈 Estado del Proyecto

| Módulo | Estado | Progreso |
|:-------|:-------|:---------|
| Gestión de Pacientes | ✅ Completo | 100% |
| Creación de Pacientes | ✅ Completo | 100% |
| Edición de Pacientes | ✅ Completo | 100% |
| Vista de Detalles | ✅ Completo | 100% |
| Búsqueda de Pacientes | ✅ Completo | 100% |
| Base de Datos | ✅ Funcional | 100% |
| Gestión de Consultas | 🚧 En desarrollo | 50% |
| Reportes | ⏳ Pendiente | 0% |

### 🎯 Hitos Completados

- ✅ Configuración inicial del proyecto
- ✅ Diseño de base de datos con Entity Framework
- ✅ Implementación de modelos de datos
- ✅ Vista principal con lista de pacientes
- ✅ Modal de creación de pacientes con validaciones
- ✅ Modal de edición de pacientes
- ✅ Vista detallada de paciente
- ✅ Sistema de búsqueda en tiempo real
- ✅ Eventos para actualización automática de vistas
- ✅ Eliminación de pacientes con confirmación
- ✅ Panel informativo con datos médicos clave
- ✅ Sistema de historial de consultas (visualización)

---

<div align="center">

**[⬆️ Volver arriba](#-centro-médico---sistema-de-gestión-de-consultorio)**

</div>

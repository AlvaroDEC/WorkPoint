# WorkPoint - Sistema de Gestión de Inspecciones

## Descripción
WorkPoint es una aplicación web ASP.NET Core para la gestión de inspecciones, observaciones y evidencias en el contexto de un sistema de gestión de calidad.

## Características Actuales
- ✅ Gestión de usuarios y roles
- ✅ Gestión de áreas y criterios de gravedad
- ✅ Creación y seguimiento de inspecciones
- ✅ Gestión de observaciones y evidencias
- ✅ API RESTful con documentación OpenAPI
- ✅ AutoMapper para mapeo de objetos
- ✅ Entity Framework Core con PostgreSQL

## Tecnologías Utilizadas
- **.NET 9.0** - Framework de desarrollo
- **Entity Framework Core** - ORM para acceso a datos
- **PostgreSQL** - Base de datos
- **AutoMapper** - Mapeo de objetos
- **ASP.NET Core Web API** - Framework web

## Requisitos Previos
- .NET 9.0 SDK
- PostgreSQL 12+
- Visual Studio 2022 o VS Code

## Instalación

### 1. Clonar el repositorio
```bash
git clone <repository-url>
cd WorkPoint
```

### 2. Configurar la base de datos
Editar `appsettings.json` y configurar la cadena de conexión:
```json
{
  "ConnectionStrings": {
    "LocalHostConnection": "Host=127.0.0.1;Database=BackendBPM;Port=5432;Username=postgres;Password=MiClave;Persist Security Info=true;Pooling=true;"
  }
}
```

### 3. Restaurar dependencias
```bash
dotnet restore
```

### 4. Ejecutar migraciones
```bash
dotnet ef database update
```

### 5. Ejecutar la aplicación
```bash
dotnet run
```

La aplicación estará disponible en `https://localhost:7001`

## Estructura del Proyecto

```
WorkPoint/
├── Controller/          # Controladores API
│   ├── AreaController.cs
│   ├── CriterioController.cs
│   ├── EvidenciaController.cs
│   ├── InspeccionController.cs
│   ├── ObservacionController.cs
│   ├── RolController.cs
│   └── UsuarioController.cs
├── Data/               # Contexto de Entity Framework
│   └── AppContexts.cs
├── DTOs/               # Objetos de transferencia de datos
│   ├── Areas/
│   ├── CriteriosDeGravedad/
│   ├── Evidencias/
│   ├── Inspecciones/
│   ├── Observaciones/
│   ├── Roles/
│   └── Usuarios/
├── Mapping/            # Configuración de AutoMapper
│   └── MappingProfile.cs
├── Migrations/         # Migraciones de Entity Framework
├── Models/             # Entidades del dominio
│   ├── AccionCorrectiva.cs
│   ├── Area.cs
│   ├── Bitacora.cs
│   ├── CriteriosDeGravedad.cs
│   ├── Evidencia.cs
│   ├── Inspeccion.cs
│   ├── Observacion.cs
│   ├── Rol.cs
│   └── Usuario.cs
├── Services/           # Lógica de negocio
│   ├── Interfaces/     # Contratos de servicios
│   │   ├── IAreaService.cs
│   │   ├── ICriterioService.cs
│   │   ├── IInspeccionService.cs
│   │   ├── IObservacionService.cs
│   │   ├── IRolService.cs
│   │   └── IUsuarioService.cs
│   └── Implementations/ # Implementaciones de servicios
│       ├── AreaService.cs
│       ├── CriteriosService.cs
│       ├── InspeccionService.cs
│       ├── ObservacionService.cs
│       ├── RolService.cs
│       └── UsuarioService.cs
└── wwwroot/            # Archivos estáticos
    └── Evidencias/     # Imágenes subidas
```

## API Endpoints

### Usuarios (`/api/Usuario`)
- `POST` - Crear usuario
- `GET` - Obtener todos los usuarios
- `GET /{id}` - Obtener usuario por ID
- `PATCH /{id}` - Actualizar usuario parcialmente

### Áreas (`/api/Area`)
- `POST` - Crear área
- `GET` - Obtener todas las áreas
- `GET /{id}` - Obtener área por ID
- `PATCH` - Actualizar área
- `DELETE /{id}` - Eliminar área

### Roles (`/api/Rol`)
- `POST` - Crear rol
- `GET` - Obtener todos los roles
- `GET /{id}` - Obtener rol por ID
- `PUT` - Actualizar rol
- `DELETE /{id}` - Eliminar rol

### Criterios de Gravedad (`/api/Criterio`)
- `POST` - Crear criterio
- `GET` - Obtener todos los criterios
- `GET /{id}` - Obtener criterio por ID
- `PUT` - Actualizar criterio
- `DELETE /{id}` - Eliminar criterio
- `PATCH /descripcion/{id}` - Actualizar descripción

### Inspecciones (`/api/Inspeccion`)
- `POST` - Crear inspección con observaciones
- `GET` - Obtener todas las inspecciones
- `GET /{id}` - Obtener inspección por ID
- `PATCH` - Actualizar inspección

### Observaciones (`/api/Observacion`)
- `PATCH` - Actualizar observación parcialmente

### Evidencias (`/api/Evidencia`)
- `POST /upload` - Subir imagen de evidencia

## Modelos de Datos

### Usuario
- `Id` (int, PK)
- `NombreCompleto` (string, required)
- `Correo` (string, required)
- `Contraseña` (string, required)
- `Estado` (bool, default: true)
- `RolId` (int, FK)

### Área
- `Id` (int, PK)
- `Nombre` (string, required)
- `Codigo` (string, required)

### Rol
- `Id` (int, PK)
- `Nombre` (string, required)

### Inspección
- `Id` (int, PK)
- `Fecha` (DateTime)
- `AuditorId` (int, FK)
- `AreaId` (int, FK)
- `Estado` (string)

### Observación
- `Id` (int, PK)
- `Descripcion` (string, required)
- `CriterioDeGravedadId` (int, FK)
- `Estado` (string)
- `FechaCreacion` (DateTime)
- `InspeccionId` (int, FK)
- `ResponsableId` (int, FK)

### Evidencia
- `Id` (int, PK)
- `RutaImagen` (string)
- `ObservacionId` (int, FK)

## Funcionalidades Principales

### Gestión de Usuarios
- Crear usuarios con roles asignados
- Listar usuarios con información de rol
- Actualizar información de usuario
- Consultar usuario por ID

### Gestión de Inspecciones
- Crear inspecciones con múltiples observaciones
- Asignar auditor y área
- Incluir evidencias en observaciones
- Seguimiento de estado de inspecciones

### Gestión de Observaciones
- Crear observaciones con criterios de gravedad
- Asignar responsables
- Actualizar estado de observaciones
- Adjuntar evidencias

### Subida de Archivos
- Subir imágenes como evidencias
- Almacenamiento en wwwroot/evidencias
- Generación de nombres únicos con GUID

## Configuración Actual

### Base de Datos
- **Proveedor**: PostgreSQL
- **Configuración**: En `appsettings.json`
- **Migraciones**: Entity Framework Core

### AutoMapper
- **Configuración**: `MappingProfile.cs`
- **Mapeos**: Entre modelos y DTOs

### Servicios
- **Patrón**: Repository con Entity Framework
- **Inyección**: Dependencias configuradas en `Program.cs`
- **Interfaces**: Separación de contratos e implementaciones

## Estado Actual del Proyecto

### ✅ Implementado
- CRUD completo para todas las entidades
- API RESTful funcional
- AutoMapper configurado
- Entity Framework con PostgreSQL
- Subida de archivos
- Relaciones entre entidades

### 🔄 En Desarrollo
- Validaciones de entrada
- Manejo de errores global
- Logging estructurado
- Seguridad mejorada

### 📋 Pendiente
- Autenticación y autorización
- Validaciones robustas
- Testing unitario
- Documentación de API mejorada
- Monitoreo y métricas

## Próximos Pasos

1. **Mejorar validaciones** en DTOs
2. **Implementar manejo global de errores**
3. **Agregar logging** estructurado
4. **Mejorar seguridad** (hashing de contraseñas)
5. **Implementar autenticación** JWT
6. **Agregar testing** unitario
7. **Mejorar documentación** de API

## Contribución
1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## Licencia
Este proyecto está bajo la Licencia MIT.

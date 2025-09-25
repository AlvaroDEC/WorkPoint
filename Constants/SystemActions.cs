namespace ClaseEntityFramework.Constants
{
    /// <summary>
    /// Constantes para las acciones del sistema
    /// </summary>
    public static class SystemActions
    {
        // Acciones de Usuarios
        public const string USUARIOS_CREAR = "USUARIOS_CREAR";
        public const string USUARIOS_EDITAR = "USUARIOS_EDITAR";
        public const string USUARIOS_ELIMINAR = "USUARIOS_ELIMINAR";
        public const string USUARIOS_VER = "USUARIOS_VER";

        // Acciones de Roles
        public const string ROLES_CREAR = "ROLES_CREAR";
        public const string ROLES_EDITAR = "ROLES_EDITAR";
        public const string ROLES_ELIMINAR = "ROLES_ELIMINAR";
        public const string ROLES_VER = "ROLES_VER";

        // Acciones de Inspecciones
        public const string INSPECCIONES_CREAR = "INSPECCIONES_CREAR";
        public const string INSPECCIONES_EDITAR = "INSPECCIONES_EDITAR";
        public const string INSPECCIONES_ELIMINAR = "INSPECCIONES_ELIMINAR";
        public const string INSPECCIONES_VER = "INSPECCIONES_VER";

        // Acciones de Observaciones
        public const string OBSERVACIONES_CREAR = "OBSERVACIONES_CREAR";
        public const string OBSERVACIONES_EDITAR = "OBSERVACIONES_EDITAR";
        public const string OBSERVACIONES_ELIMINAR = "OBSERVACIONES_ELIMINAR";
        public const string OBSERVACIONES_VER = "OBSERVACIONES_VER";

        // Acciones de Problemas
        public const string PROBLEMAS_CREAR = "PROBLEMAS_CREAR";
        public const string PROBLEMAS_EDITAR = "PROBLEMAS_EDITAR";
        public const string PROBLEMAS_ELIMINAR = "PROBLEMAS_ELIMINAR";
        public const string PROBLEMAS_VER = "PROBLEMAS_VER";

        // Acciones de Soluciones
        public const string SOLUCIONES_CREAR = "SOLUCIONES_CREAR";
        public const string SOLUCIONES_EDITAR = "SOLUCIONES_EDITAR";
        public const string SOLUCIONES_ELIMINAR = "SOLUCIONES_ELIMINAR";
        public const string SOLUCIONES_VER = "SOLUCIONES_VER";

        // Acciones de Seguimientos
        public const string SEGUIMIENTOS_CREAR = "SEGUIMIENTOS_CREAR";
        public const string SEGUIMIENTOS_EDITAR = "SEGUIMIENTOS_EDITAR";
        public const string SEGUIMIENTOS_ELIMINAR = "SEGUIMIENTOS_ELIMINAR";
        public const string SEGUIMIENTOS_VER = "SEGUIMIENTOS_VER";

        // Acciones de Evidencias
        public const string EVIDENCIAS_CREAR = "EVIDENCIAS_CREAR";
        public const string EVIDENCIAS_EDITAR = "EVIDENCIAS_EDITAR";
        public const string EVIDENCIAS_ELIMINAR = "EVIDENCIAS_ELIMINAR";
        public const string EVIDENCIAS_VER = "EVIDENCIAS_VER";

        // Acciones de Reportes y Dashboard
        public const string REPORTES_GENERAR = "REPORTES_GENERAR";
        public const string DASHBOARD_VER = "DASHBOARD_VER";

        // Acciones de Configuración
        public const string CONFIGURACION_VER = "CONFIGURACION_VER";
        public const string CONFIGURACION_EDITAR = "CONFIGURACION_EDITAR";

        /// <summary>
        /// Obtiene todas las acciones del sistema
        /// </summary>
        public static string[] GetAllActions()
        {
            return new[]
            {
                // Usuarios
                USUARIOS_CREAR, USUARIOS_EDITAR, USUARIOS_ELIMINAR, USUARIOS_VER,
                // Roles
                ROLES_CREAR, ROLES_EDITAR, ROLES_ELIMINAR, ROLES_VER,
                // Inspecciones
                INSPECCIONES_CREAR, INSPECCIONES_EDITAR, INSPECCIONES_ELIMINAR, INSPECCIONES_VER,
                // Observaciones
                OBSERVACIONES_CREAR, OBSERVACIONES_EDITAR, OBSERVACIONES_ELIMINAR, OBSERVACIONES_VER,
                // Problemas
                PROBLEMAS_CREAR, PROBLEMAS_EDITAR, PROBLEMAS_ELIMINAR, PROBLEMAS_VER,
                // Soluciones
                SOLUCIONES_CREAR, SOLUCIONES_EDITAR, SOLUCIONES_ELIMINAR, SOLUCIONES_VER,
                // Seguimientos
                SEGUIMIENTOS_CREAR, SEGUIMIENTOS_EDITAR, SEGUIMIENTOS_ELIMINAR, SEGUIMIENTOS_VER,
                // Evidencias
                EVIDENCIAS_CREAR, EVIDENCIAS_EDITAR, EVIDENCIAS_ELIMINAR, EVIDENCIAS_VER,
                // Reportes y Dashboard
                REPORTES_GENERAR, DASHBOARD_VER,
                // Configuración
                CONFIGURACION_VER, CONFIGURACION_EDITAR
            };
        }
    }
}

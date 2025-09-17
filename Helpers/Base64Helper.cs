using System.Text;

namespace ClaseEntityFramework.Helpers
{
    /// <summary>
    /// Helper para manejo de archivos Base64
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        /// Valida si una cadena es Base64 válida
        /// </summary>
        public static bool EsBase64Valido(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene el tipo MIME desde una cadena Base64
        /// </summary>
        public static string ObtenerTipoMime(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return "application/octet-stream";

            try
            {
                var bytes = Convert.FromBase64String(base64String);
                
                // Verificar magic numbers para tipos comunes
                if (bytes.Length >= 4)
                {
                    // JPEG
                    if (bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF)
                        return "image/jpeg";
                    
                    // PNG
                    if (bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47)
                        return "image/png";
                    
                    // GIF
                    if (bytes[0] == 0x47 && bytes[1] == 0x49 && bytes[2] == 0x46)
                        return "image/gif";
                }
                
                return "application/octet-stream";
            }
            catch
            {
                return "application/octet-stream";
            }
        }

        /// <summary>
        /// Calcula el tamaño en bytes de una cadena Base64
        /// </summary>
        public static long CalcularTamañoBytes(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return 0;

            try
            {
                var bytes = Convert.FromBase64String(base64String);
                return bytes.Length;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida el tamaño máximo de archivo (10MB por defecto)
        /// </summary>
        public static bool ValidarTamañoMaximo(string base64String, long tamañoMaximoBytes = 10485760)
        {
            var tamaño = CalcularTamañoBytes(base64String);
            return tamaño <= tamañoMaximoBytes;
        }
    }
}

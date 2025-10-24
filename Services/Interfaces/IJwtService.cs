using ClaseEntityFramework.Models;

namespace ClaseEntityFramework.Services.Interfaces
{
    /// <summary>
    /// Servicio para generar y validar tokens JWT
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Genera un token JWT para un usuario autenticado
        /// </summary>
        /// <param name="usuario">Usuario autenticado</param>
        /// <returns>Token JWT como string</returns>
        string GenerarToken(Usuario usuario);

        /// <summary>
        /// Obtiene la fecha de expiración del token
        /// </summary>
        /// <returns>Fecha y hora de expiración</returns>
        DateTime ObtenerFechaExpiracion();
    }
}


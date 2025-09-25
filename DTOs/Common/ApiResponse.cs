namespace ClaseEntityFramework.DTOs.Common
{
    /// <summary>
    /// Respuesta estándar de la API
    /// </summary>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public string? Error { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Operación exitosa")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorResponse(string error, string message = "Error en la operación")
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Error = error
            };
        }
    }

    /// <summary>
    /// Respuesta estándar sin datos
    /// </summary>
    public class ApiResponse : ApiResponse<object>
    {
        public static new ApiResponse SuccessResponse(string message = "Operación exitosa")
        {
            return new ApiResponse
            {
                Success = true,
                Message = message
            };
        }

        public static new ApiResponse ErrorResponse(string error, string message = "Error en la operación")
        {
            return new ApiResponse
            {
                Success = false,
                Message = message,
                Error = error
            };
        }
    }
}

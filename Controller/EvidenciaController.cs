using Microsoft.AspNetCore.Mvc;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvidenciaController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public EvidenciaController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> SubirImagen(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("No se proporcionó ninguna imagen");

            var carpeta = Path.Combine(_env.WebRootPath, "evidencias");
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);
            var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            var url = $"/evidencias/{nombreArchivo}"; // Esto lo usás en rutaImagen
            return Ok(new { ruta = url });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClaseEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using ClaseEntityFramework.Models;

namespace ClaseEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔒 Requiere autenticación JWT
    public class SetupController : ControllerBase
    {
        private readonly AppContexts _context;

        public SetupController(AppContexts context)
        {
            _context = context;
        }

        [HttpGet("check-data")]
        public async Task<IActionResult> CheckData()
        {
            try
            {
                var usuarios = await _context.Usuarios.Select(u => new { u.Id, u.NombreCompleto, u.RolId }).ToListAsync();
                var areas = await _context.Areas.Select(a => new { a.Id, a.Nombre }).ToListAsync();
                var criterios = await _context.CriteriosDeGravedad.Select(c => new { c.Id, c.Codigo, c.Descripcion }).ToListAsync();
                var estados = await _context.Estados.Select(e => new { e.Id, e.Nombre }).ToListAsync();
                var categorias = await _context.Categorias.Select(c => new { c.Id, c.Nombre }).ToListAsync();
                var roles = await _context.Roles.Select(r => new { r.Id, r.Nombre }).ToListAsync();

                return Ok(new
                {
                    success = true,
                    data = new
                    {
                        usuarios = usuarios,
                        areas = areas,
                        criterios = criterios,
                        estados = estados,
                        categorias = categorias,
                        roles = roles
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = false,
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                });
            }
        }

        [HttpPost("create-test-data")]
        public async Task<IActionResult> CreateTestData()
        {
            try
            {
                // Crear Rol si no existe
                var rolAdmin = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Admin");
                if (rolAdmin == null)
                {
                    rolAdmin = new ClaseEntityFramework.Models.Rol { Nombre = "Admin", Descripcion = "Administrador del sistema" };
                    _context.Roles.Add(rolAdmin);
                    await _context.SaveChangesAsync();
                }

                // Crear Usuarios de prueba si no existen
                var usuario1 = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == 1);
                if (usuario1 == null)
                {
                    usuario1 = new ClaseEntityFramework.Models.Usuario
                    {
                        NombreCompleto = "Usuario Admin",
                        Correo = "admin@test.com",
                        Contraseña = "password123",
                        RolId = rolAdmin.Id,
                        Estado = true
                    };
                    _context.Usuarios.Add(usuario1);
                    await _context.SaveChangesAsync();
                }

                var usuario3 = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == 3);
                if (usuario3 == null)
                {
                    usuario3 = new ClaseEntityFramework.Models.Usuario
                    {
                        NombreCompleto = "Auditor Test",
                        Correo = "auditor@test.com",
                        Contraseña = "password123",
                        RolId = rolAdmin.Id,
                        Estado = true
                    };
                    _context.Usuarios.Add(usuario3);
                    await _context.SaveChangesAsync();
                }

                var usuario5 = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == 5);
                if (usuario5 == null)
                {
                    usuario5 = new ClaseEntityFramework.Models.Usuario
                    {
                        NombreCompleto = "Responsable Test",
                        Correo = "responsable@test.com",
                        Contraseña = "password123",
                        RolId = rolAdmin.Id,
                        Estado = true
                    };
                    _context.Usuarios.Add(usuario5);
                    await _context.SaveChangesAsync();
                }

                // Crear Área si no existe
                var area1 = await _context.Areas.FirstOrDefaultAsync(a => a.Id == 1);
                if (area1 == null)
                {
                    area1 = new ClaseEntityFramework.Models.Area
                    {
                        Nombre = "Área Test",
                        Codigo = "AT001",
                        Descripcion = "Área de prueba",
                        Estado = true
                    };
                    _context.Areas.Add(area1);
                    await _context.SaveChangesAsync();
                }

                // Crear Criterio de Gravedad si no existe
                var criterio1 = await _context.CriteriosDeGravedad.FirstOrDefaultAsync(c => c.Id == 1);
                if (criterio1 == null)
                {
                    criterio1 = new ClaseEntityFramework.Models.CriterioDeGravedad
                    {
                        Codigo = "BAJO",
                        Descripcion = "Criterio de gravedad bajo"
                    };
                    _context.CriteriosDeGravedad.Add(criterio1);
                    await _context.SaveChangesAsync();
                }

                // Crear Categoría si no existe
                var categoria1 = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == 1);
                if (categoria1 == null)
                {
                    categoria1 = new ClaseEntityFramework.Models.Categoria
                    {
                        Nombre = "Categoría Test",
                        Descripcion = "Categoría de prueba"
                    };
                    _context.Categorias.Add(categoria1);
                    await _context.SaveChangesAsync();
                }

                // Crear Estado si no existe
                var estado1 = await _context.Estados.FirstOrDefaultAsync(e => e.Id == 1);
                if (estado1 == null)
                {
                    estado1 = new ClaseEntityFramework.Models.Estado
                    {
                        Nombre = "Pendiente",
                        Descripcion = "Estado pendiente"
                    };
                    _context.Estados.Add(estado1);
                    await _context.SaveChangesAsync();
                }


                return Ok(new
                {
                    success = true,
                    message = "Datos de prueba creados exitosamente",
                    data = new
                    {
                        usuario1Id = usuario1.Id,
                        usuario3Id = usuario3.Id,
                        usuario5Id = usuario5.Id,
                        area1Id = area1.Id,
                        criterio1Id = criterio1.Id,
                        categoria1Id = categoria1.Id,
                        estado1Id = estado1.Id
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = false,
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                });
            }
        }
    }
}
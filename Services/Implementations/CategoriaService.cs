using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Categorias;
using ClaseEntityFramework.DTOs.Common;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class CategoriaService : ICategoriaService
{
    private readonly AppContexts _context;
    private readonly IMapper _mapper;

    public CategoriaService(AppContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CrearCategoria(CreateCategoriaDto dto)
    {
        var categoria = _mapper.Map<Categoria>(dto);
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CategoriaDto>> ObtenerCategorias()
    {
        var categorias = await _context.Categorias.ToListAsync();
        return _mapper.Map<List<CategoriaDto>>(categorias);
    }

    public async Task<CategoriaDto> ObtenerPorId(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) throw new Exception("Categoría no encontrada");

        return _mapper.Map<CategoriaDto>(categoria);
    }

    public async Task ActualizarCategoria(UpdateCategoriaDto dto)
    {
        var categoria = await _context.Categorias.FindAsync(dto.Id);
        if (categoria == null)
            throw new Exception("Categoría no encontrada");

        _mapper.Map(dto, categoria);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) throw new Exception("Categoría no encontrada");

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResponse<CategoriaReporteDto>> ObtenerParaReportesAsync(int pageSize)
    {
        var categorias = await _context.Categorias
            .OrderBy(c => c.Nombre)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _context.Categorias.CountAsync();

        var categoriasDto = categorias.Select(c => new CategoriaReporteDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,
            Activo = c.Activo
        }).ToList();

        return new PagedResponse<CategoriaReporteDto>
        {
            Success = true,
            Data = categoriasDto,
            TotalCount = totalCount,
            PageNumber = 1,
            PageSize = pageSize
        };
    }
}
}

using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Areas;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class AreaService : IAreaService
{
    private readonly AppContexts _context;
    private readonly IMapper _mapper;

    public AreaService(AppContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CrearArea(CreateAreaDto dto)
    {
        var area = _mapper.Map<Area>(dto);
        _context.Areas.Add(area);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AreaDto>> ObtenerAreas()
    {
        var areas = await _context.Areas.ToListAsync();
        return _mapper.Map<List<AreaDto>>(areas);
    }

    public async Task<AreaDto> ObtenerPorId(int id)
    {
        var area = await _context.Areas.FindAsync(id);
        if (area == null) throw new Exception("Área no encontrada");

        return _mapper.Map<AreaDto>(area);
    }

    public async Task ActualizarArea(UpdateAreaDto dto)
    {
        var area = await _context.Areas.FindAsync(dto.Id);
        if (area == null)
            throw new Exception("Área no encontrada");

        _mapper.Map(dto, area);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarArea(int id)
    {
        var area = await _context.Areas.FindAsync(id);
        if (area == null) throw new Exception("Área no encontrada");

        _context.Areas.Remove(area);
        await _context.SaveChangesAsync();
    }
}
}

using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Estados;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class EstadoService : IEstadoService
{
    private readonly AppContexts _context;
    private readonly IMapper _mapper;

    public EstadoService(AppContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CrearEstado(CreateEstadoDto dto)
    {
        var estado = _mapper.Map<Estado>(dto);
        _context.Estados.Add(estado);
        await _context.SaveChangesAsync();
    }

    public async Task<List<EstadoDto>> ObtenerEstados()
    {
        var estados = await _context.Estados.ToListAsync();
        return _mapper.Map<List<EstadoDto>>(estados);
    }

    public async Task<EstadoDto> ObtenerPorId(int id)
    {
        var estado = await _context.Estados.FindAsync(id);
        if (estado == null) throw new Exception("Estado no encontrado");

        return _mapper.Map<EstadoDto>(estado);
    }

    public async Task ActualizarEstado(UpdateEstadoDto dto)
    {
        var estado = await _context.Estados.FindAsync(dto.Id);
        if (estado == null)
            throw new Exception("Estado no encontrado");

        _mapper.Map(dto, estado);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarEstado(int id)
    {
        var estado = await _context.Estados.FindAsync(id);
        if (estado == null) throw new Exception("Estado no encontrado");

        _context.Estados.Remove(estado);
        await _context.SaveChangesAsync();
    }
}
}

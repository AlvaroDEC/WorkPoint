using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Acciones;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class AccionService : IAccionService
{
    private readonly AppContexts _context;
    private readonly IMapper _mapper;

    public AccionService(AppContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CrearAccion(CreateAccionDto dto)
    {
        var accion = _mapper.Map<Accion>(dto);
        _context.Acciones.Add(accion);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AccionDto>> ObtenerAcciones()
    {
        var acciones = await _context.Acciones.ToListAsync();
        return _mapper.Map<List<AccionDto>>(acciones);
    }

    public async Task<AccionDto> ObtenerPorId(int id)
    {
        var accion = await _context.Acciones.FindAsync(id);
        if (accion == null) throw new Exception("Acción no encontrada");

        return _mapper.Map<AccionDto>(accion);
    }

    public async Task ActualizarAccion(UpdateAccionDto dto)
    {
        var accion = await _context.Acciones.FindAsync(dto.Id);
        if (accion == null)
            throw new Exception("Acción no encontrada");

        _mapper.Map(dto, accion);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAccion(int id)
    {
        var accion = await _context.Acciones.FindAsync(id);
        if (accion == null) throw new Exception("Acción no encontrada");

        _context.Acciones.Remove(accion);
        await _context.SaveChangesAsync();
    }
}
}

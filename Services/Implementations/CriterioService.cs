using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.CriteriosDeGravedad;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class CriterioService : ICriterioService
{
    private readonly AppContexts _context;
    private readonly IMapper _mapper;

    public CriterioService(AppContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CrearCriterio(CreateCriterioDto dto)
    {
        var criterio = _mapper.Map<CriterioDeGravedad>(dto);
        _context.CriteriosDeGravedad.Add(criterio);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CriterioDto>> ObtenerCriterios()
    {
        var criterios = await _context.CriteriosDeGravedad.ToListAsync();
        return _mapper.Map<List<CriterioDto>>(criterios);
    }

    public async Task<CriterioDto> ObtenerPorId(int id)
    {
        var criterio = await _context.CriteriosDeGravedad.FindAsync(id);
        if (criterio == null) throw new Exception("Criterio no encontrado");

        return _mapper.Map<CriterioDto>(criterio);
    }

    public async Task ActualizarCriterio(UpdateCriterioDto dto)
    {
        var criterio = await _context.CriteriosDeGravedad.FindAsync(dto.Id);
        if (criterio == null)
            throw new Exception("Criterio no encontrado");

        _mapper.Map(dto, criterio);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarCriterio(int id)
    {
        var criterio = await _context.CriteriosDeGravedad.FindAsync(id);
        if (criterio == null) throw new Exception("Criterio no encontrado");

        _context.CriteriosDeGravedad.Remove(criterio);
        await _context.SaveChangesAsync();
    }
}
}

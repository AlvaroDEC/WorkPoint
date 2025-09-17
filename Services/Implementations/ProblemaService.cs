using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Problemas;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class ProblemaService : IProblemaService
{
    private readonly AppContexts _context;
    private readonly IMapper _mapper;

    public ProblemaService(AppContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CrearProblema(CreateProblemaDto dto)
    {
        var problema = _mapper.Map<Problema>(dto);
        _context.Problemas.Add(problema);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ProblemaDto>> ObtenerProblemas()
    {
        var problemas = await _context.Problemas.ToListAsync();
        return _mapper.Map<List<ProblemaDto>>(problemas);
    }

    public async Task<ProblemaDto> ObtenerPorId(int id)
    {
        var problema = await _context.Problemas.FindAsync(id);
        if (problema == null) throw new Exception("Problema no encontrado");

        return _mapper.Map<ProblemaDto>(problema);
    }

    public async Task ActualizarProblema(UpdateProblemaDto dto)
    {
        var problema = await _context.Problemas.FindAsync(dto.Id);
        if (problema == null)
            throw new Exception("Problema no encontrado");

        _mapper.Map(dto, problema);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarProblema(int id)
    {
        var problema = await _context.Problemas.FindAsync(id);
        if (problema == null) throw new Exception("Problema no encontrado");

        _context.Problemas.Remove(problema);
        await _context.SaveChangesAsync();
    }
}
}

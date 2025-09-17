using AutoMapper;
using ClaseEntityFramework.Data;
using ClaseEntityFramework.DTOs.Seguimientos;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework.Services.Implementations
{
    public class SeguimientoService : ISeguimientoService
    {
        private readonly AppContexts _context;
        private readonly IMapper _mapper;

        public SeguimientoService(AppContexts context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CrearSeguimiento(CreateSeguimientoDto dto)
        {
            var seguimiento = _mapper.Map<Seguimiento>(dto);
            _context.Seguimientos.Add(seguimiento);
            await _context.SaveChangesAsync();
        }
    }
}

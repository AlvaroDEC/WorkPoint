using AutoMapper;
using ClaseEntityFramework.Models;
using ClaseEntityFramework.DTOs.Usuarios;
using ClaseEntityFramework.DTOs.Inspecciones;
using ClaseEntityFramework.DTOs.Observaciones;
using ClaseEntityFramework.DTOs.Evidencias;
using ClaseEntityFramework.DTOs.Areas;
using ClaseEntityFramework.DTOs.Categorias;
using ClaseEntityFramework.DTOs.CriteriosDeGravedad;
using ClaseEntityFramework.DTOs.Estados;
using ClaseEntityFramework.DTOs.Problemas;
using ClaseEntityFramework.DTOs.Acciones;
using ClaseEntityFramework.DTOs.Roles;
using ClaseEntityFramework.DTOs.Soluciones;
using ClaseEntityFramework.DTOs.Sugerencias;
using ClaseEntityFramework.DTOs.Asignaciones;
using ClaseEntityFramework.DTOs.AsignacionRoles;
using ClaseEntityFramework.DTOs.Seguimientos;
using ClaseEntityFramework.DTOs.Permisos;
using ClaseEntityFramework.DTOs.EvidenciasSolucion;
using ClaseEntityFramework.DTOs.Auth;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeos para la tabla "Usuario"
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>()
            .ForMember(dest => dest.Estado, opt => opt.Ignore()) 
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        // Mapeos para la tabla "Inspeccion"
        CreateMap<Inspeccion, InspeccionCompletaDto>().ReverseMap();
        CreateMap<CreateInspeccionDto, Inspeccion>();
        CreateMap<Inspeccion, InspeccionListaDto>();
        CreateMap<PatchInspeccionDto, Inspeccion>();

        // Mapeos para la tabla "Observacion"
        CreateMap<Observacion, PatchObservacionDto>().ReverseMap();

        // Mapeos para la tabla "Evidencia"
        CreateMap<Evidencia, PatchEvidenciaDto>().ReverseMap();

        // Mapeos para la tabla "Categoria"
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<UpdateCategoriaDto, Categoria>();

        // Mapeos para la tabla "CriterioDeGravedad"
        CreateMap<CriterioDeGravedad, CriterioDto>().ReverseMap();
        CreateMap<CreateCriterioDto, CriterioDeGravedad>();
        CreateMap<UpdateCriterioDto, CriterioDeGravedad>();

        // Mapeos para la tabla "Estado"
        CreateMap<Estado, EstadoDto>().ReverseMap();
        CreateMap<CreateEstadoDto, Estado>();
        CreateMap<UpdateEstadoDto, Estado>();

        // Mapeos para la tabla "Problema"
        CreateMap<Problema, ProblemaDto>().ReverseMap();
        CreateMap<CreateProblemaDto, Problema>();
        CreateMap<UpdateProblemaDto, Problema>();

        // Mapeos para la tabla "Accion"
        CreateMap<Accion, AccionDto>().ReverseMap();
        CreateMap<CreateAccionDto, Accion>();
        CreateMap<UpdateAccionDto, Accion>();

        // Mapeos para la tabla "Area"
        CreateMap<Area, AreaDto>().ReverseMap();
        CreateMap<CreateAreaDto, Area>();
        CreateMap<UpdateAreaDto, Area>();

        // Mapeos para la tabla "Rol"
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<CreateRolDto, Rol>();
        CreateMap<UpdateRolDto, Rol>();

        // Mapeos para la tabla "Solucion"
        CreateMap<Solucion, SolucionDto>().ReverseMap();
        CreateMap<CreateSolucionDto, Solucion>();
        CreateMap<UpdateSolucionDto, Solucion>();

        // Mapeos para la tabla "Sugerencia"
        CreateMap<Sugerencia, SugerenciaDto>().ReverseMap();
        CreateMap<CreateSugerenciaDto, Sugerencia>();
        CreateMap<UpdateSugerenciaDto, Sugerencia>();

        // Mapeos para la tabla "Asignacion"
        CreateMap<Asignacion, AsignacionDto>().ReverseMap();
        CreateMap<CreateAsignacionDto, Asignacion>();
        CreateMap<UpdateAsignacionDto, Asignacion>();

        // Mapeos para la tabla "AsignacionRoles"
        CreateMap<AsignacionRoles, AsignacionRolesDto>().ReverseMap();
        CreateMap<CreateAsignacionRolesDto, AsignacionRoles>();
        CreateMap<UpdateAsignacionRolesDto, AsignacionRoles>();

        // Mapeos para la tabla "Seguimiento"
        CreateMap<Seguimiento, SeguimientoDto>();
        CreateMap<CreateSeguimientoDto, Seguimiento>();

        // Mapeos para la tabla "Permiso"
        CreateMap<Permiso, PermisoDto>();
        CreateMap<CreatePermisoDto, Permiso>();

        // Mapeos para la tabla "EvidenciaSolucion"
        CreateMap<EvidenciaSolucion, EvidenciaSolucionDto>().ReverseMap();
        CreateMap<CreateEvidenciaSolucionDto, EvidenciaSolucion>();

        // Mapeos para Autenticación
        // Nota: LoginDto y LoginResponseDto no necesitan mapeo directo con Usuario
    }
}

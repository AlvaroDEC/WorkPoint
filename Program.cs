using ClaseEntityFramework.Data;
using ClaseEntityFramework.Services.Implementations;
using ClaseEntityFramework.Services.Interfaces;
using ClaseEntityFramework.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

// Configurar CORS para permitir comunicación con el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:8080")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IInspeccionService, InspeccionService>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<ICriterioService, CriterioService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IObservacionService, ObservacionService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IProblemaService, ProblemaService>();
builder.Services.AddScoped<IAccionService, AccionService>();
builder.Services.AddScoped<ISolucionService, SolucionService>();
builder.Services.AddScoped<ISugerenciaService, SugerenciaService>();
builder.Services.AddScoped<IAsignacionService, AsignacionService>();
builder.Services.AddScoped<IAsignacionRolesService, AsignacionRolesService>();
builder.Services.AddScoped<ISeguimientoService, SeguimientoService>();
builder.Services.AddScoped<IPermisoService, PermisoService>();
builder.Services.AddScoped<IEvidenciaSolucionService, EvidenciaSolucionService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppContexts>(Options => {
    Options.UseNpgsql(builder.Configuration.GetConnectionString("LocalhostConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

// Usar CORS antes de mapear los controladores
app.UseCors("AllowFrontend");

// Usar middleware global de manejo de errores
app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();
app.Run();
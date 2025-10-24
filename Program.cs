using ClaseEntityFramework.Data;
using ClaseEntityFramework.Services.Implementations;
using ClaseEntityFramework.Services.Interfaces;
using ClaseEntityFramework.Middleware;
using ClaseEntityFramework.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<IAccionService, AccionService>();
builder.Services.AddScoped<ISolucionService, SolucionService>();
builder.Services.AddScoped<IAsignacionService, AsignacionService>();
builder.Services.AddScoped<IAsignacionRolesService, AsignacionRolesService>();
builder.Services.AddScoped<ISeguimientoService, SeguimientoService>();
builder.Services.AddScoped<IPermisoService, PermisoService>();
builder.Services.AddScoped<IEvidenciaSolucionService, EvidenciaSolucionService>();
builder.Services.AddScoped<IEvidenciaService, EvidenciaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "WorkPoint API", 
        Version = "v1" 
    });
    
    // Configurar autenticación JWT en Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando el esquema Bearer. Ejemplo: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddDbContext<AppContexts>(Options => {
    Options.UseNpgsql(builder.Configuration.GetConnectionString("LocalhostConnection"), 
        npgsqlOptions => npgsqlOptions.EnableRetryOnFailure());
    
    // ✅ Configurar PostgreSQL para manejar fechas UTC
    Options.ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.MultipleCollectionIncludeWarning));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

// 🔑 Configurar autenticación JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Para desarrollo
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero // Sin margen de tiempo adicional
    };
});

builder.Services.AddAuthorization();

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

// 🔑 Middleware de autenticación y autorización (en este orden)
app.UseAuthentication();
app.UseAuthorization();

// Usar middleware global de manejo de errores
app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();
app.Run();
using Dropi_Dev.JwtSetup;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Services.Implementations;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "LinkTic E-commerce", Version = "v1" });

    // Definir el esquema de seguridad para el token JWT
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese el token JWT en el formato: Bearer {token}"
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
var stringcConnection = builder.Configuration.GetConnectionString("LinkticEcommerce");
builder.Services.AddDbContext<LinkticEcommerceContext>(data => data.UseSqlServer(stringcConnection));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Clases
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<IPedidoService, PedidoService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();



//Encrypt 
builder.Services.AddSingleton<EncryptUtilities>();


//JWT
builder.Services.AddSingleton<JWTUtils>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddJwtAuthentication(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

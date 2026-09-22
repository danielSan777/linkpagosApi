using linkpagosapi.aplicacion.servicios;
using linkpagosapi.dominio.interfaces;
using linkpagosapi.infraestructura.data;
using linkpagosapi.infraestructura.repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ILinkPagoRepository,LinkPagoRepository>();
builder.Services.AddScoped<LinkPagoService>();

// 1. Agregar el servicio de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddDbContext<PagosDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PagosConnection")
    )
);


var app =builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

// 2. Usar el middleware de CORS (¡ANTES de MapControllers/UseAuthorization!)
app.UseCors("PermitirAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY;
using SistemaFacturacion.REPOSITORY.Generic;
using SistemaFacturacion.REPOSITORY.Interface;
using SistemaFacturacion.SERVICE;
using SistemaFacturacion.SERVICE.Interface;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();//AddJsonOptions(opt=>
//{
//    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IService<FamiliaProducto>, FamiliaService>();
builder.Services.AddScoped<IGenericRepositorio<FamiliaProducto>, FamiliaRepository>();

builder.Services.AddScoped<IService<Producto>, ProductoService>();
builder.Services.AddScoped<IGenericRepositorio<Producto>, ProductoRepository>();

builder.Services.AddScoped<IService<Usuario>, UsuarioService>();
builder.Services.AddScoped<IGenericRepositorio<Usuario>, UsuarioRepository>();

builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<IFacturaService<Factura>, FacturaService>();
builder.Services.AddScoped<IFacturaRepository<Factura>, FacturaRepository>();

builder.Services.AddScoped<IDetalleService<DetalleFactura>, DetalleService>();
builder.Services.AddScoped<IDetalleRepository<DetalleFactura>, DetalleRepository>();



builder.Services.AddDbContext<SisFactContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));

app.UseAuthorization();

app.MapControllers();

app.Run();

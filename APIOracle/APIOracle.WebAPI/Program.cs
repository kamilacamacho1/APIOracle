using APIOracle.DataAccess.Models;
using APIOracle.Services.Autor;
using APIOracle.Services.Libro;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region(Cadena de conexion)
var cadenaConexion = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<ModelContext>(x =>
    x.UseOracle(
        cadenaConexion,
        options => options.UseOracleSQLCompatibility("11")
    )
);
#endregion
#region( Add services to the container.)
builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IAutorService, AutorService>();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

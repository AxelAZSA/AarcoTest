using AarcoExamen.Domain.Interfaces;
using AarcoExamen.Infrastructure.Data;
using AarcoExamen.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Declaraci�n del contexto de base de datos
var connectionString = builder.Configuration.GetConnectionString("carDB");

builder.Services.AddDbContext<CarDatabaseContext >(options => options.UseSqlServer(connectionString));

//Configuraci�n de los cors
builder.Services.AddCors(options => options.AddPolicy(name: "prueba", policy =>
{
    //policy.WithOrigins("https://localhost:7273", "https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}
    ));

//Declaraci�n de los esquemas de servicio
builder.Services.AddScoped<ICarRepository, CarRepository>();


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

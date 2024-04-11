using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql (
connection, new MySqlServerVersion(new Version(8,0,29))));

//Versioning API
builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

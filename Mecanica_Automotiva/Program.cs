using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conectSql = builder.Configuration.GetConnectionString("LinkSql");
builder.Services.AddDbContext<DataBase>(options=>
    options.UseMySql(conectSql,ServerVersion.AutoDetect(conectSql)));

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EnderecoService>();

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

using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Services;
using Mecanica_Automotiva.Services.DadosClienteService;
using Mecanica_Automotiva.Services.DadosPecaService;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conect sql
var conectSql = builder.Configuration.GetConnectionString("LinkSql");
builder.Services.AddDbContext<DataBase>(options=>
    options.UseMySql(conectSql,ServerVersion.AutoDetect(conectSql)));

//services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<SubCategoriaService>();
builder.Services.AddScoped<MarcaService>();
builder.Services.AddScoped<ModeloService>();
builder.Services.AddScoped<PecasService>();
builder.Services.AddScoped<VeiculoService>();



//conect front
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod() //acesso aos methodos
              .AllowAnyHeader(); // permite enviar dados(cabecalho)
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

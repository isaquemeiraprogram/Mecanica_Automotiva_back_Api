using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Interface.IDadosCliente;
using Mecanica_Automotiva.Interface.IDadosPeca;
using Mecanica_Automotiva.Interface.IDadosProdutos;
using Mecanica_Automotiva.Interface.IDadosVeiculo;
using Mecanica_Automotiva.Mapper;
using Mecanica_Automotiva.Services;
using Mecanica_Automotiva.Services.DadosClienteService;
using Mecanica_Automotiva.Services.DadosPecaService;
using Mecanica_Automotiva.Services.DadosProdutoService;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<DadosClienteProfile>();
    config.AddProfile<DadosProdutoProfile>();
    config.AddProfile<DadosVeiculoProfile>();
    config.AddProfile<OutrosProfile>();
});





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conect sql
var conectSql = builder.Configuration.GetConnectionString("LinkSql");
builder.Services.AddDbContext<DataBase>(options =>
    options.UseMySql(conectSql, ServerVersion.AutoDetect(conectSql)));

//services
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IEndereco, EnderecoService>();
builder.Services.AddScoped<ICategoriaProduto, CategoriaProdutoService>();
builder.Services.AddScoped<IMarcaProduto, MarcaProdutoService>();
builder.Services.AddScoped<ISubCategoriaProduto, SubCategoriaProdutoService>();
builder.Services.AddScoped<IMarca, MarcaVeiculoService>();
builder.Services.AddScoped<IModelo, ModeloVeiculoService>();
builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<IVeiculo, VeiculoService>();
builder.Services.AddScoped<IServico, ServicoService>();
builder.Services.AddScoped<IAgenda, AgendaService>();



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

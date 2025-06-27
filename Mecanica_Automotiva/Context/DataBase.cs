using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.DadosCliente;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Models.Produtos;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Context
{
    public class DataBase: DbContext
    {
        public DataBase(DbContextOptions<DataBase> options):base(options){}

        //Dadoscliente
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        //DadosPeca //futuramente da pra trocar por enun talves
        public DbSet<CategoriaPeca> CategoriasPecas { get; set; }
        public DbSet<SubCategoriaPeca> SubCategoriasPecas { get; set; }

        //DadosVeiculo
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        //outros
        public DbSet<Agendar> Agendamentos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}

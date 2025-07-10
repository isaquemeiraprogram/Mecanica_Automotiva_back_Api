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
        public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
        public DbSet<SubCategoriaProduto> SubCategoriasProdutos { get; set; }

        //DadosVeiculo
        public DbSet<MarcaVeiculo> Marcas { get; set; }
        public DbSet<ModeloVeiculo> Modelos { get; set; }

        //outros
        public DbSet<Agendar> Agendamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}

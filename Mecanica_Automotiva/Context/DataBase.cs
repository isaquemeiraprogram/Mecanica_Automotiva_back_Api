using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.DadosCliente;
using Mecanica_Automotiva.Models.DadosPeca;
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
        public DbSet<MarcaProduto> MarcaProdutos { get; set; }

        //DadosVeiculo
        public DbSet<MarcaVeiculo> MarcaVeiculos { get; set; }
        public DbSet<ModeloVeiculo> ModeloVeiculos { get; set; }

        //outros
        public DbSet<Agenda> Agendamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}

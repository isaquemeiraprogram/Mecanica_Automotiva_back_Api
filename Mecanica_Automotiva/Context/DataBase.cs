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

        //DadosPeca
        public DbSet<ClassePeca> ClassePecas { get; set; }
        public DbSet<SubClassePeca> SubClassePecas { get; set; }
        public DbSet<TipoPeca> TipoPeca { get; set; }

        //DadosVeiculo
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }

        //outros
        public DbSet<Agendar> Agendamentos { get; set; }
        public DbSet<Pecas> Pecas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}

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
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Endereco> Enderecos { get; set; }

        //DadosPeca
        DbSet<ClassePeca> ClassePecas { get; set; }
        DbSet<SubClassePeca> SubClassePecas { get; set; }
        DbSet<TipoPeca> TipoPeca { get; set; }

        //DadosVeiculo
        DbSet<Marca> Marcas { get; set; }
        DbSet<Modelo> Modelos { get; set; }
        DbSet<TipoVeiculo> TipoVeiculos { get; set; }

        //outros
        DbSet<Agendar> Agendamentos { get; set; }
        DbSet<Pecas> Pecas { get; set; }
        DbSet<Servico> Servicos { get; set; }
        DbSet<Veiculo> Veiculos { get; set; }
    }
}

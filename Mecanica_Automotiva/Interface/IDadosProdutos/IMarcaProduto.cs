using Mecanica_Automotiva.Dtos.DadosProdutosDtos;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosPeca;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Interface.IDadosProdutos
{
    public interface IMarcaProduto
    {
        Task<List<MarcaProduto>> GetAllAsync();
        Task<MarcaProduto> GetByIdAsync(Guid id);
        Task<MarcaProduto> AddAsync(MarcaProdutoDto dto);
        Task<MarcaProduto> UpdateAsync(MarcaProdutoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosPeca;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface.IDadosProdutos
{
    public interface IModeloProduto
    {
        Task<List<ModeloProduto>> GetAllAsync();
        Task<ModeloProduto> GetByIdAsync(Guid id);
        Task<ModeloProduto> AddAsync(ModeloDto dto);
        Task<(ModeloProduto, CodigoResult)> UpdateAsync(ModeloDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

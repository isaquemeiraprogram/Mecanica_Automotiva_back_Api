using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Interface.IDadosVeiculo
{
    public interface IMarca
    {
        Task<List<MarcaVeiculo>> GetAllAsync();
        Task<MarcaVeiculo> GetByIdAsync(Guid id);
        Task<MarcaVeiculo> AddAsync(MarcaVeiculoDto dto);
        Task<MarcaVeiculo> UpdateAsync(MarcaVeiculoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

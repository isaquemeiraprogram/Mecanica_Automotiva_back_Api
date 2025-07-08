using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Interface.IDadosVeiculo
{
    public interface IMarca
    {
        Task<List<MarcaVeiculo>> GetAllAsync();
        Task<MarcaVeiculo> GetByIdAsync(Guid id);
        Task<MarcaVeiculo> AddAsync(MarcaDto dto);
        Task<MarcaVeiculo> UpdateAsync(MarcaDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

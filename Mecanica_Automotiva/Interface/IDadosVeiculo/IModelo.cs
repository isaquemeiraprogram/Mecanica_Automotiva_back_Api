using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface.IDadosVeiculo
{
    public interface IModelo
    {
        Task<List<Modelo>> GetAllAsync();
        Task<Modelo> GetByIdAsync(Guid id);
        Task<Modelo> AddAsync(ModeloDto dto);
        Task<(Modelo, CodigoResult)> UpdateAsync(ModeloDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface
{
    public interface IVeiculo
    {
        Task<List<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<(Veiculo, CodigoResult)> AddAsync(VeiculoDto dto);
        Task<(Veiculo, CodigoResult)> UpdateAsync(Guid id, VeiculoDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

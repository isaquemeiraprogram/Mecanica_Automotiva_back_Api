using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;

namespace Mecanica_Automotiva.Interface
{
    public interface IVeiculo
    {
        Task<List<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<Veiculo> AddAsync(VeiculoDto dto);
        Task<Veiculo> UpdateAsync(Guid id, VeiculoDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

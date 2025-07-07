using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface
{
    public interface IPeca
    {
        Task<List<Peca>> GetAllAsync();
        Task<Peca> GetByIdAsync(Guid id);
        Task<Peca> AddAsync(PecaDto dto);
        Task<(Peca, CodigoResult)> UpdateAsync(PecaDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

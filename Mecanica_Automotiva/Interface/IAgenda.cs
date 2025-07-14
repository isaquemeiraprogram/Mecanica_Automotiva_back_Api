using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface
{
    public interface IAgenda
    {
        Task<List<Agenda>> GetAllAsync();
        Task<Agenda> GetByIdAsync(Guid id);
        Task<(Agenda, CodigoResult)> AddAsync(AgendarDto dto);
        Task<(Agenda, CodigoResult)> UpdateAsync(AgendarDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

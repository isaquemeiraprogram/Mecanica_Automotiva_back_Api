using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;

namespace Mecanica_Automotiva.Interface
{
    public interface IAgenda
    {
        Task<List<Agenda>> GetAllAsync();
        Task<Agenda> GetByIdAsync(Guid id);
        Task<Agenda> AddAsync(AgendarDto dto);
        Task<Agenda> UpdateAsync(AgendarDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

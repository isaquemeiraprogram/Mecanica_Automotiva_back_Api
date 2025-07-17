using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;

namespace Mecanica_Automotiva.Interface
{
    public interface IServico
    {
        Task<List<Servico>> GetAllAsync();
        Task<Servico> GetByIdAsync(Guid id);
        Task<Servico> AddAsync(ServicoDto dto);
        Task<Servico> UpdateAsync(ServicoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

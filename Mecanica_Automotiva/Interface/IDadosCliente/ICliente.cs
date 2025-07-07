using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Interface.IDadosCliente
{
    public interface ICliente
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);
        Task<Cliente> AddAsync(ClienteDto dto);
        Task<Cliente> UpdateAsync(ClienteDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

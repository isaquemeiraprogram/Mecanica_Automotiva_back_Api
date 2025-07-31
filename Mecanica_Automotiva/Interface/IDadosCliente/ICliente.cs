using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Interface.IDadosCliente
{
    public interface ICliente
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByCpfAsync(string cpf);
        Task<Cliente> AddAsync(ClienteDto dto);
        Task<Cliente> UpdateAsync(ClienteDto dto, string cpf);
        Task<bool> DeleteAsync(string cpf);
    }
}

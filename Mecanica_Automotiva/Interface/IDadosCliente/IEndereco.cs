using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Interface.IDadosCliente
{
    public interface IEndereco
    {
        Task<Endereco> AddAsync(EnderecoDto dto);
        Task<Endereco> UpdateAsync(EnderecoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

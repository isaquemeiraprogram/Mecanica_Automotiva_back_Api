using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Interface.IDadosCliente
{
    public interface IEndereco
    {
        Task<List<Endereco>> GetByCpfAsync(string cpf);
        Task<Endereco> AddAsync(EnderecoDto dto);
        Task<Endereco> UpdateAsync(EnderecoDto dto, string slug);
        Task<bool> DeleteAsync(string slug);
    }
}

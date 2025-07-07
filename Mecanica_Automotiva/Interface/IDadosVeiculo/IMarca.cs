using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Interface.IDadosVeiculo
{
    public interface IMarca
    {
        Task<List<Marca>> GetAllAsync();
        Task<Marca> GetByIdAsync(Guid id);
        Task<Marca> AddAsync(MarcaDto dto);
        Task<Marca> UpdateAsync(MarcaDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

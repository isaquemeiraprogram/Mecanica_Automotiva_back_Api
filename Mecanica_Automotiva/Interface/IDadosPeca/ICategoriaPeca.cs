using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Interface.IDadosPeca
{
    public interface ICategoriaPeca
    {
        Task<List<CategoriaPeca>> GetAllAsync();
        Task<CategoriaPeca> GetByIdAsync(Guid id);
        Task<CategoriaPeca> AddAsync(CategoriaPecaDto dto);
        Task<CategoriaPeca> UpdateAsync(CategoriaPecaDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

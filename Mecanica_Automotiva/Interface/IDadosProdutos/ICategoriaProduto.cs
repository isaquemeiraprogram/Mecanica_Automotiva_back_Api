using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Interface.IDadosPeca
{
    public interface ICategoriaProduto
    {
        Task<List<CategoriaProduto>> GetAllAsync();
        Task<CategoriaProduto> GetByIdAsync(Guid id);
        Task<CategoriaProduto> AddAsync(CategoriaProdutoDto dto);
        Task<CategoriaProduto> UpdateAsync(CategoriaProdutoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

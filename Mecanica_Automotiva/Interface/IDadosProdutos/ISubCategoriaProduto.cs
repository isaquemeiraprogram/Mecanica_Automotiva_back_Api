using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Interface.IDadosPeca
{
    public interface ISubCategoriaProduto
    {
        Task<List<SubCategoriaProduto>> GetAllAsync();
         Task<SubCategoriaProduto> GetByIdAsync(Guid id);
        Task<List<SubCategoriaProduto>> GetFiltroSubcategoriaAsync(Guid id);
        Task<SubCategoriaProduto> AddAsync(SubCategoriaProdutoDto dto);
        Task<SubCategoriaProduto> UpdateAsync(SubCategoriaProdutoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

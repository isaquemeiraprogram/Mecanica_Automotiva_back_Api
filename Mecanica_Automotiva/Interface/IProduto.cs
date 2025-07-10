using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface
{
    public interface IProduto
    {
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(Guid id);
        Task<Produto> AddAsync(ProdutoDto dto);
        Task<(Produto, CodigoResult)> UpdateAsync(ProdutoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}

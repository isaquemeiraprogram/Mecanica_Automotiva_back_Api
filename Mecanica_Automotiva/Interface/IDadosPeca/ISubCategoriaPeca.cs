using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface.IDadosPeca
{
    public interface ISubCategoriaPeca
    {
        Task<List<SubCategoriaPeca>> GetAllAsync();
         Task<SubCategoriaPeca> GetByIdAsync(Guid id);
        Task<List<SubCategoriaPeca>> GetFiltroSubcategoriaAsync(Guid id);
        Task<SubCategoriaPeca> AddAsync(SubCategoriaPecaDto dto);
        Task<(SubCategoriaPeca, CodigoResult)> UpdateAsync(SubCategoriaPecaDto dto, Guid id);
        Task<(bool, CodigoResult)> DeleteAsync(Guid id);
    }
}

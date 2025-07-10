using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosProdutos;
using Mecanica_Automotiva.Models.DadosPeca;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Services.DadosProdutoService
{
    public class ModeloProdutoService : IModeloProduto
    {
        public Task<ModeloProduto> AddAsync(ModeloDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ModeloProduto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ModeloProduto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(ModeloProduto, CodigoResult)> UpdateAsync(ModeloDto dto, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

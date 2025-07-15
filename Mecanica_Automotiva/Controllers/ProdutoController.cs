using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Services;
using Mecanica_Automotiva.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _service;

        public ProdutoController(IProduto _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAllAsync()
        {
            var produtoList = await _service.GetAllAsync();
            return Ok(produtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetByIdAsync(Guid id)
        {
            var produto = await _service.GetByIdAsync(id);
            if (produto == null) return NotFound("Produto não encontrada.");

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<(Produto, CodigoResult)>> AddAsync([FromBody] ProdutoDto dto)
        {
            var (produto,codigo) = await _service.AddAsync(dto);

            switch (codigo)
            {
                case CodigoResult.SubCategoriaNaoEncontrada:
                    return NotFound("SubCategoria Do Produto Não Encontrada");
                case CodigoResult.MarcaProdutoNaoEncontrada:
                    return NotFound("Marca Do Produto Não Encontrada");
                case CodigoResult.MarcaVeiculoNaoEncontrada:
                    return NotFound("Marca Veiculo Do Produto Não Encontrada");
                case CodigoResult.ModeloNaoEncontrado:
                    return NotFound("Modelo Veiculo Do Produto Nao Encontrado");
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<(Produto, CodigoResult)>> UpdateAsync([FromBody] ProdutoDto dto, Guid id)
        {
            var (produto, codigo) = await _service.UpdateAsync(dto, id);

            switch (codigo)
            {
                case CodigoResult.ProdutoNaoEncontrado:
                    return NotFound("Produto não encontrada.");
                case CodigoResult.SubCategoriaNaoEncontrada:
                    return NotFound("Subcategoria da produto não encontrada.");
                case CodigoResult.MarcaProdutoNaoEncontrada:
                    return NotFound("Marca Do Produto Não Encontrada");
                case CodigoResult.MarcaVeiculoNaoEncontrada:
                    return NotFound("Marca Veiculo Do Produto Não Encontrada");
                case CodigoResult.ModeloNaoEncontrado:
                    return NotFound("Modelo Veiculo Do Produto Nao Encontrado");
            }

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var produto = await _service.DeleteAsync(id);
            if (produto == false) return NotFound("Produto não encontrada.");

            return Ok(produto);
        }
    }
}

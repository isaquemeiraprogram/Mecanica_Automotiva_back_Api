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
        public async Task<ActionResult<Produto>> AddAsync(ProdutoDto dto)
        {
            var produto = await _service.AddAsync(dto);
            if (produto == null) return NotFound("Subcategoria não encontrada.");

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<(Produto, CodigoResult)>> UpdateAsync(ProdutoDto dto, Guid id)
        {
            var (produto, codigo) = await _service.UpdateAsync(dto, id);

            switch (codigo)
            {
                case CodigoResult.ProdutoNaoEncontrado:
                    return NotFound("Produto não encontrada.");
                case CodigoResult.SubCategoriaNaoEncontrada:
                    return NotFound("Subcategoria da produto não encontrada.");
            }

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var produto = await _service.DeleteAsync(id);
            if (produto) return NotFound("Produto não encontrada.");

            return true;
        }
    }
}

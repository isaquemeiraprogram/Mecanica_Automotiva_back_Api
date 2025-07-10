using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Interface.IDadosPeca;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Services.DadosPecaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Controllers.DadosPecaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly ICategoriaProduto _service;

        public CategoriaProdutoController(ICategoriaProduto _service)
        {
            this._service = _service;
        }


        [HttpGet]
        public async Task<ActionResult<List<CategoriaProduto>>> GetAllAsync()
        {
            var categoriList = await _service.GetAllAsync();
            return Ok(categoriList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProduto>> GetByIdAsync(Guid id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound("Categoria não encontrada");
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaProduto>> AddAsync([FromBody] CategoriaProdutoDto dto)
        {
            var categoria = await _service.AddAsync(dto);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaProduto>> UpdateAsync([FromBody] CategoriaProdutoDto dto, Guid id)
        {
            var categoria = await _service.UpdateAsync(dto,id);
            if (categoria == null)  return NotFound("Categoria não encontrada");
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var categoria = await _service.DeleteAsync(id);
            if (categoria ==  false) return NotFound("Categoria não encontrada");
            return Ok(categoria);
        }

    }
}

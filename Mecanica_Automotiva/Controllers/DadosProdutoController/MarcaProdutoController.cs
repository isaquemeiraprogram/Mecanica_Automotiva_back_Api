using Mecanica_Automotiva.Dtos.DadosProdutosDtos;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosProdutos;
using Mecanica_Automotiva.Models.DadosPeca;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosProdutoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaProdutoController : ControllerBase
    {
        private readonly IMarcaProduto _service;

        public MarcaProdutoController(IMarcaProduto service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MarcaProduto>>> GetAllAsync()
        {
            var marca = await _service.GetAllAsync();
            return Ok(marca);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaProduto>> GetByIdAsync(Guid id)
        {
            var marca = await _service.GetByIdAsync(id);
            if (marca == null) return NotFound("A marca do produto nao foi encontrada");

            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<MarcaProduto>> AddAsync([FromBody] MarcaProdutoDto dto)
        {
            var marca = await _service.AddAsync(dto);
            return Ok(marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MarcaProduto>> UpdateAsync([FromBody] MarcaProdutoDto dto, Guid id)
        {
            var marca = await _service.UpdateAsync(dto, id);
            if (marca == null) return NotFound("A marca do produto nao foi encontrada");

            return Ok(marca);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var marca = await _service.DeleteAsync(id);
            if (marca == false) return NotFound("A marca do produto nao foi encontrada");

            return Ok(marca);
        }
    }
}

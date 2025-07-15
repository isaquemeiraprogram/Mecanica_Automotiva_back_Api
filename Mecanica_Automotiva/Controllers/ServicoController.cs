using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServico _service;

        public ServicoController(IServico service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servico>>> GetAllAsync()
        {
            var marca = await _service.GetAllAsync();
            return Ok(marca);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetByIdAsync(Guid id)
        {
            var marca = await _service.GetByIdAsync(id);
            if (marca == null) return NotFound("Serviço Não Encontrado");

            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<Servico>> AddAsync([FromBody] ServicoDto dto)
        {
            var marca = await _service.AddAsync(dto);
            if (marca == null) return NotFound("Lista dePecas do servico nula");

            return Ok(marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<(Servico, CodigoResult)>> UpdateAsync([FromBody] ServicoDto dto, Guid id)
        {
            var (marca,codigo) = await _service.UpdateAsync(dto, id);

            switch (codigo)
            {
                case CodigoResult.ServicoNaoEncontrado: 
                    return NotFound("Serviço Não Encontrado");
                case CodigoResult.ProdutoNaoEncontrado:
                    return NotFound("Produto Não Encontrado");
            }
            
            return Ok(marca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var marca = await _service.DeleteAsync(id);
            if (marca == false) return NotFound("Serviço Não Encontrado");

            return Ok(marca);
        }
    }
}

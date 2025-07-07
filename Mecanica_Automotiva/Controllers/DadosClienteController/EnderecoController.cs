using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Interface.IDadosCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Mecanica_Automotiva.Services.DadosClienteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosClienteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEndereco _service;

        public EnderecoController(IEndereco _service)
        {
            this._service = _service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetByIdAsync(Guid id)
        {
            var endereco = await _service.GetByIdAsync(id);
            if (endereco == null) return NotFound("Endereco nao encontrado");

            return Ok(endereco);
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> AddAsync([FromBody] EnderecoDto dto)
        {
            var endereco = await _service.AddAsync(dto);
            if (endereco == null) return NotFound("Cliente do endereco não encontrado");

            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Endereco>> UpdateAsync([FromBody] EnderecoDto dto,Guid id)
        {
            var endereco = await _service.UpdateAsync(dto,id);
            if (endereco == null) return NotFound("Endereço não encontrado");

            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var endereco = await _service.DeleteAsync(id);
            if (endereco == false) return NotFound("Endereço não encontrado");
            return Ok(endereco);
        }
    }
}

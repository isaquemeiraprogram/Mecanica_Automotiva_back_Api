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

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<List<Endereco>>> GetByCpfAsync(string cpf)
        {
            var enderecoList = await _service.GetByCpfAsync(cpf);
            return enderecoList;
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> AddAsync([FromBody] EnderecoDto dto)
        {
            var endereco = await _service.AddAsync(dto);

            return Ok(endereco);
        }

        [HttpPut("slug/{slug}")]
        public async Task<ActionResult<Endereco>> UpdateAsync([FromBody] EnderecoDto dto, string slug)
        {
            var endereco = await _service.UpdateAsync(dto, slug);

            return Ok(endereco);
        }

        [HttpDelete("slug/{slug}")]
        public async Task<ActionResult<bool>> DeleteAsync(string slug)
        {
            var endereco = await _service.DeleteAsync(slug);

            return Ok(endereco);
        }
    }
}

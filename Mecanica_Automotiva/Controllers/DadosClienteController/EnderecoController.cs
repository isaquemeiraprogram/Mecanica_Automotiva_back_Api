using Mecanica_Automotiva.Dtos.DtoCliente;
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
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService _service)
        {
            this._service = _service;
        }


        [HttpPost]
        public async Task<string> AddEndereco([FromBody] EnderecoDto dto)
        {
            return await _service.AddEndereco(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateEndereco( [FromBody] EnderecoDto dto, Guid id)
        {
            return await _service.UpdateEndereco(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteEndereco(Guid id)
        {
            return await _service.DeleteEndereco(id);
        }
    }
}

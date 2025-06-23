using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Mecanica_Automotiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
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

        [HttpGet]
        public async Task<List<Endereco>> GetAllEndereco()
        {
            return await _service.GetAllEndereco();
        }

        [HttpGet("{id}")]
        public async Task<Endereco> GetEnderecoById(Guid id)
        {
            return await _service.GetEnderecoById(id);
        }

        [HttpPost]
        public async Task<string> AddEndereco(EnderecoDto dto, Guid id)
        {
            return await _service.AddEndereco(dto,id);
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

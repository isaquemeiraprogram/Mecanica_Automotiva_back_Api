using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Mecanica_Automotiva.Services.DadosClienteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosClienteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService _service)
        {
            this._service = _service;
        }


        [HttpGet]
        public async Task<List<Cliente>> GetAllClintes()
        {
            return await _service.GetAllClintes();
        }

        [HttpGet("{id}")]
        public async Task<Cliente> GetClienteById(Guid id)
        {
            return await _service.GetClienteById(id);
        }

        [HttpPost]
        public async Task<string> AddCliente([FromBody] ClienteDto dto)
        {
            return await _service.AddCliente(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateCliente([FromBody] ClienteDto dto, Guid id)
        {
            return await _service.UpdateCliente(dto,id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteCliente(Guid id)
        {
            return await _service.DeleteCliente(id);
        }
    }
}

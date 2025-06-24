using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Mecanica_Automotiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
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
        public async Task<string> AddCliente(ClienteDto dto)
        {
            return await _service.AddCliente(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateCliente(Guid id, ClienteDto dto)
        {
            return await _service.UpdateCliente(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteCliente(Guid id)
        {
            return await _service.DeleteCliente(id);
        }
    }
}

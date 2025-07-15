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
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _service;

        public ClienteController(ICliente _service)
        {
            this._service = _service;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllAsync()
        {
            //talves de pra usar try catch aqui
            var clienteList = await _service.GetAllAsync();
            return Ok(clienteList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetByIdAsync(Guid id)
        {
            //fazer assim deixa mais facil de ler o retorno
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null) return NotFound("Cliente não encontrado");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AddAsync([FromBody] ClienteDto dto)
        {
            var cliente = await _service.AddAsync(dto);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> UpdateAsync([FromBody] ClienteDto dto, Guid id)
        {
            var cliente = await _service.UpdateAsync(dto,id);
            if (cliente == null) return NotFound("Cliente não encontrado");

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var cliente = await _service.DeleteAsync(id);
            if (cliente == false) return NotFound();
            return Ok(cliente);
        }
    }
}

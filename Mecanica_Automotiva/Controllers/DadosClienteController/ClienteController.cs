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

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<Cliente>> GetByIdAsync(string cpf)
        {
            //fazer assim deixa mais facil de ler o retorno
            var cliente = await _service.GetByCpfAsync(cpf);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AddAsync([FromBody] ClienteDto dto)
        {
            var cliente = await _service.AddAsync(dto);
            return Ok(cliente);
        }

        [HttpPut("cpf/{cpf}")]
        public async Task<ActionResult<Cliente>> UpdateAsync([FromBody] ClienteDto dto, string cpf)
        {
            var cliente = await _service.UpdateAsync(dto, cpf);
            return Ok(cliente);
        }

        [HttpDelete("cpf/{cpf}")]
        public async Task<ActionResult<bool>> DeleteAsync(string cpf)
        {
            var cliente = await _service.DeleteAsync(cpf);
            return Ok(cliente);
        }
    }
}

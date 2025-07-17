using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendarController : ControllerBase
    {
        private readonly IAgenda _service;

        public AgendarController(IAgenda service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agenda>>> GetAllAsync()
        {
            var agendamentos = await _service.GetAllAsync();
            return agendamentos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agenda>> GetByIdAsync(Guid id)
        {
            var agendamento = await _service.GetByIdAsync(id);
            return agendamento;
        }

        [HttpPost]
        public async Task<ActionResult<Agenda>> AddAsync([FromBody] AgendarDto dto)
        {
            var agendamento = await _service.AddAsync(dto);

            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Agenda>> UpdateAsync([FromBody] AgendarDto dto, Guid id)
        {
            var agendamento = await _service.UpdateAsync(dto, id);

            return Ok(agendamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var agendamento = _service.DeleteAsync(id);

            return Ok(agendamento);
        }
    }
}

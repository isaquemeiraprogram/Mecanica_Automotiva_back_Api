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
    public class AgendarController : ControllerBase
    {
        private readonly IAgenda _service;

        public AgendarController(IAgenda service)
        {
            _service = service;
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
            if (agendamento == null) return NotFound("Agendamento não encontrado");
            return agendamento;
        }

        [HttpPost]
        public async Task<ActionResult<(Agenda, CodigoResult)>> AddAsync(AgendarDto dto)
        {
            var (agendamento,codigo) = await _service.AddAsync(dto);

            switch (codigo)
            {
                case CodigoResult.ServicoNaoEncontrado:
                    return NotFound("Servico não encontrado");
                case CodigoResult.ClienteNaoEncontrado:
                    return NotFound("Cliente nao encontrado");
                case CodigoResult.VeiculoNaoEncontrado:
                    return NotFound("Veiculo não encontrado");
            }

            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<(Agenda, CodigoResult)>> UpdateAsync(AgendarDto dto, Guid id)
        {
            var (agendamento,codigo) = await _service.UpdateAsync(dto, id);

            switch (codigo)
            {
                case CodigoResult.AgendamentoNaoEncontrado:
                    return NotFound("Agendamento não encontrado");
                case CodigoResult.ServicoNaoEncontrado:
                    return NotFound("Servico não encontrado");
                case CodigoResult.ClienteNaoEncontrado:
                    return NotFound("Cliente nao encontrado");
                case CodigoResult.VeiculoNaoEncontrado:
                    return NotFound("Veiculo não encontrado");
            }
            return Ok(agendamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var agendamento = _service.DeleteAsync(id);
            if (agendamento != null) return NotFound("Agendamento não encontrado");

            return Ok(agendamento);
        }
    }
}

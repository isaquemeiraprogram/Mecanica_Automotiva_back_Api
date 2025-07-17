using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Interface.IDadosPeca;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Services.DadosPecaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosPecaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaProdutoController : ControllerBase
    {
        private readonly ISubCategoriaProduto _Service;

        public SubCategoriaProdutoController(ISubCategoriaProduto _Service)
        {
            this._Service = _Service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoriaProduto>>> GetAllAsync()
        {
            var subcategoriaList = await _Service.GetAllAsync();

            return Ok(subcategoriaList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoriaProduto>> GetByIdAsync(Guid id)
        {
            var subCategoria = await _Service.GetByIdAsync(id);

            return Ok(subCategoria);
        }

        [HttpGet("/FiltroPorCategoria/{id}")]//o nome da rota tem que ser igual no parametro

        //entrada: categoriaId
        //saida : lista de subcategorias que pertencem a categoriaId
        public async Task<ActionResult<List<SubCategoriaProduto>>> GetFiltroSubcategoriaAsync(Guid id)
        {
            var subcategoriaList = await _Service.GetFiltroSubcategoriaAsync(id);

            return Ok(subcategoriaList);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoriaProduto>> AddAsync([FromBody] SubCategoriaProdutoDto dto)
        {
            var subCategoriaPeca = await _Service.AddAsync(dto);

            return Ok(subCategoriaPeca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoriaProduto>> UpdateAsync([FromBody] SubCategoriaProdutoDto dto, Guid id)
        {
            //cria duas var pra dividir   subicategoria e codigo de erro
            var subCategoria = await _Service.UpdateAsync(dto, id);

            return Ok(subCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var subCategoria = await _Service.DeleteAsync(id);

            return Ok(subCategoria);
        }
    }
}

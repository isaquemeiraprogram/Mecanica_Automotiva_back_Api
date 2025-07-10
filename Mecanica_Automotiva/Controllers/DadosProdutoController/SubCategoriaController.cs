using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Interface.IDadosPeca;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Services.DadosPecaService;
using Mecanica_Automotiva.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosPecaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ISubCategoriaProduto _Service;

        public SubCategoriaController(ISubCategoriaProduto _Service)
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
            if (subCategoria == null) return NotFound("SubCategoria não encontrada");

            return Ok(subCategoria);
        }

        [HttpGet("/Categoria/{id}")]//o nome da rota tem que ser igual no parametro

        //entrada: categoriaId
        //saida : lista de subcategorias que pertencem a categoriaId
        public async Task<ActionResult<List<SubCategoriaProduto>>> GetFiltroSubcategoriaAsync(Guid id)
        {
            var subcategoriaList = await _Service.GetFiltroSubcategoriaAsync(id);
            if (subcategoriaList == null) return NotFound("Categoria não encontrada");

            return Ok(subcategoriaList);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoriaProduto>> AddAsync(SubCategoriaProdutoDto dto)
        {
            var subCategoriaPeca = await _Service.AddAsync(dto);
            if (subCategoriaPeca == null) return NotFound("Categoria da subcategoria não encontrada");
            return Ok(subCategoriaPeca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoriaProduto>> UpdateAsync(SubCategoriaProdutoDto dto, Guid id)
        {
            //cria duas var pra dividir   subicategoria e codigo de erro
            var (subCategoria, codigo) = await _Service.UpdateAsync(dto, id);

            if (codigo == CodigoResult.SubCategoriaNaoEncontrada)
                return NotFound("SubCategoria não encontrada");

            if (codigo == CodigoResult.CategoriaNaoEncontrada)
                return NotFound("Categoria da subcategoria não encontrada");

            return Ok(subCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var (subCategoria, codigo) = await _Service.DeleteAsync(id);

            if (codigo == CodigoResult.SubCategoriaNaoEncontrada)
                return NotFound("SubCategoria não encontrada");

            return Ok(subCategoria);
        }
    }
}

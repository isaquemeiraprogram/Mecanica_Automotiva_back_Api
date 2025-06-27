using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class PecasService
    {
        private readonly DataBase _context;

        public PecasService(DataBase _context)
        {
            this._context = _context;
        }

        public async Task<List<Peca>> GetPecasAsync()
        {
            return await _context.Pecas
                .Include(p => p.SubCategoriaPeca)
                .ToListAsync();
        }

        public async Task<Peca> GetPecaByIdAsync(Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) throw new Exception("Peca Nao Encontrada");

            return peca;
        }

        public async Task<string> AddPeca(PecasDto dto)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaPecaId);
            if (categoria == null) throw new Exception("Categoria de Peca não encontrada");

            Peca peca = new Peca
            {
                Id = Guid.NewGuid(),
                Img = dto.Img,
                Nome = dto.Nome,
                Preco = dto.Preco,
                CategoriaPeca = categoria,//subcategoria esta na categoria
            };

            await _context.Pecas.AddAsync(peca);

            await _context.SaveChangesAsync();
            return $"Peca {peca.Nome} adicionada com sucesso";
        }

        public async Task<string> UpdatePeca( PecasDto dto, Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) throw new Exception("Peca Nao Encontrada");

            var subCategoria = await _context.CategoriasPecas.FindAsync(dto.SubCategoriaPecaId);
            if (subCategoria == null) throw new Exception("Categoria de Peca não encontrada");

            peca.Img = dto.Img;
            peca.Nome = dto.Nome;
            peca.Preco = dto.Preco;
            peca.SubCategoriaPeca = subCategoria;

            await _context.SaveChangesAsync();
            return $"Peca {peca.Nome} atualizada com sucesso";
        }

        public async Task<string> DeletePeca(Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) throw new Exception("Peca Nao Encontrada");

            _context.Pecas.Remove(peca);

            await _context.SaveChangesAsync();
            return $"Peca {peca.Nome} deletada com sucesso";
        }
    }
}

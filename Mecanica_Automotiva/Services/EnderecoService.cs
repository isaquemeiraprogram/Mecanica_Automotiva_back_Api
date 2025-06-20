using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class EnderecoService
    {
        private readonly DataBase _context;

        public EnderecoService(DataBase _context)
        {
            this._context = _context;
        }
        public async Task<List<Endereco>> GetAllEndereco()
        {
            return await _context.Enderecos.Include(e=> e.Cliente).ToListAsync(); 
        }

        public async Task<Endereco> GetEnderecoById(Guid id)
        {
            Endereco endereco = await _context.Enderecos
                .Include(e=>e.Cliente)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (endereco == null) throw new Exception("Endereço não encontrado");

            return endereco;
        }
    
        public async Task<string> AddEndereco(EnderecoDto dto)
        {
            Endereco endereco = new Endereco
            {
                Id = Guid.NewGuid(),
                Cep = dto.Cep,
                Estado = dto.Estado,
                Cidade = dto.Cidade,
                Bairro = dto.Bairro,
                Rua = dto.Rua,
                Numero = dto.Numero
            };

            await _context.Enderecos.AddAsync(endereco);

            await _context.SaveChangesAsync();
            return $"Endereço {endereco} adicionado com sucesso";
        }
        public async Task<string> UpdateEndereco(Guid id, EnderecoDto dto)
        {
            Endereco endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) throw new Exception("Endereço não encontrado");

            endereco.Cep = dto.Cep;
            endereco.Estado = dto.Estado;
            endereco.Cidade = dto.Cidade;
            endereco.Bairro = dto.Bairro;
            endereco.Rua = dto.Rua;
            endereco.Numero = dto.Numero;

            _context.Enderecos.Update(endereco);

            await _context.SaveChangesAsync();
            return $"Endereço {endereco} atualizado com sucesso";
        }

        public async Task<string> DeleteEndereco(Guid id)
        {
            Endereco endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) throw new Exception("Endereço não encontrado");

            _context.Enderecos.Remove(endereco);

            await _context.SaveChangesAsync();
            return $"Endereço {endereco} removido com sucesso";
        }
    }
}

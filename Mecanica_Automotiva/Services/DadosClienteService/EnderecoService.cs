using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosClienteService
{
    public class EnderecoService
    {
        private readonly DataBase _context;

        public EnderecoService(DataBase _context)
        {
            this._context = _context;
        }

        
        public async Task<string> AddEndereco(EnderecoDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null) throw new Exception("cliente nao encontrado");

            
            Endereco endereco = new Endereco
            {
                Id = Guid.NewGuid(),
                Cep = dto.Cep,
                Estado = dto.Estado,
                Cidade = dto.Cidade,
                Bairro = dto.Bairro,
                Rua = dto.Rua,
                Numero = dto.Numero,
                Cliente = cliente
            };



            await _context.Enderecos.AddAsync(endereco);

            await _context.SaveChangesAsync();
            return $"Endereço de {endereco.Cliente.Nome} adicionado com sucesso";
        }
        public async Task<string> UpdateEndereco(Guid id, EnderecoDto dto)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) throw new Exception("Endereço não encontrado");

            endereco.Cep = dto.Cep;
            endereco.Estado = dto.Estado;
            endereco.Cidade = dto.Cidade;
            endereco.Bairro = dto.Bairro;
            endereco.Rua = dto.Rua;
            endereco.Numero = dto.Numero;

            await _context.SaveChangesAsync();
            return $"Endereço {endereco.Id} atualizado com sucesso";
        }
        public async Task<string> DeleteEndereco(Guid id)
        {
            Endereco endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) throw new Exception("Endereço não encontrado");

            _context.Enderecos.Remove(endereco);

            await _context.SaveChangesAsync();
            return $"Endereço {endereco.Id} removido com sucesso";
        }
    }
}

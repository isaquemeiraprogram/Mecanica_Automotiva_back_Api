using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class ClienteService
    {
        private readonly DataBase _context;

        public ClienteService(DataBase _context)
        {
            this._context = _context;
        }
        public async Task<List<Cliente>> GetAllClintes()
        {
            return await _context.Clientes
                .Include(c => c.Endereco)
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteById(Guid id)
        {
            Cliente cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) throw new Exception("Cliente não encontrado");

            return cliente;
        }

        public async Task<string> AddCliente(ClienteDto dto)
        {
            Cliente cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cpf = dto.Cpf
            };

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return $"Cliente {cliente.Nome} adicionado com sucesso";
        }

        public async Task<string> UpdateCliente(Guid id, ClienteDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) throw new Exception("Cliente não encontrado");

            cliente.Nome = dto.Nome;
            cliente.Cpf = dto.Cpf;

            await _context.SaveChangesAsync();
            return $"Cliente {cliente.Nome} atualizado com sucesso";
        }

        //quando for deletar cliente deleta endereco tambem
        public async Task<string> DeleteCliente(Guid id)
        {
            Cliente cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) throw new Exception("Cliente não encontrado");

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();
            return $"Cliente {cliente.Nome} removido com sucesso";
        }

    }
}

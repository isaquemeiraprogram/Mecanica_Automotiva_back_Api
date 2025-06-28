using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosClienteService
{
    public class ClienteService
    {
        private readonly DataBase _context;

        public ClienteService(DataBase _context)
        {
            this._context = _context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var clienteList = await _context.Clientes
                .Include(c => c.Endereco)
                .ToListAsync();

            return clienteList;
        }
        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }
        public async Task<Cliente> AddAsync(ClienteDto dto)
        {
            Cliente cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cpf = dto.Cpf
            };

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }
        public async Task<Cliente> UpdateAsync(ClienteDto dto, Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            cliente.Nome = dto.Nome;
            cliente.Cpf = dto.Cpf;

            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}

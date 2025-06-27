using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Models;

namespace Mecanica_Automotiva.Services
{
    public class VeiculoService
    {
        private readonly DataBase _context;
        public VeiculoService(DataBase context)
        {
            this._context = context;
        }
        public async Task<List<Veiculo>> GetAll()
        {

            //implantar api pra pegar veiculo pela placa
            return await _context.Veiculos.Include(v => v.Marca)
                                          .Include(v => v.Modelo)
                                          .ToListAsync();
        }
        public async Task<Veiculo> GetByIdAsync(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) throw new Exception("Veículo não encontrado");
            return veiculo;
        }
    }
}

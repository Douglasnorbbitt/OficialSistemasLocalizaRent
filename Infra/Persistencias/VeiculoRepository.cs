using Dominio.Entidades;
using Dominio.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencias
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext _dataContext;

        public VeiculoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        ///
        public async Task Alterar(Veiculo veiculo)
        {
            _dataContext.Update(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            return await _dataContext.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Veiculo> BuscarPorMarcar(string marcar)
        {
            return await _dataContext.Veiculos.FirstOrDefaultAsync(x => x.Marca == marcar);
        }

        public async Task<Veiculo> BuscarPorModelo(string modelo)
        {
            return await _dataContext.Veiculos.FirstOrDefaultAsync(x => x.Modelo == modelo);
        }

        public async Task Criar(Veiculo veiculo)
        {
            _dataContext.Veiculos.Add(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Excluir(Veiculo veiculo)
        {
            _dataContext.Remove(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var veiculo = BuscarPorId(id);

            _dataContext.Remove(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Veiculo>> ListarTodosVeiculos()
        {
            return await _dataContext.Veiculos.AsNoTracking().ToListAsync();
        }
    }
}
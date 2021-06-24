using Dominio.Entidades;
using Dominio.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias
{
    public class ConsultarVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ConsultarVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            return await _veiculoRepository.BuscarPorId(id);
        }
        public async Task<IEnumerable<Veiculo>> ListarTodosVeiculos()
        {
            return await _veiculoRepository.ListarTodosVeiculos();
        }
        public async Task<Veiculo> BuscarPorMarcar(string marca)
        {
            return await _veiculoRepository.BuscarPorMarcar(marca);
        }
        public async Task<Veiculo> BuscarPorModelo(string modelo)
        {
            return await _veiculoRepository.BuscarPorMarcar(modelo);
        }
    }

}

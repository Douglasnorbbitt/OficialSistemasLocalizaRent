using Dominio.Entidades;
using Dominio.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias
{
    public class AlterarVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public AlterarVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task Executar(int id, Veiculo veiculo)
        {
            var dadosDoVeiculo = await _veiculoRepository.BuscarPorId(id);

            dadosDoVeiculo.AtualizarDados(veiculo.Marca, veiculo.Modelo, veiculo.Data, veiculo.Quilometragem);

            await _veiculoRepository.Alterar(dadosDoVeiculo);
        }
    }
}
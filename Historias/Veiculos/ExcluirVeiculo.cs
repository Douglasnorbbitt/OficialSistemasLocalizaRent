using Dominio.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias
{
    public class ExcluirVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ExcluirVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task Executar(int id)
        {
            await _veiculoRepository.Excluir(id);
        }
    }
}
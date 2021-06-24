using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.IRepositories
{
    public interface IVeiculoRepository
    {

        Task Criar(Veiculo veiculo);
        Task Alterar(Veiculo veiculo);
        Task Excluir(Veiculo veiculo);
        Task<Veiculo> BuscarPorId(int id);
        Task<Veiculo> BuscarPorModelo(string modelo);
        Task<Veiculo> BuscarPorMarcar(string marcar);
        Task<IEnumerable<Veiculo>> ListarTodosVeiculos();
        Task Excluir(int id);

    }
}
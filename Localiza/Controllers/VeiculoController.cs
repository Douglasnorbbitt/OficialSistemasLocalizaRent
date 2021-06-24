using Dominio.IRepositories;
using Historias;
using Localiza.Factories;
using Localiza.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Controllers
{
    public class VeiculoController : ControllerBase
    {
        private readonly CriarVeiculo _criarVeiculo;
        private readonly ConsultarVeiculo _consultarVeiculo;
        private readonly AlterarVeiculo _alterarVeiculo;
        private readonly ExcluirVeiculo _excluirVeiculo;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _criarVeiculo = new CriarVeiculo(veiculoRepository);
            _consultarVeiculo = new ConsultarVeiculo(veiculoRepository);
            _alterarVeiculo = new AlterarVeiculo(veiculoRepository);
            _excluirVeiculo = new ExcluirVeiculo(veiculoRepository);

        }
        [HttpPost("criar-veiculo")]
        public async Task<IActionResult> Criar([FromBody] VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { mensagem = "Os campos são obrigatórios" });
            }

            var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);

            await _criarVeiculo.Executar(veiculo);

            return Ok(new { mensagem = "Veiculo Criado com sucesso!" });
        }

        [HttpGet("listar-veiculos")]
        public async Task<IEnumerable<VeiculoViewModel>> Listar()
        {
            var listaDeVeiculos = await _consultarVeiculo.ListarTodosVeiculos();

            if (listaDeVeiculos == null)
            {
                return null;
            }

            var listaVeiculovm = VeiculoFactory.MapearListaVeiculoViewModel(listaDeVeiculos);
            return listaVeiculovm;
        }
        [HttpGet("buscar-veiculo/{id}")]
        public async Task<VeiculoViewModel> Buscar(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPorId(id);

            if (veiculo == null)
            {
                return null;
            }

            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return veiculoViewModel;
        }
        [HttpGet("buscar-veiculo/{marca}")]
        public async Task<VeiculoViewModel> BuscarMarca(string marca)
        {
            var veiculo = await _consultarVeiculo.BuscarPorMarcar(marca);

            if (veiculo == null)
            {
                return null;
            }

            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return veiculoViewModel;
        }
        [HttpGet("buscar-veiculo/{modelo}")]
        public async Task<VeiculoViewModel> BuscarModelo(string modelo)
        {
            var veiculo = await _consultarVeiculo.BuscarPorModelo(modelo);

            if (veiculo == null)
            {
                return null;
            }

            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return veiculoViewModel;
        }

        [HttpPut("alterar-veiculo")]
        public async Task<IActionResult> Alterar([FromBody] VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { mensagem = "Os campos são obrigatorios" });
            }

            try
            {
                var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);

                await _alterarVeiculo.Executar(veiculoViewModel.Id, veiculo);

                return Ok(new { mensagem = "Veiculo alterado com sucesso" });
            }
            catch (System.Exception)
            {

                return BadRequest(new { erro = "Erro ao alterar o veiculo" });
            }

        }
        [HttpDelete("excluir-veiculo/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _excluirVeiculo.Executar(id);
                return Ok(new { mensagem = "Veiculo excluido com sucesso" });
            }
            catch (System.Exception)
            {

                return BadRequest(new { erro = "Erro ao excluir o veiculo" });
            }
        }
    }
}

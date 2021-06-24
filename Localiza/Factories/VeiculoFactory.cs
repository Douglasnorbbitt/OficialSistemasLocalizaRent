using Dominio.Entidades;
using Localiza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Factories
{
    public static class VeiculoFactory
    {
        public static Veiculo MapearVeiculo(VeiculoViewModel veiculoViewModel)
        {
            return new Veiculo(veiculoViewModel.Marca, veiculoViewModel.Modelo, veiculoViewModel.Data, veiculoViewModel.Quilometragem);
        }

        public static VeiculoViewModel MapearVeiculoViewModel(Veiculo veiculo)
        {
            return new VeiculoViewModel() { Id = veiculo.Id, Marca = veiculo.Marca, Modelo = veiculo.Modelo, Data = veiculo.Data, Quilometragem = veiculo.Quilometragem };
        }
        public static IEnumerable<VeiculoViewModel> MapearListaVeiculoViewModel(IEnumerable<Veiculo> lista)
        {
            var listaVeiculoViewModel = new List<VeiculoViewModel>();
            VeiculoViewModel veiculoVm;

            foreach (var item in lista)
            {
                veiculoVm = new VeiculoViewModel
                {
                    Id = item.Id,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Data = item.Data,
                    Quilometragem = item.Quilometragem

                };
                listaVeiculoViewModel.Add(veiculoVm);
            }
            return listaVeiculoViewModel;
        }
    }
}

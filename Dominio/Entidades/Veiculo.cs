using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Veiculo
    {
        public Veiculo(string marca, string modelo, DateTime data, string quilometragem)
        {
            Marca = marca;
            Modelo = modelo;
            Data = data;
            Quilometragem = quilometragem;
        }

        public int Id { get; private set; }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public DateTime Data { get; private set; }
        public string Quilometragem { get; private set; }

        public void AtualizarDados(string marca, string modelo, DateTime data, string quilometragem)
        {
            throw new NotImplementedException();
        }
    }

}

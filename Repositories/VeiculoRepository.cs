using System.Collections.Generic;
using System.Linq;
using Estacionamento.Models;

namespace Estacionamento.Repositories {

    /*
        Responsável por armazenar e buscar veículos.
        Os dados ficam em memória enquanto o programa roda.
    */

    public class VeiculoRepository {

        private readonly List<Veiculo> _veiculos =
            new List<Veiculo>();

        /*
            Adiciona um veículo à lista.
        */

        public void Inserir(Veiculo veiculo) {

            _veiculos.Add(veiculo);
        }

        /*
            Retorna todos os veículos cadastrados.
        */

        public List<Veiculo> Listar() {

            return _veiculos;
        }

        /*
            Busca um veículo pela placa.
        */

        public Veiculo BuscarPorPlaca(string placa) {

            return _veiculos.FirstOrDefault(
                v => v.Placa.ToUpper() == placa.ToUpper()
            );
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Estacionamento.Models;

namespace Estacionamento.Repositories {

    public class VeiculoRepository {

        private readonly List<Veiculo> _veiculos =
            new List<Veiculo>();


        public void Inserir(Veiculo veiculo) {

            _veiculos.Add(veiculo);
        }


        public List<Veiculo> Listar() {

            return _veiculos;
        }


        public Veiculo BuscarPorPlaca(string placa) {

            return _veiculos.FirstOrDefault(
                v => v.Placa.ToUpper() == placa.ToUpper()
            );
        }
    }
}

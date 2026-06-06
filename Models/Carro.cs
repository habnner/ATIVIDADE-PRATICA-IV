using Estacionamento.Enums;

namespace Estacionamento.Models {

    public class Carro : Veiculo {

        public override decimal ValorHora => 10m;

        public override decimal TaxaAdicional => 0m;

        public Carro() {

            Tipo = TipoVeiculo.Carro;
        }

        public override decimal CalcularValor(decimal horas) {

            return horas * ValorHora;
        }
    }
}

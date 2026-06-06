using Estacionamento.Enums;

namespace Estacionamento.Models {

    public class Moto : Veiculo {

        public override decimal ValorHora => 5m;

        public override decimal TaxaAdicional => 0m;

        public Moto() {

            Tipo = TipoVeiculo.Moto;
        }

        public override decimal CalcularValor(decimal horas) {

            return horas * ValorHora;
        }
    }
}

using Estacionamento.Enums;

namespace Estacionamento.Models {

    /*
        Representa um carro.
        Valor da hora: R$ 10. Sem taxa adicional.
    */

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

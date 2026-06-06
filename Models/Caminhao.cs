using Estacionamento.Enums;

namespace Estacionamento.Models {

    public class Caminhao : Veiculo {

        public override decimal ValorHora => 18m;

        public override decimal TaxaAdicional => 15m;

        public Caminhao() {

            Tipo = TipoVeiculo.Caminhao;
        }

        public override decimal CalcularValor(decimal horas) {

            return (horas * ValorHora) + TaxaAdicional;
        }
    }
}

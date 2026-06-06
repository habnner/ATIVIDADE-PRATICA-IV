using Estacionamento.Enums;

namespace Estacionamento.Models {

    /*
        Representa um caminhão.
        Valor da hora: R$ 18. Possui taxa de carga: R$ 15.
    */

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

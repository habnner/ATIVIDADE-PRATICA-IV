using Estacionamento.Enums;

namespace Estacionamento.Models {

    /*
        Representa um veículo genérico.
        Cada tipo de veículo herda dessa classe.
    */

    public abstract class Veiculo {

        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public TipoVeiculo Tipo { get; set; }

        /*
            Cada tipo de veículo define seu valor por hora.
        */

        public abstract decimal ValorHora { get; }

        /*
            Cada tipo de veículo define sua taxa adicional.
        */

        public abstract decimal TaxaAdicional { get; }

        /*
            Calcula o valor total baseado nas horas.
        */

        public abstract decimal CalcularValor(decimal horas);
    }
}

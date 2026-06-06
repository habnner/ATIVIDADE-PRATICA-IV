using Estacionamento.Enums;

namespace Estacionamento.Models {

    public abstract class Veiculo {

        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public TipoVeiculo Tipo { get; set; }

        public abstract decimal ValorHora { get; }

        public abstract decimal TaxaAdicional { get; }


        public abstract decimal CalcularValor(decimal horas);
    }
}

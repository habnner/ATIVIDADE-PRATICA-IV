using System;
using Estacionamento.Enums;

namespace Estacionamento.Models {

    public class Pagamento {

        public TipoPagamento Tipo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataHora { get; set; }

        public bool ValidarValor(decimal valorDevido) {

            return Valor >= valorDevido;
        }
    }
}

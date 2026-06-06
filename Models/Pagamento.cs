using System;
using Estacionamento.Enums;

namespace Estacionamento.Models {

    /*
        Representa o pagamento de um ticket.
    */

    public class Pagamento {

        public TipoPagamento Tipo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataHora { get; set; }

        /*
            Valida se o valor informado cobre o total.
        */

        public bool ValidarValor(decimal valorDevido) {

            return Valor >= valorDevido;
        }
    }
}

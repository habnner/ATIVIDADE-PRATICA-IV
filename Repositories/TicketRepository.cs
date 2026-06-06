using System.Collections.Generic;
using System.Linq;
using Estacionamento.Models;

namespace Estacionamento.Repositories {

    public class TicketRepository {

        private readonly List<Ticket> _tickets =
            new List<Ticket>();

        private int _proximoId = 1;

        private int _proximaVaga = 1;


        public Ticket Inserir(Ticket ticket) {

            ticket.Id = _proximoId++;

            ticket.Vaga = _proximaVaga++;

            _tickets.Add(ticket);

            return ticket;
        }


        public List<Ticket> Listar() {

            return _tickets;
        }


        public Ticket BuscarAbertoPorPlaca(string placa) {

            return _tickets.FirstOrDefault(
                t =>
                    t.Veiculo.Placa.ToUpper() == placa.ToUpper()
                    && t.Pago == false
                    && t.HoraSaida == null
            );
        }


        public void Atualizar(Ticket ticket) {

            int indice = _tickets.FindIndex(
                t => t.Id == ticket.Id
            );

            if (indice >= 0) {

                _tickets[indice] = ticket;
            }
        }
    }
}

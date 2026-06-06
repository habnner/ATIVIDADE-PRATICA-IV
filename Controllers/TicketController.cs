using System;
using Estacionamento.Enums;
using Estacionamento.Models;
using Estacionamento.Repositories;

namespace Estacionamento.Controllers {

    /*
        Controla entrada e saída de veículos.
    */

    public class TicketController {

        private readonly TicketRepository _ticketRepository =
            new TicketRepository();

        private readonly VeiculoRepository _veiculoRepository;

        public TicketController(
            VeiculoRepository veiculoRepository
        ) {

            _veiculoRepository = veiculoRepository;
        }

        /*
            Registra a entrada de um veículo.
        */

        public void RegistrarEntrada() {

            Console.Write("Placa do veículo: ");

            string placa = Console.ReadLine();

            Veiculo veiculo =
                _veiculoRepository.BuscarPorPlaca(placa);

            if (veiculo == null) {

                Console.WriteLine(
                    "Veículo não encontrado. Cadastre o veículo primeiro."
                );

                return;
            }

            Ticket ticketExistente =
                _ticketRepository.BuscarAbertoPorPlaca(placa);

            if (ticketExistente != null) {

                Console.WriteLine(
                    "Este veículo já está no estacionamento"
                );

                return;
            }

            var ticket = new Ticket {

                Veiculo = veiculo,
                HoraEntrada = DateTime.Now,
                Pago = false
            };

            _ticketRepository.Inserir(ticket);

            Console.WriteLine(
                $"\nTicket gerado!"
            );

            Console.WriteLine(
                $"Ticket Nº: {ticket.Id}"
            );

            Console.WriteLine(
                $"Vaga: {ticket.Vaga}"
            );

            Console.WriteLine(
                $"Entrada: {ticket.HoraEntrada:dd/MM/yyyy HH:mm}"
            );
        }

        /*
            Registra a saída e processa o pagamento.
        */

        public void RegistrarSaida() {

            Console.Write("Placa do veículo: ");

            string placa = Console.ReadLine();

            Ticket ticket =
                _ticketRepository.BuscarAbertoPorPlaca(placa);

            if (ticket == null) {

                Console.WriteLine(
                    "Nenhum ticket em aberto para esta placa"
                );

                return;
            }

            ticket.HoraSaida = DateTime.Now;

            decimal horas = ticket.CalcularHoras();

            decimal valorTotal =
                ticket.Veiculo.CalcularValor(horas);

            Console.WriteLine(
                $"\n--- Resumo ---"
            );

            Console.WriteLine(
                $"Placa: {ticket.Veiculo.Placa}"
            );

            Console.WriteLine(
                $"Entrada: {ticket.HoraEntrada:dd/MM/yyyy HH:mm}"
            );

            Console.WriteLine(
                $"Saída: {ticket.HoraSaida:dd/MM/yyyy HH:mm}"
            );

            Console.WriteLine(
                $"Horas cobradas: {horas}"
            );

            if (horas == 0) {

                Console.WriteLine(
                    "Dentro da tolerância (até 15 min). Sem cobrança."
                );

                ticket.Pago = true;

                _ticketRepository.Atualizar(ticket);

                return;
            }

            if (ticket.Veiculo.TaxaAdicional > 0) {

                Console.WriteLine(
                    $"Taxa adicional: R$ {ticket.Veiculo.TaxaAdicional:F2}"
                );
            }

            Console.WriteLine(
                $"Valor total: R$ {valorTotal:F2}"
            );

            Console.WriteLine("\nForma de pagamento:");
            Console.WriteLine("1 - Dinheiro");
            Console.WriteLine("2 - Cartao");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            TipoPagamento tipoPagamento;

            switch (opcao) {

                case "1":
                    tipoPagamento = TipoPagamento.Dinheiro;
                    break;

                case "2":
                    tipoPagamento = TipoPagamento.Cartao;
                    break;

                default:
                    Console.WriteLine(
                        "Forma de pagamento inválida"
                    );
                    return;
            }

            Console.Write(
                $"Valor informado (R$): "
            );

            decimal valorInformado =
                Convert.ToDecimal(
                    Console.ReadLine()
                );

            var pagamento = new Pagamento {

                Tipo = tipoPagamento,
                Valor = valorInformado,
                DataHora = DateTime.Now
            };

            if (!pagamento.ValidarValor(valorTotal)) {

                Console.WriteLine(
                    "Valor insuficiente. Pagamento não realizado."
                );

                return;
            }

            ticket.Pagamento = pagamento;
            ticket.Pago = true;

            _ticketRepository.Atualizar(ticket);

            decimal troco = valorInformado - valorTotal;

            Console.WriteLine(
                "\nPagamento registrado com sucesso!"
            );

            if (troco > 0 && tipoPagamento == TipoPagamento.Dinheiro) {

                Console.WriteLine(
                    $"Troco: R$ {troco:F2}"
                );
            }
        }

        /*
            Lista todos os tickets registrados.
        */

        public void Listar() {

            var lista = _ticketRepository.Listar();

            if (lista.Count == 0) {

                Console.WriteLine(
                    "Nenhum ticket registrado"
                );

                return;
            }

            Console.WriteLine(
                "--- Tickets ---"
            );

            foreach (var t in lista) {

                string status = t.Pago ? "PAGO" : "EM ABERTO";

                Console.WriteLine(
                    $"Ticket {t.Id} | Vaga {t.Vaga} | {t.Veiculo.Placa} | {status}"
                );
            }
        }
    }
}

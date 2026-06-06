using System;
using Estacionamento.Controllers;

namespace Estacionamento {

    /*
        Ponto inicial do sistema de estacionamento.
    */

    class Program {

        static void Main(string[] args) {

            var veiculoController =
                new VeiculoController();

            var ticketController =
                new TicketController(
                    veiculoController.ObterRepository()
                );

            while (true) {

                Console.WriteLine();
                Console.WriteLine("=== Estacionamento ===");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Listar veículos");
                Console.WriteLine("3 - Registrar entrada");
                Console.WriteLine("4 - Registrar saída");
                Console.WriteLine("5 - Listar tickets");
                Console.WriteLine("0 - Sair");

                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                Console.WriteLine();

                switch (opcao) {

                    case "1":
                        veiculoController.Cadastrar();
                        break;

                    case "2":
                        veiculoController.Listar();
                        break;

                    case "3":
                        ticketController.RegistrarEntrada();
                        break;

                    case "4":
                        ticketController.RegistrarSaida();
                        break;

                    case "5":
                        ticketController.Listar();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine(
                            "Opção inválida"
                        );
                        break;
                }
            }
        }
    }
}

using System;
using Estacionamento.Models;
using Estacionamento.Repositories;

namespace Estacionamento.Controllers {

    public class VeiculoController {

        private readonly VeiculoRepository _repository =
            new VeiculoRepository();

        public void Cadastrar() {

            Console.Write("Placa: ");
            string placa = Console.ReadLine();

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Cor: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Tipo:");
            Console.WriteLine("1 - Carro");
            Console.WriteLine("2 - Moto");
            Console.WriteLine("3 - Caminhao");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            Veiculo veiculo;

            switch (opcao) {

                case "1":
                    veiculo = new Carro();
                    break;

                case "2":
                    veiculo = new Moto();
                    break;

                case "3":
                    veiculo = new Caminhao();
                    break;

                default:
                    Console.WriteLine(
                        "Tipo inválido"
                    );
                    return;
            }

            veiculo.Placa = placa.ToUpper();
            veiculo.Modelo = modelo;
            veiculo.Cor = cor;

            _repository.Inserir(veiculo);

            Console.WriteLine(
                "Veículo cadastrado com sucesso"
            );
        }

        public void Listar() {

            var lista = _repository.Listar();

            if (lista.Count == 0) {

                Console.WriteLine(
                    "Nenhum veículo cadastrado"
                );

                return;
            }

            Console.WriteLine(
                "--- Veículos ---"
            );

            foreach (var v in lista) {

                Console.WriteLine(
                    $"{v.Placa} | {v.Modelo} | {v.Cor} | {v.Tipo}"
                );
            }
        }

        public VeiculoRepository ObterRepository() {

            return _repository;
        }
    }
}

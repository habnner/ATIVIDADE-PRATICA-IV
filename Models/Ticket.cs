using System;

namespace Estacionamento.Models {

    public class Ticket {

        public int Id { get; set; }

        public Veiculo Veiculo { get; set; }

        public int Vaga { get; set; }

        public DateTime HoraEntrada { get; set; }

        public DateTime? HoraSaida { get; set; }

        public bool Pago { get; set; }

        public Pagamento Pagamento { get; set; }

        public decimal CalcularHoras() {

            if (HoraSaida == null) {

                return 0;
            }

            TimeSpan permanencia =
                HoraSaida.Value - HoraEntrada;

            double minutos = permanencia.TotalMinutes;


            if (minutos <= 15) {

                return 0;
            }

            double horas = permanencia.TotalHours;


            int horasInteiras = (int)horas;

            double minutosFracao =
                (horas - horasInteiras) * 60;

            if (minutosFracao > 30) {

                horasInteiras += 1;
            }

            if (horasInteiras == 0) {

                horasInteiras = 1;
            }

            return horasInteiras;
        }
    }
}

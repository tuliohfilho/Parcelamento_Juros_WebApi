using System;

namespace ParcelamentoJurosWebApi.Models {
    public class Parcela
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }
        public decimal Juros { get; set; }
        public DateTime? Vencimento { get; set; }


        public virtual Simulacao Simulacao { get; set; }
        public int SimulacaoId { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace ParcelamentoJurosWebApi.Models {
    public class Simulacao
    {
        public int Id { get; set; }

        public decimal ValorCompra { get; set; }
        public decimal Juros { get; set; }
        public decimal Total { get; set; }
        public int QuantidadeParecelas { get; set; }
        public DateTime? DataCompra { get; set; }


        public ICollection<Parcela> Parcelas { get; set; }
    }
}
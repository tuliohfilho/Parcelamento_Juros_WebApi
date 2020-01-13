using System;
using System.Collections.Generic;
using ParcelamentoJurosWebApi.Models;

namespace ParcelamentoJurosWebApi.ViewModels {
    public class SimulacaoViewModel
    {
        public int Id { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorTotal { get; set; }
        public int QuantidadeParecelas { get; set; }
        public string DataCompra { get; set; }


        public IEnumerable<ParcelaViewModel> Parcelas { get; set; }



        internal void AffterMap(Simulacao origin) {
            if (origin == null)
                return;

            ValorJuros = origin.Juros;
            ValorTotal = origin.Total;
            DataCompra = origin.DataCompra.Value.ToShortDateString();
        }
    }
}
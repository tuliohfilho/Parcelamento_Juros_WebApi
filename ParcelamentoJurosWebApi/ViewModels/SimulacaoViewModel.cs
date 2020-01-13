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

            var day = origin.DataCompra.Value.Day;
            var dia = day.ToString();
            if (day < 10)
                dia = $"0{day.ToString()}";

            var month = origin.DataCompra.Value.Month;
            var mes = month.ToString();
            if (month < 10)
                mes = $"0{month.ToString()}";

            var ano = origin.DataCompra.Value.Year;

            ValorJuros = origin.Juros;
            ValorTotal = origin.Total;
            DataCompra = $"{dia}/{mes}/{ano}";
        }
    }
}
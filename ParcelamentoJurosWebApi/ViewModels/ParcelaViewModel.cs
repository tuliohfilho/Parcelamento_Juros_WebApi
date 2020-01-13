using ParcelamentoJurosWebApi.Models;

namespace ParcelamentoJurosWebApi.ViewModels {
    public class ParcelaViewModel {
        public int Id { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorJuros { get; set; }
        public string DataVencimento { get; set; }



        internal void AffterMap(Parcela origin) {
            if (origin == null)
                return;

            var day = origin.Vencimento.Value.Day;
            var month = origin.Vencimento.Value.Month;
            var ano = origin.Vencimento.Value.Year;

            var dia = day.ToString();
            if (day < 10)
                dia = $"0{dia}";

            var mes = month.ToString();
            if (month < 10)
                mes = $"0{mes}";

            ValorParcela = origin.Valor;
            ValorJuros = origin.Juros;
            DataVencimento = $"{dia}/{mes}/{ano}";
        }
    }
}
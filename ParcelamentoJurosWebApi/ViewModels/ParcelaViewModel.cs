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
            var dia = day.ToString();
            if (day < 10)
                dia = $"0{day.ToString()}";

            var month = origin.Vencimento.Value.Month;
            var mes = month.ToString();
            if (month < 10)
                mes = $"0{month.ToString()}";

            var ano = origin.Vencimento.Value.Year;

            ValorParcela = origin.Valor;
            ValorJuros = origin.Juros;
            DataVencimento = $"{dia}/{mes}/{ano}";
        }
    }
}
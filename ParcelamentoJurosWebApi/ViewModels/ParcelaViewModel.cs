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

            ValorParcela = origin.Valor;
            ValorJuros = origin.Juros;
            DataVencimento = origin.Vencimento.Value.ToShortDateString();
        }
    }
}
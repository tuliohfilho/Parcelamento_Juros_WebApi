using System.Collections.Generic;
using System.Linq;
using ParcelamentoJurosWebApi.Models;
using ParcelamentoJurosWebApi.Repositories;

namespace ParcelamentoJurosWebApi.Services.Impl {
    public class SimulacaoService : ISimulacaoService {
        private readonly ISimulacaoRepository _repository;

        public SimulacaoService(ISimulacaoRepository repository) {
            _repository = repository;
        }

        public IQueryable<Simulacao> ObterPorCpf(string cpf) =>
            _repository.ObterPorCpf(cpf);

        public Simulacao SimularParcelas(Simulacao simulacao) {
            var parcelas = GeraParcelas(simulacao);

            simulacao.Parcelas = parcelas.ToList();
            simulacao.Total = parcelas.Sum(x => x.Valor);

            return simulacao;
        }
        private IEnumerable<Parcela> GeraParcelas(Simulacao simulacao) {
            var controle = 0;
            var dataCompra = simulacao.DataCompra.Value;
            var valorJuros = (simulacao.ValorCompra * simulacao.Juros) / 100;
            var valorParcela = (simulacao.ValorCompra + valorJuros) / simulacao.QuantidadeParecelas;

            var parcelas =
                    Enumerable.Range(1, simulacao.QuantidadeParecelas)
                        .Select(x => {
                            var vencimento = dataCompra;

                            if (controle > 0)
                                vencimento = vencimento.AddDays(controle);

                            controle++;

                            return new Parcela {
                                Valor = valorParcela,
                                Vencimento = vencimento,
                                Juros = simulacao.Juros,
                            };
                        }).ToList();

            return parcelas;
        }

        public Simulacao Save(Simulacao simulacao) =>
            _repository.Save(simulacao);
    }
}
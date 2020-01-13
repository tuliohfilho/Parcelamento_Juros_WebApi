using ParcelamentoJurosWebApi.Infraestrutura;
using ParcelamentoJurosWebApi.Models;
using System;
using System.Linq;

namespace ParcelamentoJurosWebApi.Repositories.Impl {
    public class SimulacaoRepository : ISimulacaoRepository {
        private readonly ParcelamentoJurosContext _context;

        public SimulacaoRepository(ParcelamentoJurosContext context) {
            _context = context;
        }


        public IQueryable<Simulacao> ObterPorCpf(string cpf) {
            var simulacoes = Enumerable.Range(1, 5)
                              .Select(simulacao => new Simulacao {
                                  Parcelas = Enumerable.Range(1, 5)
                                              .Select(parcela => new Parcela {
                                                  Id = parcela,
                                                  Valor = 35.89M,
                                                  Juros = 12.7854M,
                                                  Vencimento = DateTime.Now,
                                              }).ToList(),
                                  Id = simulacao,
                                  ValorCompra = 358.00M,
                                  Juros = 12.7854M,
                                  Total = 358.98M,
                                  QuantidadeParecelas = 10,
                                  DataCompra = DateTime.Now
                              }).ToList();

            return simulacoes.AsQueryable();
        }


        public Simulacao Save(Simulacao simulacao) {
            _context.Simulacao.Add(simulacao);

            SaveChanges();

            return simulacao;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
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

        public Simulacao Save(Simulacao simulacao) => 
            _repository.Save(simulacao);
    }
}
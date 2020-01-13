using ParcelamentoJurosWebApi.Models;
using System.Linq;

namespace ParcelamentoJurosWebApi.Repositories {
    public interface ISimulacaoRepository {
        Simulacao Save(Simulacao simulacao);
        IQueryable<Simulacao> ObterPorCpf(string cpf);
    }
}
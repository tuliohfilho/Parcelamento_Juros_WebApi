using ParcelamentoJurosWebApi.Models;
using System.Linq;

namespace ParcelamentoJurosWebApi.Repositories {
    public interface ISimulacaoRepository {
        IQueryable<Simulacao> ObterPorCpf(string cpf);
    }
}
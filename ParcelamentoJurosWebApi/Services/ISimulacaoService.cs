using ParcelamentoJurosWebApi.Models;
using System.Linq;

namespace ParcelamentoJurosWebApi.Services {
    public interface ISimulacaoService {
        IQueryable<Simulacao> ObterPorCpf(string cpf);
    }
}
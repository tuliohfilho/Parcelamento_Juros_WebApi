using ParcelamentoJurosWebApi.Models;
using System.Linq;

namespace ParcelamentoJurosWebApi.Services {
    public interface ISimulacaoService {
        Simulacao Save(Simulacao simulacao);
        IQueryable<Simulacao> ObterPorCpf(string cpf);
        Simulacao SimularParcelas(Simulacao simulacao);
    }
}
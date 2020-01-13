using ParcelamentoJurosWebApi.Infraestrutura;

namespace ParcelamentoJurosWebApi.Repositories.Impl {
    public class SimuladorRepository : ISimuladorRepository {
        private readonly ParcelamentoJurosContext _context;

        public SimuladorRepository(ParcelamentoJurosContext context) {
            _context = context;
        }
    }
}
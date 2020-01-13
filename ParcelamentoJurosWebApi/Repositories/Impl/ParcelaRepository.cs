using ParcelamentoJurosWebApi.Infraestrutura;

namespace ParcelamentoJurosWebApi.Repositories.Impl {
    public class ParcelaRepository : IParcelaRepository {
        private readonly ParcelamentoJurosContext _context;

        public ParcelaRepository(ParcelamentoJurosContext context) {
            _context = context;
        }
    }
}
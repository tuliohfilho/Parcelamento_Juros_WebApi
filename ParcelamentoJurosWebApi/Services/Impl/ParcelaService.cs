using ParcelamentoJurosWebApi.Repositories;

namespace ParcelamentoJurosWebApi.Services.Impl {
    public class ParcelaService : IParcelaService {
        private readonly IParcelaRepository _repository;

        public ParcelaService(IParcelaRepository repository) {
            _repository = repository;
        }
    }
}
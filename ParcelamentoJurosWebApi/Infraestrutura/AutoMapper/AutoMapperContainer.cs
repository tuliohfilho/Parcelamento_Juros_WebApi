using AutoMapper;
using ParcelamentoJurosWebApi.Models;
using ParcelamentoJurosWebApi.ViewModels;

namespace ParcelamentoJurosWebApi.Infraestrutura.AutoMapper {
    public static class AutoMapperContainer {
        public static void Initialize() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<SimulacaoPostViewModel, Simulacao>();

                cfg.CreateMap<Parcela, ParcelaViewModel>().AfterMap((origin, src) => src.AffterMap(origin));
                cfg.CreateMap<Simulacao, SimulacaoViewModel>().AfterMap((origin, src) => src.AffterMap(origin));
            });
        }
    }
}
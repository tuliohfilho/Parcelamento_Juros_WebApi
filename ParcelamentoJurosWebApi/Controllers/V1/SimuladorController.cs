using Microsoft.AspNetCore.Mvc;
using ParcelamentoJurosWebApi.Infraestrutura;
using System;
using System.Linq;

namespace ParcelamentoJurosWebApi.Controllers.V1 {
    [Route("api/v1/[controller]")]
    public class SimuladorController : Controller {
        private readonly ParcelamentoJurosContext _context;

        public SimuladorController(ParcelamentoJurosContext context) {
            _context = context;
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult Get() {
            var simulacoes = Enumerable.Range(1, 5)
                                .Select(simulacao => new {
                                    Parcelas = Enumerable.Range(1, 5)
                                                .Select(parcela => new {
                                                    Id = parcela,
                                                    ValorParcela = "35,89",
                                                    ValorJuros = "12,7854",
                                                    DataVencimento = DateTime.Now.ToShortDateString(),
                                                }).ToList(),
                                    Id = simulacao,
                                    ValorCompra = "358,00",
                                    ValorJuros = "12,7854",
                                    ValorTotal = "358,98",
                                    QuantidadeParecelas = 10,
                                    DataCompra = DateTime.Now.ToShortDateString()
                                }).ToList();

            return Ok(simulacoes);
        }

        [HttpPost]
        public IActionResult Post([FromBody]dynamic value) {
            var valorJuros = ((decimal)value.valorTotal * (decimal)value.valorJuros) / 100;
            var valorParcela = ((decimal)value.valorTotal + valorJuros) / (int)value.qtoParcelas;
            var dataCompra = (DateTime)value.dataCompra;
            var controle = 0;

            var list = Enumerable.Range(1, (int)value.qtoParcelas)
                        .Select(x => {
                            var vencimento = dataCompra;

                            if (controle > 0)
                                vencimento = vencimento.AddMonths(controle);

                            controle++;

                            return new {
                                Id = x,
                                ValorParcela = valorParcela,
                                ValorJuros = (decimal)value.valorJuros,
                                DataVencimento = vencimento.ToShortDateString(),
                            };
                        }).ToList();

            var valorTotal = list.Sum(x => x.ValorParcela);
            var result = new {
                Parcelas = list,

                Id = 1,
                ValorTotal = valorTotal,
                ValorJuros = (decimal)value.valorJuros,
                ValorCompra = (decimal)value.valorTotal,
                DataCompra = dataCompra.ToShortDateString(),
                QuantidadeParecelas = (int)value.qtoParcelas
            };

            return Ok(result);
        }
    }
}
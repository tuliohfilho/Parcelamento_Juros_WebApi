using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelamentoJurosWebApi.Models;
using ParcelamentoJurosWebApi.Services;
using ParcelamentoJurosWebApi.ViewModels;
using System;
using System.Linq;

namespace ParcelamentoJurosWebApi.Controllers.V1 {
    [Route("api/v1/[controller]")]
    public class SimuladorController : Controller {
        private readonly ISimulacaoService _simulacaoService;

        public SimuladorController(ISimulacaoService simulacaoService) {
            _simulacaoService = simulacaoService;
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult Get(string cpf) {
            //var simulacoes = Enumerable.Range(1, 5)
            //                    .Select(simulacao => new {
            //                        Parcelas = Enumerable.Range(1, 5)
            //                                    .Select(parcela => new {
            //                                        Id = parcela,
            //                                        ValorParcela = "35,89",
            //                                        ValorJuros = "12,7854",
            //                                        DataVencimento = DateTime.Now.ToShortDateString(),
            //                                    }).ToList(),
            //                        Id = simulacao,
            //                        ValorCompra = "358,00",
            //                        ValorJuros = "12,7854",
            //                        ValorTotal = "358,98",
            //                        QuantidadeParecelas = 10,
            //                        DataCompra = DateTime.Now.ToShortDateString()
            //                    }).ToList();

            return Ok(_simulacaoService.ObterPorCpf(cpf));
        }

        [HttpPost]
        public IActionResult Post([FromBody]SimuladorPostViewModel viewModel) {
            try {
                if (!ModelState.IsValid)
                    return ErrorMessage();

                var simulacao = _simulacaoService.Save(new Simulacao());

                return Ok(simulacao);
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPost]
        //public IActionResult Post([FromBody]dynamic value) {
        //    var valorJuros = ((decimal)value.valorTotal * (decimal)value.valorJuros) / 100;
        //    var valorParcela = ((decimal)value.valorTotal + valorJuros) / (int)value.qtoParcelas;
        //    var dataCompra = (DateTime)value.dataCompra;
        //    var controle = 0;

        //    var list = Enumerable.Range(1, (int)value.qtoParcelas)
        //                .Select(x => {
        //                    var vencimento = dataCompra;

        //                    if (controle > 0)
        //                        vencimento = vencimento.AddMonths(controle);

        //                    controle++;

        //                    return new {
        //                        Id = x,
        //                        ValorParcela = valorParcela,
        //                        ValorJuros = (decimal)value.valorJuros,
        //                        DataVencimento = vencimento.ToShortDateString(),
        //                    };
        //                }).ToList();

        //    var valorTotal = list.Sum(x => x.ValorParcela);
        //    var result = new {
        //        Parcelas = list,

        //        Id = 1,
        //        ValorTotal = valorTotal,
        //        ValorJuros = (decimal)value.valorJuros,
        //        ValorCompra = (decimal)value.valorTotal,
        //        DataCompra = dataCompra.ToShortDateString(),
        //        QuantidadeParecelas = (int)value.qtoParcelas
        //    };

        //    return Ok(result);
        //}


        private ActionResult ErrorMessage() {
            var errors = string.Join(" ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));

            return BadRequest(errors);
        }
    }
}
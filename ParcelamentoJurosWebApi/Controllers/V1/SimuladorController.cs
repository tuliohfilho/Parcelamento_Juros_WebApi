using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelamentoJurosWebApi.Models;
using ParcelamentoJurosWebApi.Services;
using ParcelamentoJurosWebApi.ViewModels;
using System;
using System.Collections.Generic;
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
            try {
                if (!ModelState.IsValid)
                    return ErrorMessage();

                var simulacoes = _simulacaoService.ObterPorCpf(cpf).ToList();

                return Ok(Mapper.Map<IEnumerable<SimulacaoViewModel>>(simulacoes));
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]SimulacaoPostViewModel viewModel) {
            try {
                if (!ModelState.IsValid)
                    return ErrorMessage();

                var simulacao = Mapper.Map<Simulacao>(viewModel);
                simulacao.DataCompra = new DateTime(viewModel.AnoCompra, viewModel.MesCompra, viewModel.DiaCompra);

                simulacao = _simulacaoService.SimularParcelas(simulacao);
                if (viewModel.SalvarSimulacao)
                    simulacao = _simulacaoService.Save(simulacao);

                return Ok(Mapper.Map<SimulacaoViewModel>(simulacao));
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        private ActionResult ErrorMessage() {
            var errors = string.Join(" ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));

            return BadRequest(errors);
        }
    }
}
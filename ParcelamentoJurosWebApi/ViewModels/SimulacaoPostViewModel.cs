using Newtonsoft.Json;
using ParcelamentoJurosWebApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ParcelamentoJurosWebApi.ViewModels {
    public class SimulacaoPostViewModel
    {
        [Required]
        [JsonProperty("valorTotal")]
        public decimal ValorCompra { get; set; }

        [Required]
        [JsonProperty("valorJuros")]
        public decimal Juros { get; set; }

        [Required]
        [JsonProperty("qtoParcelas")]
        public int QuantidadeParecelas { get; set; }

        [Required]
        [JsonProperty("dataCompra")]
        public string DataCompra { get; set; }

        [JsonProperty("cpfComprador")]
        public string CpfComprador { get; set; }

        [JsonProperty("salvarSimulacao")]
        public bool SalvarSimulacao { get; set; }
    }
}
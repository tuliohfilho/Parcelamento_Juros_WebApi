using Microsoft.EntityFrameworkCore;
using ParcelamentoJurosWebApi.Infraestrutura;
using ParcelamentoJurosWebApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ParcelamentoJurosWebApi.Repositories.Impl {
    public class SimulacaoRepository : ISimulacaoRepository {
        private readonly ParcelamentoJurosContext _context;

        public SimulacaoRepository(ParcelamentoJurosContext context) {
            _context = context;
        }


        public IQueryable<Simulacao> ObterPorCpf(string cpf) {
            return Query(x => x.CpfComprador.Equals(cpf))
                    .Include(x => x.Parcelas);
        }

        public Simulacao Save(Simulacao simulacao) {
            _context.Simulacao.Add(simulacao);

            SaveChanges();

            return simulacao;
        }


        private IQueryable<Simulacao> Query(Expression<Func<Simulacao, bool>> filter) => 
            List().Where(filter);

        private IQueryable<Simulacao> List() =>
            _context.Set<Simulacao>();

        private void SaveChanges() => 
            _context.SaveChanges();
    }
}
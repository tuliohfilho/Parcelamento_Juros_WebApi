using Microsoft.EntityFrameworkCore;
using ParcelamentoJurosWebApi.Models;
using System.Linq;

namespace ParcelamentoJurosWebApi.Infraestrutura {
    public class ParcelamentoJurosContext : DbContext {
        public ParcelamentoJurosContext(DbContextOptions<ParcelamentoJurosContext> options)
          : base(options) {
            //Database.Migrate();
            Database.EnsureCreated();
        }


        public DbSet<Simulacao> Simulacao { get; set; }
        public DbSet<Parcela> Parcela { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            EntidadeConfiguracao.InitializeMapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
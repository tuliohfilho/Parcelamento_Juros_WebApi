using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParcelamentoJurosWebApi.Models;

namespace ParcelamentoJurosWebApi.Infraestrutura {
    public static class EntidadeConfiguracao {
        public static void InitializeMapping(ModelBuilder modelBuilder) {
            SimulacaoMapping(modelBuilder.Entity<Simulacao>());
            ParcelaMapping(modelBuilder.Entity<Parcela>());
        }


        private static void SimulacaoMapping(EntityTypeBuilder<Simulacao> entity) {
            entity.ToTable("Simulacao");

            entity.HasKey(x => x.Id);

            entity.Property(p => p.ValorCompra)
                .HasColumnName("ValorCompra")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Juros)
                .HasColumnName("Juros")
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            entity.Property(p => p.Total)
                .HasColumnName("Total")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.QuantidadeParecelas)
                .HasColumnName("QuantidadeParecelas")
                .IsRequired()
                .HasColumnType("int");

            entity.Property(p => p.DataCompra)
              .HasColumnName("DataCompra")
              .HasColumnType("datetime2(7)");

            entity.Property(x => x.CpfComprador)
                .HasColumnName("CpfComprador")
                .HasMaxLength(14)
                .HasColumnType("nvarchar(14)");
        }

        private static void ParcelaMapping(EntityTypeBuilder<Parcela> entity) {
            entity.ToTable("Parcela");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Valor)
                .HasColumnName("ValorCompra")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.Juros)
                .HasColumnName("Juros")
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            entity.Property(x => x.Vencimento)
              .HasColumnName("DataCompra")
              .HasColumnType("datetime2(7)");


            entity.HasOne(x => x.Simulacao)
                   .WithMany(x => x.Parcelas)
                   .HasForeignKey(x => x.SimulacaoId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteIara.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Infrastructure.Mappings
{
    public class CotacaoMap : IEntityTypeConfiguration<CotacaoEntity>
    {
        public void Configure(EntityTypeBuilder<CotacaoEntity> builder)
        {
            builder.ToTable("Cotacao");
            builder.HasKey(k => k.NumeroCotacao);

            builder.Property(p => p.NumeroCotacao)
                .HasColumnName("NumeroCotacao")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.CNPJComprador)
                .HasColumnName("CNPJComprador")
                .IsRequired();

            builder.Property(p => p.CNPJFornecedor)
                .HasColumnName("CNPJFornecedor")
                .IsRequired();

            builder.Property(p => p.DataCotacao)
                .HasColumnName("DataCotacao")
                .IsRequired();

            builder.Property(p => p.DataEntregaCotacao)
                .HasColumnName("DataEntregaCotacao")
                .IsRequired();

            builder.Property(p => p.CEP)
                .HasColumnName("CEP")
                .IsRequired();

            builder.Property(p => p.Logradouro)
            .HasColumnName("Logradouro");

            builder.Property(p => p.Complemento)
             .HasColumnName("Complemento");

            builder.Property(p => p.Bairro)
               .HasColumnName("Bairro");

            builder.Property(p => p.UF)
                .HasColumnName("UF");

            builder.Property(p => p.Observacao)
                .HasColumnName("Observacao");

            builder.HasMany(fk => fk.CotacaoItems)
                .WithOne(fk => fk.CotacaoEntity)
                .HasForeignKey(fk => fk.NumeroCotacao);
        }
    }
}
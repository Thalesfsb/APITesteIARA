using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Infrastructure.Mappings
{
    public class CotacaoItemMap : IEntityTypeConfiguration<CotacaoItemEntity>
    {
        public void Configure(EntityTypeBuilder<CotacaoItemEntity> builder)
        {
            builder.ToTable("CotacaoItem");
            builder.HasKey(k => k.NumeroCotacaoItem);

            builder.Property(p => p.NumeroCotacaoItem)
                .HasColumnName("NumeroCotacaoItem")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.NumeroCotacao)
                .HasColumnName("NumeroCotacao");

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();

            builder.Property(p => p.NumeroItem)
                .HasColumnName("NumeroItem")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("Preco");

            builder.Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            builder.Property(p => p.Marca)
                .HasColumnName("Marca");

            builder.Property(p => p.Unidade)
                .HasColumnName("Unidade");

            builder.HasOne(fk => fk.CotacaoEntity)
                .WithMany(fk => fk.CotacaoItems)
                .HasForeignKey(fk => fk.NumeroCotacao);
        }
    }
}

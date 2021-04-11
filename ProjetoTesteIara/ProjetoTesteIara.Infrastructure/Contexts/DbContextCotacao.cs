using Microsoft.EntityFrameworkCore;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Contexts;
using ProjetoTesteIara.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Infrastructure.Contexts
{
    public class DbContextCotacao : DbContext, IDbContextCotacao
    {
        public DbContextCotacao(DbContextOptions options) : base(options) => this.Database.EnsureCreated();
        public DbSet<CotacaoEntity> Cotacao { get; set; }
        public DbSet<CotacaoItemEntity> CotacaoItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CotacaoItemMap());
            modelBuilder.ApplyConfiguration(new CotacaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

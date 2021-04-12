using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Repositories;
using ProjetoTesteIara.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Infrastructure.Repositories
{
    public class CotacaoRepository : Repository<CotacaoEntity>, ICotacaoRepository
    {
        private readonly DbContextCotacao _dbContext;
        public CotacaoRepository(DbContextCotacao dbContext) : base(dbContext) => _dbContext = dbContext;
        public async Task<bool> Delete(int id)
        {
            _dbContext.Remove(_dbContext.Cotacao.Where(e => e.NumeroCotacao == id).Include(e => e.CotacaoItems).FirstOrDefault());

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IList<CotacaoEntity>> Select(int id) => await _dbContext.Cotacao
                .Include(e => e.CotacaoItems)
                .Where(e => e.NumeroCotacao == id)
                .ToListAsync();

        public async Task<IList<CotacaoEntity>> SelectAll() => await _dbContext.Cotacao.Include(e => e.CotacaoItems).ToListAsync();

        public async Task<CotacaoEntity> SelectCotacao(int id)
        {
            return await _dbContext.Cotacao.FirstOrDefaultAsync(e => e.NumeroCotacao == id);
        }

        public async Task<int> Insert(List<CotacaoEntity> cotacaoItemEntity)
        {
            _dbContext.AddRange(cotacaoItemEntity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

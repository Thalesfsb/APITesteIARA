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
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly DbContextCotacao _dbContext;
        public CotacaoRepository(DbContextCotacao dbContext) => _dbContext = dbContext;

        public async Task<bool> Delete(int id)
        {
            var cotacao = _dbContext.Cotacao.Where(e => e.NumeroCotacao == id).Include(e => e.CotacaoItems).FirstOrDefault();
            _dbContext.Remove(cotacao);

            return await _dbContext.SaveChangesAsync() > 0;

        }

        public async Task<int> Insert(CotacaoEntity cotacaoEntity)
        {
            _dbContext.Cotacao.Add(cotacaoEntity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<CotacaoEntity> Select(int id) => await _dbContext.FindAsync<CotacaoEntity>(id);

        public async Task<IList<CotacaoEntity>> SelectAll() => await _dbContext.Cotacao.Include(e => e.CotacaoItems).ToListAsync();

        public async Task<CotacaoEntity> Update(CotacaoEntity cotacaoEntity)
        {
            var cotacaoUpd = _dbContext.Update(cotacaoEntity);
            await _dbContext.SaveChangesAsync();

            return cotacaoUpd.Entity;
        }
    }
}

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
    public class CotacaoItemRepository : ICotacaoItemRepository
    {
        private readonly DbContextCotacao _dbContext;
        public CotacaoItemRepository(DbContextCotacao dbContext) => _dbContext = dbContext;
        public async Task<bool> Delete(int id)
        {
            var cotacaoItem = _dbContext.Cotacao.FirstOrDefault(e => e.NumeroCotacao == id);
            _dbContext.Remove(cotacaoItem);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<int> Insert(CotacaoItemEntity cotacaoItemEntity)
        {
            _dbContext.CotacaoItem.Add(cotacaoItemEntity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<CotacaoItemEntity> Select(int id) => await _dbContext.FindAsync<CotacaoItemEntity>(id);

        public async Task<IList<CotacaoItemEntity>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CotacaoItemEntity> Update(CotacaoItemEntity cotacaoItemEntity)
        {
            var cotacaoUpd = _dbContext.Update(cotacaoItemEntity);
            await _dbContext.SaveChangesAsync();

            return cotacaoUpd.Entity;
        }
    }
}

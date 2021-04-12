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
    public class CotacaoItemRepository : Repository<CotacaoItemEntity>, ICotacaoItemRepository
    {
        private readonly DbContextCotacao _dbContext;
        public CotacaoItemRepository(DbContextCotacao dbContext) : base(dbContext) => _dbContext = dbContext;
        public async Task<bool> Delete(int id)
        {
            _dbContext.Remove(_dbContext.CotacaoItem.FirstOrDefault(e => e.NumeroCotacaoItem == id));

            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<IList<CotacaoItemEntity>> SelectAll()
        {
            return null;
        }

        public async Task<CotacaoItemEntity> Select(int id) => _dbContext.Set<CotacaoItemEntity>().FirstOrDefault(e => e.NumeroCotacaoItem == id);

        public async Task<int> Insert(CotacaoItemEntity cotacaoItemEntity)
        {
            _dbContext.Add(cotacaoItemEntity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

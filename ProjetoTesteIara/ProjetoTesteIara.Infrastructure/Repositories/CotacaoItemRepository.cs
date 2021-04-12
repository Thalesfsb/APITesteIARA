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
            var cotacaoItem = _dbContext.Cotacao.FirstOrDefault(e => e.NumeroCotacao == id);
            _dbContext.Remove(cotacaoItem);

            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<IList<CotacaoItemEntity>> SelectAll()
        {
            return null;
        }
    }
}

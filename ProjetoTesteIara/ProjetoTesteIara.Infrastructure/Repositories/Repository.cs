using ProjetoTesteIara.Domain.Interfaces.Repositories;
using ProjetoTesteIara.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContextCotacao _dbContext;
        public Repository(DbContextCotacao dbContext) => _dbContext = dbContext;

        public async Task<int> Insert(TEntity entity)
        {
            _dbContext.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Select(int id) => await _dbContext.FindAsync<TEntity>(id);

        public async Task<TEntity> Update(TEntity entity)
        {
            var cotacaoUpd = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return cotacaoUpd.Entity;
        }
    }
}

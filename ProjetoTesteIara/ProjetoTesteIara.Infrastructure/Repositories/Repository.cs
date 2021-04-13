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

        public async Task<int> Insert(IList<TEntity> entity)
        {
            _dbContext.AddRange(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

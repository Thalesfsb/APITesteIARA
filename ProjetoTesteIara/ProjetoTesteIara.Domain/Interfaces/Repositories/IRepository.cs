using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Select(int id);
        Task<int> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
    }
}

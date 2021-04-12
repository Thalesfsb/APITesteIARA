using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Update(TEntity entity);
    }
}

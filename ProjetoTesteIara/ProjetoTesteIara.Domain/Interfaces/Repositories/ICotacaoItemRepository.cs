using ProjetoTesteIara.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Repositories
{
    public interface ICotacaoItemRepository : IRepository<CotacaoItemEntity>
    {
        Task<IList<CotacaoItemEntity>> SelectAll();
        Task<bool> Delete(int id);
    }
}

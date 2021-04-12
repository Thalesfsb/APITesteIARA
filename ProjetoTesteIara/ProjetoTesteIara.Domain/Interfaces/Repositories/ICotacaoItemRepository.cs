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
        Task<CotacaoItemEntity> Select(int id);
        Task<IList<CotacaoItemEntity>> SelectAll();
        Task<int> Insert(CotacaoItemEntity cotacaoItemEntity);
        Task<bool> Delete(int id);
    }
}

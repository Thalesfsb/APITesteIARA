using ProjetoTesteIara.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Repositories
{
    public interface ICotacaoItemRepository
    {
        Task<IList<CotacaoItemEntity>> SelectAll();
        Task<CotacaoItemEntity> Select(int id);
        Task<int> Insert(CotacaoItemEntity cotacaoItemEntity);
        Task<CotacaoItemEntity> Update(CotacaoItemEntity cotacaoItemEntity);
        Task<bool> Delete(int id);
    }
}

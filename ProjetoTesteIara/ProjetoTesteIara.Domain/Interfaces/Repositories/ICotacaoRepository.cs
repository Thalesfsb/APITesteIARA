using ProjetoTesteIara.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Repositories
{
    public interface ICotacaoRepository
    {
        Task<IList<CotacaoEntity>> SelectAll();
        Task<CotacaoEntity> Select(int id);
        Task<int> Insert(CotacaoEntity cotacaoEntity);
        Task<CotacaoEntity> Update(CotacaoEntity cotacaoEntity);
        Task<bool> Delete(int id);
    }
}

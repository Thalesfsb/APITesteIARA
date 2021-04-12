using ProjetoTesteIara.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Repositories
{
    public interface ICotacaoRepository : IRepository<CotacaoEntity>
    {
        Task<IList<CotacaoEntity>> SelectAll();
        Task<bool> Delete(int id);
    }
}

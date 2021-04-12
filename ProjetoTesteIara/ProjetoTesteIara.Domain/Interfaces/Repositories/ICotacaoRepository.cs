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
        Task<IList<CotacaoEntity>> Select(int id);
        Task <CotacaoEntity> SelectCotacao(int id);
        Task<int> Insert(IList<CotacaoEntity> entity);
        Task<bool> Delete(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Repositories;
using ProjetoTesteIara.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Infrastructure.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly DbContextCotacao _dbContext;
        public CotacaoRepository(DbContextCotacao dbContext) => _dbContext = dbContext;
        public async Task<int> Insert(CotacaoEntity cotacaoEntity)
        {
            _dbContext.Cotacao.Add(cotacaoEntity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

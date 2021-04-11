using ProjetoTesteIara.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Entities
{
    public class CotacaoItemEntity : ICotacaoItemEntity
    {
        public string Descricao { get; set; }
        public int NumeroItem { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public int NumeroCotacao { get; set; }
        public virtual CotacaoEntity CotacaoEntity { get; set; }
    }
}

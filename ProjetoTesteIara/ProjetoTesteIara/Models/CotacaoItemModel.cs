using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Models
{
    public class CotacaoItemModel
    {
        public string Descricao { get; set; }
        public int NumeroItem { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public int NumeroCotacao { get; set; }
        public CotacaoModel Cotacao { get; set; }
    }
}

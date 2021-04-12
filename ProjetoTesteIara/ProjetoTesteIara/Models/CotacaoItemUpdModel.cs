using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Models
{
    public class CotacaoItemUpdModel
    {
        public int NumeroCotacaoItem { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int NumeroItem { get; set; }
        public decimal Preco { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public int NumeroCotacao { get; set; }
    }
}

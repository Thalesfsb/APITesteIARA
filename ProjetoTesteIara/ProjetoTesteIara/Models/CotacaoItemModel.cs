using System.ComponentModel.DataAnnotations;

namespace ProjetoTesteIara.Models
{
    public class CotacaoItemModel
    {
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
        public CotacaoModel Cotacao { get; set; }
    }
}

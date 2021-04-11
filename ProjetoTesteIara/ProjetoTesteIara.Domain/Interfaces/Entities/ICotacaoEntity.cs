using ProjetoTesteIara.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Entities
{
    public interface ICotacaoEntity
    {
        string CNPJComprador { get; set; }
        string CNPJFornecedor { get; set; }
        int NumeroCotacao { get; set; }
        DateTime DataCotacao { get; set; }
        DateTime DataEntregaCotacao { get; set; }
        string CEP { get; set; }
        string Logradouro { get; set; }
        string Complemento { get; set; }
        string Bairro { get; set; }
        string UF { get; set; }
        string Observacao { get; set; }
        ICollection<CotacaoItemEntity> CotacaoItems { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Domain.Interfaces.Entities
{
    public interface ICotacaoItemEntity
    {
        int NumeroCotacao { get; set; }
        string Descricao { get; set; }
        int NumeroItem { get; set; }
        decimal Preco { get; set; }
        int Quantidade { get; set; }
        string Marca { get; set; }
        string Unidade { get; set; }

    }
}

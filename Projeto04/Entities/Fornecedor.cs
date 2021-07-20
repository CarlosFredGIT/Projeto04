using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Entities
{
    /// <summary>
    /// Classe de modelo de entidade para Fornecedor
    /// </summary>
    public class Fornecedor
    {
        public Guid IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        #region Associação
        public List<Produto> Produtos { get; set; }
        #endregion
    }
}

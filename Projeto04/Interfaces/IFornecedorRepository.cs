using Projeto04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Interfaces
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Fornecedor ConsultarPorCnpj(string cnpj);
    }
}

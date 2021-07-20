using Dapper;
using Projeto04.Entities;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    /// <summary>
    /// Classe para repositorio de banco de dados de Fornecedor
    /// </summary>

    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly string _connectionstring;

        public FornecedorRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Inserir(Fornecedor obj)
        {
            var query = @"
                          INSERT INTO FORNECEDOR(IDFORNECEDOR, NOME, CNPJ)
                          VALUES(@IdFornecedor, @Nome, @Cnpj)
                         ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Fornecedor obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Fornecedor obj)
        {
            throw new NotImplementedException();
        }

        public List<Fornecedor> Consultar()
        {
            throw new NotImplementedException();
        }

        public Fornecedor ConsultarPorCnpj(string cnpj)
        {
            throw new NotImplementedException();
        }
    }
}

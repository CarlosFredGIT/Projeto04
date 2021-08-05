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
            var query = @"
                            UPDATE FORNECEDOR
                            SET
                                NOME = @Nome
                                CNPJ = @Cnpj
                            WHERE
                                IDFORNECEDOR = @IdFornecedor
                         ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Fornecedor obj)
        {
            var query = @"
                            DELETE FROM FORNECEDOR
                            WHERE IDFORNECEDOR = @IdFornecedor
                        ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Fornecedor> Consultar()
        {
            var query = @"
                            SELECT * FROM FORNECEDOR  
                            ORDER BY NOME
                         ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection
                    .Query<Fornecedor>(query) //Usado para consulta
                    .ToList();//retorna lista(varios valores)
            }
        }

        public Fornecedor ConsultarPorCnpj(string cnpj)
        {
            var query = @"
                            SELECT * FROM FORNECEDOR
                            WHERE CNPJ = @cnpj
                         ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection.Query<Fornecedor>(query, new { cnpj }).FirstOrDefault();
            }
        }

        public Fornecedor ObterPorId(Guid id)
        {
            var query = @"
                            SELECT * FROM FORNECEDOR
                            WHERE IDFORNECEDOR = @id
                         ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection.Query<Fornecedor>(query, new { id }).FirstOrDefault();
            }
        }
    }
}

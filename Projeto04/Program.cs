using Projeto04.Entities;
using Projeto04.Repositories;
using System;

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n - CONTROLE DE PRODUTOS E FORNECEDORES - \n");

            try
            {
                var connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProjeto04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                Console.WriteLine("\nCADASTRO DE FORNECEDOR\n");

                var fornecedor = new Fornecedor();
                fornecedor.IdFornecedor = Guid.NewGuid();

                Console.Write("Nome do fornecedor..........: ");
                fornecedor.Nome = Console.ReadLine();

                Console.Write("CNPJ do fornecedor..........: ");
                fornecedor.Cnpj = Console.ReadLine();

                var fornecedorRepository = new FornecedorRepository(connectionstring);
                fornecedorRepository.Inserir(fornecedor);

                Console.WriteLine("\n Fornecedor cadastrado com sucesso! =D ");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Ocorreu um erro =/ : " + e.Message);
            }

            Console.ReadKey();
        }
    }
}

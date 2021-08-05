using Projeto04.Entities;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class ProdutoController
    {
        //atributo
        private readonly IProdutoRepository _produtoRepository;

        //construtor para inicializar o atributo da interface
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void CadastrarProduto()
        {
            Console.WriteLine("\nCADASTRO DE PRODUTO\n");

            var produto = new Produto();
            produto.IdProduto = Guid.NewGuid();

            Console.Write("Nome do produto..........: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Preço do produto..........: ");
            produto.Preco = decimal.Parse(Console.ReadLine());

            Console.Write("Quantidade do produto..........: ");
            produto.Quantidade = int.Parse(Console.ReadLine());

            Console.Write("Data da compra do produto..........: ");
            produto.DataCompra = DateTime.Parse(Console.ReadLine());

            Console.Write("Id do fornecedor do produto..........: ");
            produto.IdFornecedor = Guid.Parse(Console.ReadLine());

            if (_produtoRepository.ObterPorId(produto.IdProduto) == null)
            {
                _produtoRepository.Inserir(produto);
                Console.Write("Produto cadastrado com sucesso! =D");
            }
            else
            {
                Console.Write("Produto já está cadastrado!");
            }
}

        public void AtualizarProduto()
        {
            Console.WriteLine("\nEDIÇÃO DE PRODUTO\n");

            Console.Write("Entre com o ID do produto..........: ");
            var idProduto = Guid.Parse(Console.ReadLine());

            var produto = _produtoRepository.ObterPorId(idProduto);

            if (produto != null)
            {
                Console.Write("Nome do produto..........: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Preço do produto..........: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Quantidade do produto..........: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                Console.Write("Data da compra do produto..........: ");
                produto.DataCompra = DateTime.Parse(Console.ReadLine());

                _produtoRepository.Alterar(produto);
                
                Console.Write("Produto atualizado com sucesso! =D");
            }
            else
            {
                Console.Write("Produto não encontrado!");
            }

        }

        public void ExcluirProduto()
        {
            Console.WriteLine("\nEXCLUSÃO DE PRODUTO\n");

            Console.Write("Entre com o ID do produto..........: ");
            var idProduto = Guid.Parse(Console.ReadLine());

            var produto = _produtoRepository.ObterPorId(idProduto);

            if (produto != null)
            {
                _produtoRepository.Excluir(produto);

                Console.Write("Produto excluído com sucesso! =D");
            }
            else
            {
                Console.Write("Produto não encontrado!");
            }
        }

        public void ConsultarProdutos()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTO\n");

            var produto = _produtoRepository.Consultar();
                 
            foreach (var item in produto)
            {
                Console.WriteLine("Id do produto.......: " + item.IdProduto);
                Console.WriteLine("Nome................: " + item.Nome);
                Console.WriteLine("Preço...............: " + item.Preco);
                Console.WriteLine("Quantidade..........: " + item.Quantidade);
                Console.WriteLine("Data da compra......: " + item.DataCompra);
                Console.WriteLine("Id do fornecedor....: " + item.IdFornecedor);
                Console.WriteLine("---");
            }      
        }

        public void ConsultarProdutosPorPreco()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTO POR PREÇO\n");

            Console.Write("Entre com o menor preço do produto..........: ");
            var precoMin = decimal.Parse(Console.ReadLine());

            Console.Write("Entre com o maior preço do produto..........: ");
            var precoMax = decimal.Parse(Console.ReadLine());

            var produto = _produtoRepository.ConsultarPorPreco(precoMin, precoMax);

            foreach (var item in produto)
            {
                Console.WriteLine("Id do produto.......: " + item.IdProduto);
                Console.WriteLine("Nome................: " + item.Nome);
                Console.WriteLine("Preço...............: " + item.Preco);
                Console.WriteLine("Quantidade..........: " + item.Quantidade);
                Console.WriteLine("Data da compra......: " + item.DataCompra);
                Console.WriteLine("Id do fornecedor....: " + item.IdFornecedor);
                Console.WriteLine("---");
            }
        }

        public void ConsultarProdutosPorData()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTO POR DATA\n");

            Console.Write("Entre com o menor data do produto..........: ");
            var dataMin = DateTime.Parse(Console.ReadLine());

            Console.Write("Entre com o maior data do produto..........: ");
            var dataMax = DateTime.Parse(Console.ReadLine());

            var produto = _produtoRepository.ConsultarPorData(dataMin, dataMax);

            foreach (var item in produto)
            {
                Console.WriteLine("Id do produto.......: " + item.IdProduto);
                Console.WriteLine("Nome................: " + item.Nome);
                Console.WriteLine("Preço...............: " + item.Preco);
                Console.WriteLine("Quantidade..........: " + item.Quantidade);
                Console.WriteLine("Data da compra......: " + item.DataCompra);
                Console.WriteLine("Id do fornecedor....: " + item.IdFornecedor);
                Console.WriteLine("---");
            }
        }
    }
}

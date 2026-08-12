using CrudProdutos.Entities;
using CrudProdutos.Repositories;
using System.Numerics;

namespace CrudProdutos.Controllers
{
    public class ProdutoController
    {

        public void Inserir()
        {
            try
            {           
                Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

                var produto = new Produto();

                Console.Write("Nome do Produto......: ");
                produto.Nome = Console.ReadLine();

                Console.Write("PREÇO.................: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("QUANTIDADE............: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                var repo = new ProdutoRepository();
                repo.Inserir(produto);

                Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
            }
            catch (Exception e)
            {
                Console.WriteLine("NÃO FOI POSSÍVEL CADASTRAR O PRODUTO!");
                throw new Exception(e.Message);
            }
        }

    }
}

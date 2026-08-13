using CrudProdutos.Entities;
using CrudProdutos.Repositories;
using System.Numerics;

namespace CrudProdutos.Controllers
{
    public class ProdutoController
    {

        public void GerenciarProdutos()
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE PRODUTOS:\n");
            Console.WriteLine("\t(1) CADASTRAR PRODUTOS");
            Console.WriteLine("\t(2) ATUALIZAR PRODUTO");
            Console.WriteLine("\t(3) EXCLUIR PRODUTO");
            Console.WriteLine("\t(4) CONSULTAR PRODUTOS");
            Console.WriteLine("\t(5) CONSULTAR POR ID");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = 0;
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                GerenciarProdutos();
            }

            switch (opcao)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Atualizar();
                    break;
                case 3:
                    Excluir();
                    break;
                case 4:
                    Consultar();
                    break;
                case 5:
                    ConsultarPorId();
                    break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    break;
            }

            Console.Write("\nDESEJA EXECUTAR OUTRA OPERAÇÃO? (S, N) ");
            var confirmacao = Console.ReadLine();

            if (confirmacao.ToUpper().Equals("S"))
            {
                Console.Clear();
                GerenciarProdutos();
            }
            else {
                Console.Beep();
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }

        private void Cadastrar()
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

        private void Atualizar()
        {
            try
            {
                Console.WriteLine("\nATUALIZAR PRODUTO:\n");

                Console.Write("Id do Produto......: ");
                var id = Guid.Parse(Console.ReadLine());

                var repo = new ProdutoRepository();
                var produto = repo.ObterPorId(id);

                if (produto != null)
                {
                    Console.Write("Nome do Produto......: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("PREÇO.................: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("QUANTIDADE............: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    repo.Alterar(produto);

                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nNENHUM PRODUTO ENCONTRADO!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("NÃO FOI POSSÍVEL ATUALIZAR O PRODUTO!");
                throw new Exception(e.Message);
            }
        }

        private void Excluir()
        {
            try
            {
                Console.WriteLine("\nEXCLUIR PRODUTO:\n");

                Console.Write("Id do Produto......: ");
                var id = Guid.Parse(Console.ReadLine());

                var repo = new ProdutoRepository();
                var produto = repo.ObterPorId(id);

                if (produto != null)
                {
                    Console.WriteLine($"\tNOME............: {produto.Nome}");
                    Console.WriteLine($"\tPREÇO...........: {produto.Preco}");
                    Console.WriteLine($"\tQUANTIDADE......: {produto.Quantidade}");

                    Console.Write("\nDESEJA EXCLUIR ESTE PRODUTO ? (S,N)");
                    var escolha = Console.ReadLine();

                    if (escolha.ToUpper().Equals("S"))
                    {
                        repo.Excluir(id);
                        Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO!");
                    }
                    else
                    {
                        Console.WriteLine("\nEXCLUSÃO CANCELADA!");
                    }
                } 
                else
                {
                    Console.WriteLine("\nNENHUM PRODUTO ENCONTRADO!");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("NÃO FOI POSSÍVEL EXCLUIR O PRODUTO!");
                throw new Exception(e.Message);
            }
        }

        private void Consultar()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE PRODUTOS:\n");

                var repo = new ProdutoRepository();
                var produtos = repo.Consultar();

                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID.....................: {produto.Id}");
                    Console.WriteLine($"NOME...................: {produto.Nome}");
                    Console.WriteLine($"PREÇO..................: {produto.Preco}");
                    Console.WriteLine($"QUANTIDADE.............: {produto.Quantidade}");
                    Console.WriteLine($"DATA HORA CADASTRO.....: {produto.DataHoraCadastro}");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("NÃO FOI POSSÍVEL OBTER PRODUTO PELO ID!");
                throw new Exception(e.Message);
            }
        }

        private void ConsultarPorId()
        {
            try
            {
                Console.WriteLine("\nCONSULTAR PRODUTO POR ID:\n");

                Console.Write("Id do Produto......: ");
                var id = Guid.Parse(Console.ReadLine());

                var repo = new ProdutoRepository();
                var produto = repo.ObterPorId(id);

                if (produto != null)
                {
                    Console.WriteLine($"ID.....................: {produto.Id}");
                    Console.WriteLine($"NOME...................: {produto.Nome}");
                    Console.WriteLine($"PREÇO..................: {produto.Preco}");
                    Console.WriteLine($"QUANTIDADE.............: {produto.Quantidade}");
                    Console.WriteLine($"DATA HORA CADASTRO.....: {produto.DataHoraCadastro}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nPRODUTO NÃO ENCONTRADO!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("NÃO FOI POSSÍVEL OBTER PRODUTO PELO ID!");
                throw new Exception(e.Message);
            }
        }
    }
}

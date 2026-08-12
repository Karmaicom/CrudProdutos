using CrudProdutos.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace CrudProdutos.Repositories
{
    /// <summary>
    /// Repositorio para crud de produtos
    /// </summary>
    public class ProdutoRepository
    {
        private static string connectionString = @"
                Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30
            ";
        
        public void Inserir(Produto produto)
        {
            try
            {
                var query = @"
                        insert into produtos(id, nome, preco, quantidade, datahoracadastro)
                        values (@Id, @Nome, @Preco, @Quantidade, @DataHoraCadastro)
                    ";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, produto);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Alterar(Produto produto)
        {
            try
            {
                var query = @"update produtos set nome = @Nome, preco = @Preco, quantidade = @Quantidade 
                                where id = @Id";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, produto);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                var query = @"delete from produtos where id = @Id";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, new { @Id = id });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Produto> Consultar()
        {
            try
            {

                var query = @"select * from produto order by nome";

                using (var connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Produto>(query).ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

using CrudProdutos.Controllers;

namespace CrudProdutos
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new ProdutoController();
            controller.Inserir();
        }
    }
}

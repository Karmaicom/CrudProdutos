namespace CrudProdutos.Entities
{
    /// <summary>
    /// Modelo de entidade para produto
    /// </summary>
    public class Produto
    {
        #region Propriedades
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;

        #endregion


    }
}

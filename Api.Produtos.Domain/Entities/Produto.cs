namespace Api.Produtos.Domain.Entities
{
    public class Produto
    {
        #region Propriedades

        public Guid IdProduto { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }


        #endregion
    }
}

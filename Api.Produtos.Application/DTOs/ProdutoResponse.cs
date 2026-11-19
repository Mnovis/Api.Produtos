namespace Api.Produtos.Application.DTOs
{
    public record ProdutoResponse(
        Guid idProduto,
        string nome,
        decimal preco,
        int quantidade
    );
}

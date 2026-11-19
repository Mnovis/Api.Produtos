namespace Api.Produtos.Application.DTOs
{
    public record ProdutoRequest(
        string nome,
        decimal preco,
        int quantidade
    );
}

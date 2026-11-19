using Api.Produtos.Application.DTOs;
using Api.Produtos.Domain.Entities;
using Api.Produtos.Domain.Validators;
using Api.Produtos.Infrastructure.Repositories;
using FluentValidation;

namespace Api.Produtos.Application.Services
{
    public class ProdutoService
    {
        // Método para criar produto
        public async Task<ProdutoResponse> CriarProduto(ProdutoRequest request)
        {
            #region Captura os dados enviados na requisição

            var produto = new Produto
            {
                Nome = request.nome,
                Preco = request.preco,
                Quantidade = request.quantidade
            };

            #endregion

            #region Verificar se os dados passam nas validações

            var produtoValidator = new ProdutoValidator();
            var result = produtoValidator.Validate(produto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            #endregion

            #region Salvar Produto no banco de dados

            var produtoRepository = new ProdutoRepository();
            await produtoRepository.InserirAsync(produto);

            #endregion

            #region Retornar resposta

            return new ProdutoResponse(
                produto.IdProduto,
                produto.Nome,
                produto.Preco,
                produto.Quantidade
            );

            #endregion
        }

        // Método para atualizar produto
        public async Task<ProdutoResponse> AtualizarProduto(Guid id, ProdutoRequest request)
        {
            #region Obter o produto no banco de dados 

            var produtoRepository = new ProdutoRepository();

            var produto = await produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new ApplicationException("Produto não encontrado!");
            }

            #endregion

            #region Atualizar produto

            produto.Nome = request.nome;
            produto.Preco = request.preco;
            produto.Quantidade = request.quantidade;

            #endregion

            #region Verificar se os dados passam nas validações

            var produtoValidator = new ProdutoValidator();
            var result = produtoValidator.Validate(produto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            #endregion

            #region Salvar alterações do produto no banco

            await produtoRepository.AtualizarAsync(produto);

            #endregion

            #region Retornar resposta

            return new ProdutoResponse(
                produto.IdProduto,
                produto.Nome,
                produto.Preco,
                produto.Quantidade
            );

            #endregion
        }

        // Método para excluir produto
        public async Task<ProdutoResponse> ExcluirProduto(Guid id)
        {
            #region Obter o produto no banco de dados 

            var produtoRepository = new ProdutoRepository();

            var produto = await produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new ApplicationException("Produto não encontrado!");
            }

            #endregion

            #region Excluir Produto

            await produtoRepository.ExcluirAsync(produto);

            #endregion

            #region Retornar resposta

            return new ProdutoResponse(
                produto.IdProduto,
                produto.Nome,
                produto.Preco,
                produto.Quantidade
            );

            #endregion
        }

        public async Task<ProdutoResponse> ObterProdutoPorId(Guid id)
        {
            #region Obter o produto no banco de dados 

            var produtoRepository = new ProdutoRepository();

            var produto = await produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new ApplicationException("Produto não encontrado!");
            }

            #endregion

            #region Retornar resposta

            return new ProdutoResponse(
                produto.IdProduto,
                produto.Nome,
                produto.Preco,
                produto.Quantidade
            );

            #endregion
        }

        public async Task<List<ProdutoResponse>> ObterTodosProdutos()
        {
            #region Obter Produtos

            var produtoRepository = new ProdutoRepository();
            var produtos = await produtoRepository.ObterTodosAsync();

            #endregion

            #region Retornar Lista

            return produtos
                .Select(p => new ProdutoResponse(
                    p.IdProduto,
                    p.Nome,
                    p.Preco,
                    p.Quantidade

                ))
                .ToList();

            #endregion


        }
    }
}

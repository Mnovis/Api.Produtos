using Api.Produtos.Application.DTOs;
using Api.Produtos.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Produtos.Controllers
{
    [Route("api/v1/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IActionResult> PostAsync(ProdutoRequest request)
        {
            try
            {
                var produtoService = new ProdutoService();
                var response = await produtoService.CriarProduto(request);

                return StatusCode(201, response); // HTTP CREATED (201)
            }
            catch (ValidationException e)
            {
                return StatusCode(400, e.Errors.Select(e => e.ErrorMessage)); // HTTP BAD REQUEST (400)
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message }); // HTTP INTERNAL SERVER ERROR (500)
            }
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> PutAsync(Guid id, ProdutoRequest request)
        {
            try
            {
                var produtoService = new ProdutoService();
                var response = await produtoService.AtualizarProduto(id, request);

                return Ok(response); // HTTP OK (200)
            }
            catch (ValidationException e)
            {
                return StatusCode(400, e.Errors.Select(e => e.ErrorMessage)); // HTTP BAD REQUEST (400)
            }
            catch (ApplicationException e)
            {
                return StatusCode(404, new { e.Message }); // HTTP Not Found (404)
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message }); // HTTP INTERNAL SERVER ERROR (500)
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var produtoService = new ProdutoService();
                var response = await produtoService.ExcluirProduto(id);

                return Ok(response); // HTTP OK (200)
            }
            catch (ApplicationException e)
            {
                return StatusCode(404, new { e.Message }); // HTTP Not Found (404)
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message }); // HTTP INTERNAL SERVER ERROR (500)
            }
        }

        [HttpGet("obterTodos")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var produtoService = new ProdutoService();
                var response = await produtoService.ObterTodosProdutos();

                return Ok(response); // HTTP OK (200)
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message }); // HTTP INTERNAL SERVER ERROR (500)
            }
        }

        [HttpGet("obterPorId/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var produtoService = new ProdutoService();
                var response = await produtoService.ObterProdutoPorId(id);

                return Ok(response); // HTTP OK (200)
            }
            catch (ApplicationException e)
            {
                return StatusCode(404, new { e.Message }); // HTTP Not Found (404)
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message }); // HTTP INTERNAL SERVER ERROR (500)
            }
        }

    }
}

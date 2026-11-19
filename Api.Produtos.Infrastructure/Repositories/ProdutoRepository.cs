using Api.Produtos.Domain.Entities;
using Api.Produtos.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Produtos.Infrastructure.Repositories
{
    public class ProdutoRepository
    {
        public async Task InserirAsync(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                await dataContext.AddAsync(produto);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarAsync(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task ExcluirAsync(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(produto);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            using (var dataContext = new DataContext())
            {
                return await dataContext.Set<Produto>()
                    .OrderBy(p => p.Nome)
                    .ToListAsync();
            }
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return await dataContext.Set<Produto>()
                    .FirstOrDefaultAsync(p => p.IdProduto.Equals(id));
            }
        }
    }
}

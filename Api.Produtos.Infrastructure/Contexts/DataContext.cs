using Api.Produtos.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Produtos.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost,1436;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Coti@2026;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}

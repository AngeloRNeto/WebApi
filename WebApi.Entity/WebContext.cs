using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;

namespace WebApi.Entity
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }

     }
}

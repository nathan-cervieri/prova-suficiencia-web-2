using FurbAPIRest.Models;
using Microsoft.EntityFrameworkCore;

namespace FurbAPIRest.Helpers
{
#nullable disable
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("sqlConnectionString"));
        }

        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}


using Fiap.Web.Donation2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation2.Data
{
    public class DataContext : DbContext
    {

        public DbSet<TipoProdutoModel> TipoProdutos { get; set; }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}

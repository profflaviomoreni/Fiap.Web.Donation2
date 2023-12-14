using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation2.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext context)
        {
            _dataContext = context;
        }


        public IList<ProdutoModel> FindAll()
        {
            // SELECT * FROM Produtos
            var produtos = _dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos ;
        }


        public IList<ProdutoModel> FindAllDisponivelTroca(int idUsuario)
        {
            var produtos = _dataContext
                                .Produtos
                                    .Include(p => p.TipoProduto)
                                    .Include(p => p.Usuario)
                                    .Where(
                                        p => p.UsuarioId != idUsuario && 
                                        p.Disponivel == true          &&
                                        p.DataExpiracao >= DateTime.Now
                                     )
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindAllDisponivelUsuarioTroca(int idUsuario)
        {
            var produtos = _dataContext
                                .Produtos
                                    .Include(p => p.TipoProduto)
                                    .Include(p => p.Usuario)
                                    .Where(
                                        p => p.UsuarioId == idUsuario &&
                                        p.Disponivel == true &&
                                        p.DataExpiracao >= DateTime.Now
                                     )
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }



        public IList<ProdutoModel> FindAllWithTipo()
        {
            // SELECT * FROM Produtos
            var produtos = _dataContext
                                .Produtos
                                    .Include( p => p.TipoProduto )
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllWithTipoAndUsuario()
        {
            var produtos = _dataContext
                                .Produtos
                                    .Include(p => p.TipoProduto)
                                    .Include(p => p.Usuario )
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public ProdutoModel FindById(int id)
        {
            // SELECT * FROM Produtos WHERE ProdutoId = {id}
            var produtoModel = _dataContext.Produtos.FirstOrDefault( p => p.ProdutoId == id );
            return produtoModel;
        }

        public IList<ProdutoModel> FindByNome(string nome)
        {
            var produtos = _dataContext
                                .Produtos
                                    .Include(p => p.TipoProduto)
                                    .Include(p => p.Usuario)
                                    .Where( p => p.Nome.ToLower().Contains(nome.ToLower()))
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindByNomeAndDataExpiracao( string nome, DateTime dataExpiracao )
        {
            var produtos = _dataContext.Produtos
                                .Include(p => p.TipoProduto)
                                .Include(p => p.Usuario)
                                .Where(p => 
                                    p.Nome.ToLower().Contains(nome.ToLower()) && 
                                    p.DataExpiracao >= dataExpiracao  
                                 )
                                .OrderByDescending(p => p.Nome)
                                .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public int Insert ( ProdutoModel produtoModel )
        {
            _dataContext.Produtos.Add( produtoModel );
            _dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        public void Update( ProdutoModel produtoModel )
        {
            _dataContext.Produtos.Update(produtoModel);
            _dataContext.SaveChanges();
        }

        public void Delete( ProdutoModel produtoModel )
        {
            _dataContext.Produtos.Remove(produtoModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id
            };

            Delete(produtoModel);
        }



    }
}

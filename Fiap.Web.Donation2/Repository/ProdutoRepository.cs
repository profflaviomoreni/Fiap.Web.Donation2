using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;

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

        public ProdutoModel FindById(int id)
        {
            // SELECT * FROM Produtos WHERE ProdutoId = {id}
            var produtoModel = _dataContext.Produtos.FirstOrDefault( p => p.ProdutoId == id );
            return produtoModel;
        }

        public IList<ProdutoModel> FindByNome(string nome)
        {
            return null;
        }

        public IList<ProdutoModel> FindByNomeAndDataExpiracao( string nome, DateTime dataExpiracao )
        {
            return null;
        }


        public IList<ProdutoModel> FindByDisponivelAndDataExpiracao(bool disponivel, DateTime dataExp)
        {
            return null;
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

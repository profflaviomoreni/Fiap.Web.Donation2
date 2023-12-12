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
            return null;
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

        }

        public void Delete( ProdutoModel produtoModel )
        {

        }

        public void Delete(int id)
        {

        }



    }
}

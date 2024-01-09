using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;

namespace Fiap.Web.Donation2.Repository
{
    public class TrocaRepository
    {

        private readonly DataContext _dataContext;

        public TrocaRepository(DataContext context)
        {
            this._dataContext = context;
        }


        public Guid Insert(TrocaModel trocaModel)
        {
            _dataContext.Trocas.Add(trocaModel);
            _dataContext.SaveChanges();

            return trocaModel.TrocaId;
        }


    }
}

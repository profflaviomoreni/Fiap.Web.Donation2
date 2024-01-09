using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;

namespace Fiap.Web.Donation2.Repository
{
    public class UsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext context)
        {
            _dataContext =  context;
        }


        public UsuarioModel Login(string username, string password)
        {
            var usuarioModel = _dataContext
                                   .Usuarios
                                   .Where( u => u.Senha == password && u.Email == username)
                                   .FirstOrDefault();

            return usuarioModel;
        }



    }
}

using Fiap.Web.Donation2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation2.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            var lista = ObterUsuariosMock();
            return View(lista);
        }


        private List<UsuarioModel> ObterUsuariosMock()
        {
            // Lista de usuários mock
            var usuariosMock = new List<UsuarioModel>
            {
                new UsuarioModel { UsuarioId = 1, Nome = "Usuario1", Email = "usuario1@email.com", Senha = "senha1", Regra = "Admin" },
                new UsuarioModel { UsuarioId = 2, Nome = "Usuario2", Email = "usuario2@email.com", Senha = "senha2", Regra = "Usuário" },
                new UsuarioModel { UsuarioId = 3, Nome = "Usuario3", Email = "usuario3@email.com", Senha = "senha3", Regra = "Usuário" },
                new UsuarioModel { UsuarioId = 4, Nome = "Usuario4", Email = "usuario4@email.com", Senha = "senha4", Regra = "Moderador" },
                new UsuarioModel { UsuarioId = 5, Nome = "Usuario5", Email = "usuario5@email.com", Senha = "senha5", Regra = "Usuário" }
            };

            return usuariosMock;
        }

    }
}

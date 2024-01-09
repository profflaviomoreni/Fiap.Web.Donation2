using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation2.Controllers
{
    public class BaseController : Controller
    {

        public readonly int? UsuarioId = 0;

        public readonly string? UsuarioNome = string.Empty;

        public readonly bool Autenticado = false;


        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            
            if ( httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Session != null)
            {
                UsuarioId = httpContextAccessor.HttpContext.Session.GetInt32("UsuarioId");
                UsuarioNome = httpContextAccessor.HttpContext.Session.GetString("UsuarioNome");

                if ( UsuarioId != null && UsuarioId != 0 )
                {
                    Autenticado = true;
                }
            }

        }

    }
}

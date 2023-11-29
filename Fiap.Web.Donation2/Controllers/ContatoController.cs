using Fiap.Web.Donation2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation2.Controllers
{
    public class ContatoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Gravar(ContatoModel contatoModel)
        {
            // INSERT INTO --- contatoModel

            return View("Sucesso");
        }

        


    }
}

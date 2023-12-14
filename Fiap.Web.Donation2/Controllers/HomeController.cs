using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;
using Fiap.Web.Donation2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Donation2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly int UsuarioId = 1;

        private readonly ProdutoRepository _produtoRepository;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAllDisponivelTroca(UsuarioId);

            return View(produtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
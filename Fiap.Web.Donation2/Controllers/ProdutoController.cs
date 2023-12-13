using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;
using Fiap.Web.Donation2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation2.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository _produtoRepository;
        private readonly TipoProdutoRepository _tipoProdutoRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _tipoProdutoRepository = new TipoProdutoRepository(dataContext);    
        }


        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAll();

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            var listaTipos = _tipoProdutoRepository.FindAll();
            ViewBag.TipoProdutos = listaTipos;

            return View(new ProdutoModel());
        }


        [HttpPost]
        public IActionResult Novo(ProdutoModel produtoModel)
        {
            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                var listaTipos = _tipoProdutoRepository.FindAll();
                ViewBag.TipoProdutos = listaTipos;

                ViewBag.Mensagem = "O campo nome é requerido";
                return View(produtoModel);
            }
            else
            {
                produtoModel.UsuarioId = 1;
                _produtoRepository.Insert(produtoModel);
                
                TempData["Mensagem"] = $"Produto {produtoModel.Nome} cadastrado com sucesso";

                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Editar(int id) {
            var listaTipos = _tipoProdutoRepository.FindAll();
            ViewBag.TipoProdutos = listaTipos;

            ProdutoModel produto = _produtoRepository.FindById(id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if ( string.IsNullOrEmpty(produtoModel.Nome)  )
            {
                var listaTipos = _tipoProdutoRepository.FindAll();
                ViewBag.TipoProdutos = listaTipos;

                return View(produtoModel);
            } else
            {
                
                produtoModel.UsuarioId = 1;
                _produtoRepository.Update(produtoModel);

                TempData["Mensagem"] = $"Produto {produtoModel.Nome} editado com sucesso";

                return RedirectToAction("Index");
            }
            
        }


        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _produtoRepository.Delete(id);
            TempData["Mensagem"] = $"Produto removido com sucesso";
            return RedirectToAction("Index");
        }


    }
}

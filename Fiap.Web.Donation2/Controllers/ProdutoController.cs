using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;
using Fiap.Web.Donation2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //var produtos = _produtoRepository.FindAll();
            //var produtos = _produtoRepository.FindAllWithTipoAndUsuario();
            //var produtos = _produtoRepository.FindByNome("2");
            var produtos = _produtoRepository.FindByNomeAndDataExpiracao("i", DateTime.Now );

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            ComboTipoProduto();

            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Novo(ProdutoModel produtoModel)
        {
            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                ComboTipoProduto();

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
            ComboTipoProduto();

            ProdutoModel produto = _produtoRepository.FindById(id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if ( string.IsNullOrEmpty(produtoModel.Nome)  )
            {
                ComboTipoProduto();

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


        private void ComboTipoProduto()
        {
            var listaTipos = _tipoProdutoRepository.FindAll();
                                        
                                      // Itens  ,   Valor Numerico , Texto  
            var combo = new SelectList(listaTipos, "TipoProdutoId", "Nome");

            ViewBag.TipoProdutos = combo;
        }

    }
}

using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;
using Fiap.Web.Donation2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation2.Controllers
{
    public class TrocaController : Controller
    {

        private readonly ProdutoRepository _produtoRepository;

        private readonly int UsuarioId = 1;

        public TrocaController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);        
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var trocaModel = new TrocaModel();
            trocaModel.ProdutoId1 = id;
            trocaModel.Produto1 = _produtoRepository.FindById(id);

            ComboMeusProduto();

            return View(trocaModel);
        }


        [HttpPost]
        public IActionResult Index(TrocaModel trocaModel)
        {
            var produto1 = _produtoRepository.FindById(trocaModel.ProdutoId1);
            var produto2 = _produtoRepository.FindById(trocaModel.ProdutoId2);

            try
            {
                if( produto1.Disponivel == false )
                {
                    throw new Exception("Produto selecionado indisponível");
                }

                if (produto2.Disponivel == false)
                {
                    throw new Exception("O seu produto já foi trocado e não está mais disponível");
                }

                if ( produto2.Valor / produto1.Valor < 0.9 )
                {
                    throw new Exception("O seu produto tem o valor abaixo de 90% do produto escolhido");
                }

                produto1.Disponivel = false;
                _produtoRepository.Update(produto1);

                produto2.Disponivel = false;
                _produtoRepository.Update(produto2);

                trocaModel.Status = TrocaStatus.Iniciado;

                //_trocaRepository.Insert(trocalModel);

                return RedirectToAction("Index", "Home");
            } catch (Exception ex)
            {

                TempData["Erro"] = ex.Message;

                return RedirectToAction("Index", "Home");

            }


            
        }


        private void ComboMeusProduto()
        {
            var produtos = _produtoRepository.FindAllDisponivelUsuarioTroca(UsuarioId);

            // Itens  ,   Valor Numerico , Texto  
            var combo = new SelectList(produtos, "ProdutoId", "Nome");

            ViewBag.Produtos = combo;
        }
    }
}

using Fiap.Web.Donation2.Data;
using Fiap.Web.Donation2.Models;
using Fiap.Web.Donation2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation2.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
        }


        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAll();

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new ProdutoModel());
        }


        [HttpPost]
        public IActionResult Novo(ProdutoModel produtoModel)
        {
            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
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

            // SELECT * FROM produto WHERE produtoid = id
            ProdutoModel produto = new ProdutoModel()
            {
                ProdutoId = 1,
                Nome = "Iphone 11",
                Descricao = "Descricao Descricao",
                TipoProdutoId = 1,
                Disponivel = true,
                DataExpiracao = DateTime.Now,
            };

            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if ( string.IsNullOrEmpty(produtoModel.Nome)  )
            {
                return View(produtoModel);
            } else
            {
                // INSERT
                TempData["Mensagem"] = $"Produto {produtoModel.Nome} editado com sucesso";

                return RedirectToAction("Index");
            }
            
        }



        // Simulando o acesso ao banco de dados para obter uma lista de produtos
        private IList<ProdutoModel> ListarProdutosMock()
        {
            // SELECT * FROM produtos;

            var produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    Nome = "Iphone 11",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    Nome = "Iphone 12",
                    TipoProdutoId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    Nome = "Iphone 13",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    Nome = "Iphone 14",
                    TipoProdutoId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },
            };

            return produtos;
        }

    }
}

using System;
using System.Web.Mvc;
using TesteDotNet.Core.Models;
using TesteDotNet.Core.Repositories;
using System.Linq;

namespace TesteDotNet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ItemModel filtros = new ItemModel();
        public ActionResult Index()
        {
            return View(TesteRepository.ConsultarItem(filtros));
        }

        [HttpPost]
        public ActionResult Cadastro(ItemModel dados)
        {
            if (ModelState.IsValid)
            {
                TesteRepository.AdicionarItem(dados);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dados);
            }
        }

        [HttpPost]
        public ActionResult Gravar(ItemModel dados)
        {
            if (ModelState.IsValid)
            {
                if (dados.Codigo != null)
                    TesteRepository.AlterarItem(dados);
                else
                    TesteRepository.AdicionarItem(dados);

                return RedirectToAction("Index");
            }
            else
            {
                return View(dados);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            ItemModel dados = new ItemModel()
            {
                Codigo = id
            };

            TesteRepository.ExcluirItem(dados);
            var result = new { Success = "True" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Cadastro(int? id)
        {
            ItemModel dados = new ItemModel();
            if (id != null)
            {
                dados.Codigo = id;
                dados = TesteRepository.ConsultarItem(dados).SingleOrDefault();
                return View(dados);
            }
            else
                return View();
        }


        [HttpGet]
        public ActionResult Detalhe(int id)
        {
            ItemModel dados = new ItemModel() {
                Codigo = id
            };
            dados = TesteRepository.ConsultarItem(dados).SingleOrDefault();
            return View(dados);
        }
    }
}
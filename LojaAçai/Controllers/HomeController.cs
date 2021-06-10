using LojaAçai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaAçai.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logar(string usuario, string senha)
        {
            CadastrarModels cm = new CadastrarModels();
            cm.Username = usuario;
            cm.Senha = senha;
            Session["UsuarioLogado"] = cm.logar();
            if (Session["UsuarioLogado"] != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Não encontrado no banco de dados";
                return RedirectToAction("Cadastrar");
            }
        }
        public ActionResult Diversos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Diversos(string quantidade)
        {
            CadastrarModels cm = new CadastrarModels();
            if (Session["UsuarioLogado"] == null)
            {
                TempData["msg"] = "Precisa logar primeiro";
                return View();
            }
            if (quantidade == null || quantidade == "") 
            {
                TempData["msg"] = "Preencha o campo quantidade";
                return View();
            }
            else
            {
                cm.Quantidade = quantidade;
                cm.Session = Session["UsuarioLogado"].ToString();
                TempData["msg"] = cm.ComprarDiversos();
                return RedirectToAction("Index");
            }
               
            
        }
        public ActionResult Completo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Completo(string quantidade)
        {
            CadastrarModels cm = new CadastrarModels();
            if (Session["UsuarioLogado"] == null)
            {
                TempData["msg"] = "Precisa logar primeiro";
                return View();
            }
            if (quantidade == null || quantidade == "")
            {
                TempData["msg"] = "Preencha o campo quantidade";
                return View();
            }
            else
            {
                cm.Quantidade = quantidade;
                cm.Session = Session["UsuarioLogado"].ToString();
                TempData["msg"] = cm.ComprarCompleto();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Barca()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Barca(string quantidade)
        {
            CadastrarModels cm = new CadastrarModels();
            if (Session["UsuarioLogado"] == null)
            {
                TempData["msg"] = "Precisa logar primeiro";
                return View();
            }
            if (quantidade == null || quantidade == "")
            {
                TempData["msg"] = "Preencha o campo quantidade";
                return View();
            }
            else
            {
                cm.Quantidade = quantidade;
                cm.Session = Session["UsuarioLogado"].ToString();
                TempData["msg"] = cm.ComprarBarca();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Chocolate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Chocolate(string quantidade)
        {
            CadastrarModels cm = new CadastrarModels();
            if (Session["UsuarioLogado"] == null)
            {
                TempData["msg"] = "Precisa logar primeiro";
                return View();
            }
            if (quantidade == null || quantidade == "")
            {
                TempData["msg"] = "Preencha o campo quantidade";
                return View();
            }
            else
            {
                cm.Quantidade = quantidade;
                cm.Session = Session["UsuarioLogado"].ToString();
                TempData["msg"] = cm.ComprarChocolate();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost] //apenas trata requisições
        public ActionResult Cadastrar(string usuario,string senha)
        {
            CadastrarModels cm = new CadastrarModels();
            cm.Username = usuario;
            cm.Senha = senha;
            TempData["msg"] = cm.SalvarM();
            if (TempData["msg"].ToString() == "Não preencheu todos os campos")
            {
                return View();
            }
                return RedirectToAction("Logar");


        }
        public ActionResult Carrinho()
        {
            if (Session["usuarioLogado"] != null)
            {
                CadastrarModels cm = new CadastrarModels();
                cm.Session = Session["UsuarioLogado"].ToString();
                List<CadastrarModels> lista = cm.ListarCarrinho();
                return View(lista);
            }
            else
            {
                return RedirectToAction("Logar");
            }
        }
        public ActionResult Excluir(string id)
        {
            Models.CadastrarModels c = new Models.CadastrarModels();
            c.Codigo = id;
            string msg = c.Cancelar();
            TempData["msg"] = msg;
            return RedirectToAction("Carrinho");
        }
    }
}
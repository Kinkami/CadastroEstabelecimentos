using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstabelecimentos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEstabelecimentos.Controllers
{
    public class EstabelecimentoController : Controller
    {
        EstabelecimentoDAL estabelecimentoDAL = new EstabelecimentoDAL();
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Estabelecimento> listaRegistros = new List<Estabelecimento>();
            listaRegistros = estabelecimentoDAL.BuscarTodos().ToList();
            return View(listaRegistros);
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([Bind] Estabelecimento estabelecimento)
        {

            if (estabelecimento.Categoria.Equals("Supermercado") && String.IsNullOrEmpty(estabelecimento.Telefone))
            {
                ModelState.AddModelError("Telefone", "O campo telefone é obrigatório!");
            }

            if (ModelState.IsValid)
            {
                estabelecimentoDAL.InsereNovo(estabelecimento);
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {

            if (id==null)
            {
                return NotFound();
            }
            Estabelecimento registro = estabelecimentoDAL.BuscarPorId(id);
            if (registro ==null)
            {
                return NotFound();
            }
            return View(registro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int? id, [Bind] Estabelecimento registro)
        {
            if (registro.Categoria.Equals("Supermercado") && String.IsNullOrEmpty(registro.Telefone))
            {
                ModelState.AddModelError("Telefone", "O campo telefone é obrigatório!");
            }

            if (id == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                estabelecimentoDAL.Atualiza(registro);
                return RedirectToAction("Index");
            }
            return View(estabelecimentoDAL);
        }

        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Estabelecimento registro = estabelecimentoDAL.BuscarPorId(id);
            if (registro == null)
            {
                return NotFound();
            }
            return View(registro);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Estabelecimento registro = estabelecimentoDAL.BuscarPorId(id);
            if (registro == null)
            {
                return NotFound();
            }
            return View(registro);
        }


        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int? id)
        {
            estabelecimentoDAL.Deletar(id);
            return RedirectToAction("Index");
        }


    }
}
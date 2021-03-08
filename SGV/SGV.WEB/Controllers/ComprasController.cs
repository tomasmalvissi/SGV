using Microsoft.AspNetCore.Mvc;
using SGV.DATA;
using SGV.WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGV.WEB.Controllers
{
    public class ComprasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ComprasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Compra> listCompras = _context.Compras;
            return View(listCompras);
        }

        //HTTP GET DEL CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();

                TempData["Msj"] = "Nueva compra creada con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET DEL EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var compra = _context.Compras.Find(id);

            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Update(compra);
                _context.SaveChanges();

                TempData["Msj"] = "Compra actualizada con exito.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET DEL DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var compra = _context.Compras.Find(id);

            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCompra(int? id)
        {
            var compra = _context.Compras.Find(id);

            if (compra == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Compras.Remove(compra);
                _context.SaveChanges();

                TempData["Msj"] = "Compra eliminada con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

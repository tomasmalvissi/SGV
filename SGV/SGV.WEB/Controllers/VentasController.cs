using Microsoft.AspNetCore.Mvc;
using SGV.DATA;
using SGV.WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGV.WEB.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Venta> listVentas = _context.Ventas;
            return View(listVentas);
        }

        //HTTP GET DEL CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta)
        {
            venta.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Ventas.Add(venta);
                _context.SaveChanges();

                TempData["Msj"] = "Nueva venta cargada con exito.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET DEL EDIT
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var venta = _context.Ventas.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Ventas.Update(venta);
                _context.SaveChanges();

                TempData["Msj"] = "Venta actualizada con exito.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET DEL DELETE
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var venta = _context.Ventas.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVenta(int? id)
        {
            var venta = _context.Ventas.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Ventas.Remove(venta);
                _context.SaveChanges();

                TempData["Msj"] = "Venta eliminada con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SGV.DATA;
using SGV.WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGV.WEB.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Producto> listaProd = _context.Productos;
            return View(listaProd);
        }

        //HTTP GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto prod)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(prod);
                _context.SaveChanges();

                TempData["Msj"] = "Nuevo producto cargado con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET DEL UPDATE PARA OBTENER ID
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto prod)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(prod);
                _context.SaveChanges();

                TempData["Msj"] = "Producto actualizado con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET DEL DELETE PARA SABER CUAL ELIMINAR
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProducto(int? id)
        {
            var prod = _context.Productos.Find(id);

            if (prod == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Productos.Remove(prod);
                _context.SaveChanges();

                TempData["Msj"] = "Producto eliminado con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

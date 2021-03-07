using Microsoft.AspNetCore.Mvc;
using SGV.DATA;
using SGV.WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGV.WEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> listClientes = _context.Clientes;
            return View(listClientes);
        }

        //HTTP GET DEL CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente) 
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                TempData["Msj"] = "Nuevo cliente creado con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET DEL UPDATE
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); 
            }

            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();

                TempData["Msj"] = "Cliente actualizado con exito.";
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

            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCliente(int? id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();

                TempData["Msj"] = "Cliente eliminado con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

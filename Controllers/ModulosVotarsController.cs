using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlterdataVotador.Data;
using AlterdataVotador.Models;

namespace AlterdataVotador.Controllers
{
    public class ModulosVotarsController : Controller
    {
        //Methodo que traz o Data AterdataVotadorContext.css para criar as amarrações das dependencias
        private readonly AlterdataVotadorContext _context;

        public ModulosVotarsController(AlterdataVotadorContext context)
        {
            _context = context;
        }

        // Carrega em Get, os dasdos para formar a View do Botão Votar << Botão Botar >>
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModulosVotar.ToListAsync());
        }

        // Carrega em Get, os dasdos para formar a View do Botão Detalhe << Botão Detalhe >>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosVotar = await _context.ModulosVotar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulosVotar == null)
            {
                return NotFound();
            }

            return View(modulosVotar);
        }

        // Pega o Que foi Criado no Create. para cadastro
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModulosVotars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameModulos,LinhaDoModulo")] ModulosVotar modulosVotar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulosVotar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modulosVotar);
        }

        // GET: ModulosVotars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosVotar = await _context.ModulosVotar.FindAsync(id);
            if (modulosVotar == null)
            {
                return NotFound();
            }
            return View(modulosVotar);
        }

        // POST: ModulosVotars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameModulos,LinhaDoModulo")] ModulosVotar modulosVotar)
        {
            if (id != modulosVotar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulosVotar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulosVotarExists(modulosVotar.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modulosVotar);
        }

        // GET: ModulosVotars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosVotar = await _context.ModulosVotar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulosVotar == null)
            {
                return NotFound();
            }

            return View(modulosVotar);
        }

        // POST: ModulosVotars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modulosVotar = await _context.ModulosVotar.FindAsync(id);
            _context.ModulosVotar.Remove(modulosVotar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulosVotarExists(int id)
        {
            return _context.ModulosVotar.Any(e => e.Id == id);
        }
    }
}

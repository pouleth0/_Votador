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
    public class MelhoriasVotarsController : Controller
    {
        //Methodo que traz o Data AterdataVotadorContext.css para criar as amarrações das dependencias
        private readonly AlterdataVotadorContext _context;

        public MelhoriasVotarsController(AlterdataVotadorContext context)
        {
            _context = context;
        }

        // Carrega em Get, os dasdos para formar a View do Botão Votar << Botão Botar >>
        public async Task<IActionResult> Index()
        {
            return View(await _context.MelhoriasVotar.ToListAsync());
        }

        // Carrega em Get, os dasdos para formar a View do Botão Detalhe << Botão Detalhe >>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melhoriasVotar = await _context.MelhoriasVotar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (melhoriasVotar == null)
            {
                return NotFound();
            }

            return View(melhoriasVotar);
        }

        // Pega o Que foi Criado no Create. para cadastro
        public IActionResult Create()
        {
            return View();
        }

        // POST: MelhoriasVotars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeModulo,MelhoriaArea,QuantVotos")] MelhoriasVotar melhoriasVotar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(melhoriasVotar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(melhoriasVotar);
        }

        // GET: MelhoriasVotars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melhoriasVotar = await _context.MelhoriasVotar.FindAsync(id);
            if (melhoriasVotar == null)
            {
                return NotFound();
            }
            return View(melhoriasVotar);
        }

        // POST: MelhoriasVotars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeModulo,MelhoriaArea,QuantVotos")] MelhoriasVotar melhoriasVotar)
        {
            if (id != melhoriasVotar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melhoriasVotar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MelhoriasVotarExists(melhoriasVotar.Id))
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
            return View(melhoriasVotar);
        }

        // GET: MelhoriasVotars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melhoriasVotar = await _context.MelhoriasVotar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (melhoriasVotar == null)
            {
                return NotFound();
            }

            return View(melhoriasVotar);
        }

        // POST: MelhoriasVotars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var melhoriasVotar = await _context.MelhoriasVotar.FindAsync(id);
            _context.MelhoriasVotar.Remove(melhoriasVotar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MelhoriasVotarExists(int id)
        {
            return _context.MelhoriasVotar.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlterdataVotador.Data;
using AlterdataVotador.Models;
using AlterdataVotador.Services;
using AlterdataVotador.Models.ViewModels;

namespace AlterdataVotador.Controllers
{
    public class UsuariosAcessesController : Controller
    {
        //Methodo que traz o Data AterdataVotadorContext.css para criar as amarrações das dependencias
        private readonly AlterdataVotadorContext _context;
        private readonly DepartamentServices _departamentServices;

        public UsuariosAcessesController(AlterdataVotadorContext context, DepartamentServices departamentServices)
        {
            _context = context;
            _departamentServices = departamentServices;
        }

        // Carrega em Get, os dasdos para formar a View do Botão Votar << Botão Botar >>
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuariosAcess.ToListAsync());
        }

        // Carrega em Get, os dasdos para formar a View do Botão Detalhe << Botão Detalhe >>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosAcess = await _context.UsuariosAcess
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuariosAcess == null)
            {
                return NotFound();
            }

            return View(usuariosAcess);
        }

        // Pega o Que foi Criado no Create. para cadastro
        public IActionResult Create()
        {
            var departaments = _departamentServices.FindAll();
            var viewModel = new SellerFormViewModel { NameModulos = departaments };
            return View(viewModel);
        }

        // POST: UsuariosAcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> Create([Bind("Id,NomeUsuario,TimeZoneUSuario,PassWord")] UsuariosAcess usuariosAcess)
        {
        
            if (ModelState.IsValid)
            {
                _context.Add(usuariosAcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuariosAcess);
        }

        // GET: UsuariosAcesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosAcess = await _context.UsuariosAcess.FindAsync(id);
            if (usuariosAcess == null)
            {
                return NotFound();
            }
            return View(usuariosAcess);
        }

        // POST: UsuariosAcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUsuario,TimeZoneUSuario,PassWord")] UsuariosAcess usuariosAcess)
        {
            if (id != usuariosAcess.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosAcess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosAcessExists(usuariosAcess.Id))
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
            return View(usuariosAcess);
        }
        // GET: UsuariosAcesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosAcess = await _context.UsuariosAcess
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuariosAcess == null)
            {
                return NotFound();
            }

            return View(usuariosAcess);
        }

        // POST: UsuariosAcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuariosAcess = await _context.UsuariosAcess.FindAsync(id);
            _context.UsuariosAcess.Remove(usuariosAcess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosAcessExists(int id)
        {
            return _context.UsuariosAcess.Any(e => e.Id == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Result(UsuariosAcess userSeller) => RedirectToAction(nameof(Index));
    }
}

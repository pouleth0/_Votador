using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlterdataVotador.Data;
using AlterdataVotador.Models;

namespace AlterdataVotador.Controllers
{
    public class VotarHomesController : Controller
    {
        private readonly AlterdataVotadorContext _context;

        public VotarHomesController(AlterdataVotadorContext context)
        {
            _context = context;
        }

        // GET: VotarHomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VotaHome.ToListAsync());
        }

        // GET: VotarHomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votarHome = await _context.VotaHome
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votarHome == null)
            {
                return NotFound();
            }

            return View(votarHome);
        }

        // GET: VotarHomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VotarHomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVotar,Status")] VotarHome votarHome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(votarHome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(votarHome);
        }

        // GET: VotarHomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votarHome = await _context.VotaHome.FindAsync(id);
            if (votarHome == null)
            {
                return NotFound();
            }
            return View(votarHome);
        }

        // POST: VotarHomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataVotar,Status")] VotarHome votarHome)
        {
            if (id != votarHome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(votarHome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotarHomeExists(votarHome.Id))
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
            return View(votarHome);
        }

        // GET: VotarHomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votarHome = await _context.VotaHome
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votarHome == null)
            {
                return NotFound();
            }

            return View(votarHome);
        }

        // POST: VotarHomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var votarHome = await _context.VotaHome.FindAsync(id);
            _context.VotaHome.Remove(votarHome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VotarHomeExists(int id)
        {
            return _context.VotaHome.Any(e => e.Id == id);
        }
    }
}

using berloga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace berloga.Controllers
{
    public class AllAdvertsController : Controller
    {
        private readonly berlogaContext _context;

        public AllAdvertsController(berlogaContext context)
        {
            _context = context;
        }

        // GET: AllAdverts
        public async Task<IActionResult> Index()
        {
            var berlogaContext = _context.AllAdverts.Include(a => a.IdAdvertsNavigation).Include(a => a.IdApartamentNavigation).Include(a => a.IdUserNavigation);
            return View(await berlogaContext.ToListAsync());
        }

        // GET: AllAdverts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allAdverts = await _context.AllAdverts
                .Include(a => a.IdAdvertsNavigation)
                .Include(a => a.IdApartamentNavigation)
                .Include(a => a.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdHome == id);
            if (allAdverts == null)
            {
                return NotFound();
            }

            return View(allAdverts);
        }

        // GET: AllAdverts/Create
        public IActionResult Create()
        {
            ViewData["IdAdverts"] = new SelectList(_context.TypeOfAdvert, "IdAdvert", "IdAdvert");
            ViewData["IdApartament"] = new SelectList(_context.TypeOfApartament, "IdApartament", "TypeOfApartament1");
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: AllAdverts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHome,IdAdverts,IdUser,IdApartament,TownDistrict,Adress,NumOfRooms,Square,AboutHome,Price,Image")] AllAdverts allAdverts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allAdverts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdverts"] = new SelectList(_context.TypeOfAdvert, "IdAdvert", "IdAdvert", allAdverts.IdAdverts);
            ViewData["IdApartament"] = new SelectList(_context.TypeOfApartament, "IdApartament", "TypeOfApartament1", allAdverts.IdApartament);
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", allAdverts.IdUser);
            return View(allAdverts);
        }

        // GET: AllAdverts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allAdverts = await _context.AllAdverts.FindAsync(id);
            if (allAdverts == null)
            {
                return NotFound();
            }
            ViewData["IdAdverts"] = new SelectList(_context.TypeOfAdvert, "IdAdvert", "IdAdvert", allAdverts.IdAdverts);
            ViewData["IdApartament"] = new SelectList(_context.TypeOfApartament, "IdApartament", "TypeOfApartament1", allAdverts.IdApartament);
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", allAdverts.IdUser);
            return View(allAdverts);
        }

        // POST: AllAdverts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHome,IdAdverts,IdUser,IdApartament,TownDistrict,Adress,NumOfRooms,Square,AboutHome,Price,Image")] AllAdverts allAdverts)
        {
            if (id != allAdverts.IdHome)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allAdverts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllAdvertsExists(allAdverts.IdHome))
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
            ViewData["IdAdverts"] = new SelectList(_context.TypeOfAdvert, "IdAdvert", "IdAdvert", allAdverts.IdAdverts);
            ViewData["IdApartament"] = new SelectList(_context.TypeOfApartament, "IdApartament", "TypeOfApartament1", allAdverts.IdApartament);
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", allAdverts.IdUser);
            return View(allAdverts);
        }

        // GET: AllAdverts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allAdverts = await _context.AllAdverts
                .Include(a => a.IdAdvertsNavigation)
                .Include(a => a.IdApartamentNavigation)
                .Include(a => a.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdHome == id);
            if (allAdverts == null)
            {
                return NotFound();
            }

            return View(allAdverts);
        }

        // POST: AllAdverts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allAdverts = await _context.AllAdverts.FindAsync(id);
            _context.AllAdverts.Remove(allAdverts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllAdvertsExists(int id)
        {
            return _context.AllAdverts.Any(e => e.IdHome == id);
        }
    }
}
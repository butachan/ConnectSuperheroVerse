using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperheroUniverse.Data;
using SuperheroUniverse.Models;

namespace SuperheroUniverse.Controllers
{
    public class SaveWorldsController : Controller
    {
        private readonly SuperheroUniverseContext _context;

        public SaveWorldsController(SuperheroUniverseContext context)
        {
            _context = context;
        }

        // GET: SaveWorlds
        public async Task<IActionResult> Index()
        {
              return _context.SaveWorld != null ? 
                          View(await _context.SaveWorld.ToListAsync()) :
                          Problem("Entity set 'SuperheroUniverseContext.SaveWorld'  is null.");
        }

        // GET: SaveWorlds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaveWorld == null)
            {
                return NotFound();
            }

            var saveWorld = await _context.SaveWorld
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saveWorld == null)
            {
                return NotFound();
            }

            return View(saveWorld);
        }

        // GET: SaveWorlds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaveWorlds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,ReleaseDate,context,Price")] SaveWorld saveWorld)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saveWorld);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saveWorld);
        }

        // GET: SaveWorlds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaveWorld == null)
            {
                return NotFound();
            }

            var saveWorld = await _context.SaveWorld.FindAsync(id);
            if (saveWorld == null)
            {
                return NotFound();
            }
            return View(saveWorld);
        }

        // POST: SaveWorlds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,ReleaseDate,context,Price")] SaveWorld saveWorld)
        {
            if (id != saveWorld.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saveWorld);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaveWorldExists(saveWorld.Id))
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
            return View(saveWorld);
        }

        // GET: SaveWorlds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaveWorld == null)
            {
                return NotFound();
            }

            var saveWorld = await _context.SaveWorld
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saveWorld == null)
            {
                return NotFound();
            }

            return View(saveWorld);
        }

        // POST: SaveWorlds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaveWorld == null)
            {
                return Problem("Entity set 'SuperheroUniverseContext.SaveWorld'  is null.");
            }
            var saveWorld = await _context.SaveWorld.FindAsync(id);
            if (saveWorld != null)
            {
                _context.SaveWorld.Remove(saveWorld);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaveWorldExists(int id)
        {
          return (_context.SaveWorld?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

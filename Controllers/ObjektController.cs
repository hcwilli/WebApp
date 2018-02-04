using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class ObjektController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObjektController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Objekt
        public async Task<IActionResult> Index()
        {
            return View(await _context.Objekt.ToListAsync());
        }

        // GET: Objekt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objekt = await _context.Objekt
                .SingleOrDefaultAsync(m => m.Id == id);
            if (objekt == null)
            {
                return NotFound();
            }

            return View(objekt);
        }

        // GET: Objekt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objekt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Objekt objekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objekt);
        }

        // GET: Objekt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objekt = await _context.Objekt.SingleOrDefaultAsync(m => m.Id == id);
            if (objekt == null)
            {
                return NotFound();
            }
            return View(objekt);
        }

        // POST: Objekt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Objekt objekt)
        {
            if (id != objekt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjektExists(objekt.Id))
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
            return View(objekt);
        }

        // GET: Objekt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objekt = await _context.Objekt
                .SingleOrDefaultAsync(m => m.Id == id);
            if (objekt == null)
            {
                return NotFound();
            }

            return View(objekt);
        }

        // POST: Objekt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objekt = await _context.Objekt.SingleOrDefaultAsync(m => m.Id == id);
            _context.Objekt.Remove(objekt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjektExists(int id)
        {
            return _context.Objekt.Any(e => e.Id == id);
        }
    }
}

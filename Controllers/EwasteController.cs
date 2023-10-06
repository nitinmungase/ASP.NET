using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ewaste_Collection.Data;
using Ewaste_Collection.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ewaste_Collection.Controllers
{
    public class EwasteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EwasteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ewastes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ewaste.ToListAsync());
        }

        // GET: Ewastes/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: Ewastes/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index",await _context.Ewaste.Where(E=>E.title.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Ewastes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ewaste = await _context.Ewaste
                .FirstOrDefaultAsync(m => m.id == id);
            if (ewaste == null)
            {
                return NotFound();
            }

            return View(ewaste);
        }

        // GET: Ewastes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ewastes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,pickupdate,quantity,weight,ecopoints")] Ewaste ewaste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ewaste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ewaste);
        }

        // GET: Ewastes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ewaste = await _context.Ewaste.FindAsync(id);
            if (ewaste == null)
            {
                return NotFound();
            }
            return View(ewaste);
        }

        // POST: Ewastes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,pickupdate,quantity,weight,ecopoints")] Ewaste ewaste)
        {
            if (id != ewaste.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ewaste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EwasteExists(ewaste.id))
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
            return View(ewaste);
        }

        // GET: Ewastes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ewaste = await _context.Ewaste
                .FirstOrDefaultAsync(m => m.id == id);
            if (ewaste == null)
            {
                return NotFound();
            }

            return View(ewaste);
        }

        // POST: Ewastes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ewaste = await _context.Ewaste.FindAsync(id);
            _context.Ewaste.Remove(ewaste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EwasteExists(int id)
        {
            return _context.Ewaste.Any(e => e.id == id);
        }
    }
}

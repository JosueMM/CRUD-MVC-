using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class MakeController : Controller
    {
        private readonly CRUDContext _context;

        public MakeController(CRUDContext context)
        {
            _context = context;
        }

        // GET: Make
        public async Task<IActionResult> Index()
        {
            return View(await _context.Make.ToListAsync());
        }

        // GET: Make/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeModel = await _context.Make
                .SingleOrDefaultAsync(m => m.id == id);
            if (makeModel == null)
            {
                return NotFound();
            }

            return View(makeModel);
        }

        // GET: Make/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Make/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] MakeModel makeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(makeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(makeModel);
        }

        // GET: Make/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeModel = await _context.Make.SingleOrDefaultAsync(m => m.id == id);
            if (makeModel == null)
            {
                return NotFound();
            }
            return View(makeModel);
        }

        // POST: Make/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] MakeModel makeModel)
        {
            if (id != makeModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakeModelExists(makeModel.id))
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
            return View(makeModel);
        }

        // GET: Make/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeModel = await _context.Make
                .SingleOrDefaultAsync(m => m.id == id);
            if (makeModel == null)
            {
                return NotFound();
            }

            return View(makeModel);
        }

        // POST: Make/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makeModel = await _context.Make.SingleOrDefaultAsync(m => m.id == id);
            _context.Make.Remove(makeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakeModelExists(int id)
        {
            return _context.Make.Any(e => e.id == id);
        }
    }
}

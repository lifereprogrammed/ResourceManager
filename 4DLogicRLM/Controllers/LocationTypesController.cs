using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _4DLogicRLM.Data;
using _4DLogicRLM.Models;

namespace _4DLogicRLM.Controllers
{
    public class LocationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationType.ToListAsync());
        }

        // GET: LocationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationType = await _context.LocationType
                .FirstOrDefaultAsync(m => m.LocationTypeID == id);
            if (locationType == null)
            {
                return NotFound();
            }

            return View(locationType);
        }

        // GET: LocationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationTypeID,LocationTypeName,LocationTypeDescription")] LocationType locationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationType);
        }

        // GET: LocationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationType = await _context.LocationType.FindAsync(id);
            if (locationType == null)
            {
                return NotFound();
            }
            return View(locationType);
        }

        // POST: LocationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationTypeID,LocationTypeName,LocationTypeDescription")] LocationType locationType)
        {
            if (id != locationType.LocationTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationTypeExists(locationType.LocationTypeID))
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
            return View(locationType);
        }

        // GET: LocationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationType = await _context.LocationType
                .FirstOrDefaultAsync(m => m.LocationTypeID == id);
            if (locationType == null)
            {
                return NotFound();
            }

            return View(locationType);
        }

        // POST: LocationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationType = await _context.LocationType.FindAsync(id);
            _context.LocationType.Remove(locationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationTypeExists(int id)
        {
            return _context.LocationType.Any(e => e.LocationTypeID == id);
        }
    }
}

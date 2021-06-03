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
    public class ResourceQuantityTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceQuantityTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResourceQuantityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResourceQuantityTypes.ToListAsync());
        }

        // GET: ResourceQuantityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceQuantityType = await _context.ResourceQuantityTypes
                .FirstOrDefaultAsync(m => m.ResourceQuantityTypeID == id);
            if (resourceQuantityType == null)
            {
                return NotFound();
            }

            return View(resourceQuantityType);
        }

        // GET: ResourceQuantityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceQuantityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceQuantityTypeID,ResournceQuantityTypeName,ResournceQuantityTypeDescription,ResourceQuantityTypeShortName")] ResourceQuantityType resourceQuantityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceQuantityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resourceQuantityType);
        }

        // GET: ResourceQuantityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceQuantityType = await _context.ResourceQuantityTypes.FindAsync(id);
            if (resourceQuantityType == null)
            {
                return NotFound();
            }
            return View(resourceQuantityType);
        }

        // POST: ResourceQuantityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceQuantityTypeID,ResournceQuantityTypeName,ResournceQuantityTypeDescription,ResourceQuantityTypeShortName")] ResourceQuantityType resourceQuantityType)
        {
            if (id != resourceQuantityType.ResourceQuantityTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceQuantityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceQuantityTypeExists(resourceQuantityType.ResourceQuantityTypeID))
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
            return View(resourceQuantityType);
        }

        // GET: ResourceQuantityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceQuantityType = await _context.ResourceQuantityTypes
                .FirstOrDefaultAsync(m => m.ResourceQuantityTypeID == id);
            if (resourceQuantityType == null)
            {
                return NotFound();
            }

            return View(resourceQuantityType);
        }

        // POST: ResourceQuantityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceQuantityType = await _context.ResourceQuantityTypes.FindAsync(id);
            _context.ResourceQuantityTypes.Remove(resourceQuantityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceQuantityTypeExists(int id)
        {
            return _context.ResourceQuantityTypes.Any(e => e.ResourceQuantityTypeID == id);
        }
    }
}

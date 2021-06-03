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
    public class ResourceTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResourceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResourceTypes.ToListAsync());
        }

        // GET: ResourceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceType = await _context.ResourceTypes
                .FirstOrDefaultAsync(m => m.ResourceTypeID == id);
            if (resourceType == null)
            {
                return NotFound();
            }

            return View(resourceType);
        }

        // GET: ResourceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceTypeID,ResourceTypeName,ResourceTypeDescription")] ResourceType resourceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resourceType);
        }

        // GET: ResourceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceType = await _context.ResourceTypes.FindAsync(id);
            if (resourceType == null)
            {
                return NotFound();
            }
            return View(resourceType);
        }

        // POST: ResourceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceTypeID,ResourceTypeName,ResourceTypeDescription")] ResourceType resourceType)
        {
            if (id != resourceType.ResourceTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceTypeExists(resourceType.ResourceTypeID))
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
            return View(resourceType);
        }

        // GET: ResourceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceType = await _context.ResourceTypes
                .FirstOrDefaultAsync(m => m.ResourceTypeID == id);
            if (resourceType == null)
            {
                return NotFound();
            }

            return View(resourceType);
        }

        // POST: ResourceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceType = await _context.ResourceTypes.FindAsync(id);
            _context.ResourceTypes.Remove(resourceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceTypeExists(int id)
        {
            return _context.ResourceTypes.Any(e => e.ResourceTypeID == id);
        }
    }
}

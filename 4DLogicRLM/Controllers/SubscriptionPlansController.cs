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
    public class SubscriptionPlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubscriptionPlans
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubscriptionPlans.ToListAsync());
        }

        // GET: SubscriptionPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionPlans = await _context.SubscriptionPlans
                .FirstOrDefaultAsync(m => m.SubscriptionPlanID == id);
            if (subscriptionPlans == null)
            {
                return NotFound();
            }

            return View(subscriptionPlans);
        }

        // GET: SubscriptionPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubscriptionPlanID,SubscriptionPlanName,SubscriptionPlanDescription,SubscriptionPlanFee,SubscriptionUserCount")] SubscriptionPlans subscriptionPlans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriptionPlans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionPlans);
        }

        // GET: SubscriptionPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionPlans = await _context.SubscriptionPlans.FindAsync(id);
            if (subscriptionPlans == null)
            {
                return NotFound();
            }
            return View(subscriptionPlans);
        }

        // POST: SubscriptionPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubscriptionPlanID,SubscriptionPlanName,SubscriptionPlanDescription,SubscriptionPlanFee,SubscriptionUserCount")] SubscriptionPlans subscriptionPlans)
        {
            if (id != subscriptionPlans.SubscriptionPlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriptionPlans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionPlansExists(subscriptionPlans.SubscriptionPlanID))
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
            return View(subscriptionPlans);
        }

        // GET: SubscriptionPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionPlans = await _context.SubscriptionPlans
                .FirstOrDefaultAsync(m => m.SubscriptionPlanID == id);
            if (subscriptionPlans == null)
            {
                return NotFound();
            }

            return View(subscriptionPlans);
        }

        // POST: SubscriptionPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriptionPlans = await _context.SubscriptionPlans.FindAsync(id);
            _context.SubscriptionPlans.Remove(subscriptionPlans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionPlansExists(int id)
        {
            return _context.SubscriptionPlans.Any(e => e.SubscriptionPlanID == id);
        }
    }
}

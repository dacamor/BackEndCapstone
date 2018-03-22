using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Data;
using BackEndCapstone.Models;

namespace WebApplication1.Controllers
{
    public class PlayerAttributesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerAttributesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerAttributes
        public async Task<IActionResult> Index(int? id)
        {
            var applicationDbContext = _context.PlayerAttribute.Where(a => a.PlayerId == id).Include(p => p.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerAttributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerAttribute = await _context.PlayerAttribute
                .Include(p => p.Player)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playerAttribute == null)
            {
                return NotFound();
            }

            return View(playerAttribute);
        }

        // GET: PlayerAttributes/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "FirstName");
            return View();
        }

        // POST: PlayerAttributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Stat,Value,PlayerId")] PlayerAttribute playerAttribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerAttribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "FirstName", playerAttribute.PlayerId);
            return View(playerAttribute);
        }

        // GET: PlayerAttributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerAttribute = await _context.PlayerAttribute.SingleOrDefaultAsync(m => m.Id == id);
            if (playerAttribute == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "FirstName", playerAttribute.PlayerId);
            return View(playerAttribute);
        }

        // POST: PlayerAttributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Stat,Value,PlayerId")] PlayerAttribute playerAttribute)
        {
            if (id != playerAttribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerAttribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerAttributeExists(playerAttribute.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "FirstName", playerAttribute.PlayerId);
            return View(playerAttribute);
        }

        // GET: PlayerAttributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerAttribute = await _context.PlayerAttribute
                .Include(p => p.Player)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playerAttribute == null)
            {
                return NotFound();
            }

            return View(playerAttribute);
        }

        // POST: PlayerAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerAttribute = await _context.PlayerAttribute.SingleOrDefaultAsync(m => m.Id == id);
            _context.PlayerAttribute.Remove(playerAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerAttributeExists(int id)
        {
            return _context.PlayerAttribute.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyOrganiserWebApp.Data;
using PartyOrganiserWebApp.Models;

namespace PartyOrganiserWebApp.Controllers
{
    public class PartyAttendancesController : Controller
    {
        private readonly PartyOrganiserWebAppContext _context;

        public PartyAttendancesController(PartyOrganiserWebAppContext context)
        {
            _context = context;
        }

        // GET: PartyAttendances
        public async Task<IActionResult> Index()
        {
            var partyOrganiserWebAppContext = _context.PartyAttendance.Include(p => p.Party).Include(p => p.Person);
            return View(await partyOrganiserWebAppContext.ToListAsync());
        }

        // GET: PartyAttendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PartyAttendance == null)
            {
                return NotFound();
            }

            var partyAttendance = await _context.PartyAttendance
                .Include(p => p.Party)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyAttendance == null)
            {
                return NotFound();
            }

            return View(partyAttendance);
        }

        // GET: PartyAttendances/Create
        public IActionResult Create(int partyId)
        {
            PartyAttendance partyAttendance = new PartyAttendance();
            partyAttendance.PartyId = partyId;
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "FirstName");

            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name");
            return View(partyAttendance);
        }

        // POST: PartyAttendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,DrinkId,PartyId")] PartyAttendance partyAttendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partyAttendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "FirstName", partyAttendance.PersonId);
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", partyAttendance.DrinkId);

            return View(partyAttendance);
        }

        // GET: PartyAttendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PartyAttendance == null)
            {
                return NotFound();
            }

            var partyAttendance = await _context.PartyAttendance.FindAsync(id);
            if (partyAttendance == null)
            {
                return NotFound();
            }
            ViewData["PartyId"] = new SelectList(_context.Set<BaseParty>(), "Id", "Discriminator", partyAttendance.PartyId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", partyAttendance.PersonId);
            return View(partyAttendance);
        }

        // POST: PartyAttendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,PartyId")] PartyAttendance partyAttendance)
        {
            if (id != partyAttendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partyAttendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyAttendanceExists(partyAttendance.Id))
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
            ViewData["PartyId"] = new SelectList(_context.Set<BaseParty>(), "Id", "Discriminator", partyAttendance.PartyId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", partyAttendance.PersonId);
            return View(partyAttendance);
        }

        // GET: PartyAttendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PartyAttendance == null)
            {
                return NotFound();
            }

            var partyAttendance = await _context.PartyAttendance
                .Include(p => p.Party)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyAttendance == null)
            {
                return NotFound();
            }

            return View(partyAttendance);
        }

        // POST: PartyAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PartyAttendance == null)
            {
                return Problem("Entity set 'PartyOrganiserWebAppContext.PartyAttendance'  is null.");
            }
            var partyAttendance = await _context.PartyAttendance.FindAsync(id);
            if (partyAttendance != null)
            {
                _context.PartyAttendance.Remove(partyAttendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyAttendanceExists(int id)
        {
          return _context.PartyAttendance.Any(e => e.Id == id);
        }
    }
}

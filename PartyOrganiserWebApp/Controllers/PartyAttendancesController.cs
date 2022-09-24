using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyOrganiserWebApp.Data;
using PartyOrganiserWebApp.Models;
using PartyOrganiserWebApp.ViewModels;

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
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var partyOrganiserWebAppContext = _context.PartyAttendance.Include(p => p.Party).Include(p => p.Person);
                return View(await partyOrganiserWebAppContext.ToListAsync());
            }

            if(_context.Parties == null)
            {
                return NotFound();
            }

            var party = await _context.Parties.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }

            var attendants = await _context.PartyAttendance.Where(x => x.PartyId == id).Include(p => p.Drink).Include(p => p.Person).ToListAsync();

            PartyAttendantsViewModel vm = new PartyAttendantsViewModel(attendants, party);
            return View(vm);
            
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
            
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
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
                return RedirectToAction(nameof(Index), new {id = partyAttendance.PartyId});
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", partyAttendance.PersonId);
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
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", partyAttendance.PersonId);
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", partyAttendance.DrinkId);
            return View(partyAttendance);
        }

        // POST: PartyAttendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,PartyId,DrinkId")] PartyAttendance partyAttendance)
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
                return RedirectToAction(nameof(Index), new { id = partyAttendance.PartyId });
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", partyAttendance.PersonId);
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", partyAttendance.DrinkId);
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
            if (partyAttendance != null)
            {
                //check to keep delete as idempotent
                return RedirectToAction(nameof(Index), new { id = partyAttendance.PartyId });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PartyAttendanceExists(int id)
        {
          return _context.PartyAttendance.Any(e => e.Id == id);
        }
    }
}

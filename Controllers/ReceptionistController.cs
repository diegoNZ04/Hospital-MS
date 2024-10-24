using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Management.Data;
using Hospital_Management.Models;

namespace Hospital_Management.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly HMSContext _context;

        public ReceptionistController(HMSContext context)
        {
            _context = context;
        }

        // GET: Receptionist
        public async Task<IActionResult> Index()
        {
            var hMSContext = _context.Receptionists.Include(r => r.Employee);
            return View(await hMSContext.ToListAsync());
        }

        // GET: Receptionist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionist = await _context.Receptionists
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receptionist == null)
            {
                return NotFound();
            }

            return View(receptionist);
        }

        // GET: Receptionist/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address");
            return View();
        }

        // POST: Receptionist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId")] Receptionist receptionist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receptionist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address", receptionist.EmployeeId);
            return View(receptionist);
        }

        // GET: Receptionist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address", receptionist.EmployeeId);
            return View(receptionist);
        }

        // POST: Receptionist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId")] Receptionist receptionist)
        {
            if (id != receptionist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receptionist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptionistExists(receptionist.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address", receptionist.EmployeeId);
            return View(receptionist);
        }

        // GET: Receptionist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionist = await _context.Receptionists
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receptionist == null)
            {
                return NotFound();
            }

            return View(receptionist);
        }

        // POST: Receptionist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist != null)
            {
                _context.Receptionists.Remove(receptionist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceptionistExists(int id)
        {
            return _context.Receptionists.Any(e => e.Id == id);
        }
    }
}

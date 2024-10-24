using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Management.Data;
using Hospital_Management.Models;

namespace Hospital_Management.Controllers
{
    public class NurseController : Controller
    {
        private readonly HMSContext _context;

        public NurseController(HMSContext context)
        {
            _context = context;
        }

        // GET: Nurse
        public async Task<IActionResult> Index()
        {
            var hMSContext = _context.Nurses.Include(n => n.Employee);
            return View(await hMSContext.ToListAsync());
        }

        // GET: Nurse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Nurses
                .Include(n => n.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nurse == null)
            {
                return NotFound();
            }

            return View(nurse);
        }

        // GET: Nurse/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address");
            return View();
        }

        // POST: Nurse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nurse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address", nurse.EmployeeId);
            return View(nurse);
        }

        // GET: Nurse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address", nurse.EmployeeId);
            return View(nurse);
        }

        // POST: Nurse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId")] Nurse nurse)
        {
            if (id != nurse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nurse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NurseExists(nurse.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address", nurse.EmployeeId);
            return View(nurse);
        }

        // GET: Nurse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Nurses
                .Include(n => n.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nurse == null)
            {
                return NotFound();
            }

            return View(nurse);
        }

        // POST: Nurse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse != null)
            {
                _context.Nurses.Remove(nurse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.Id == id);
        }
    }
}

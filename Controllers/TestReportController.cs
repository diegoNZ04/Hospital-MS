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
    public class TestReportController : Controller
    {
        private readonly HMSContext _context;

        public TestReportController(HMSContext context)
        {
            _context = context;
        }

        // GET: TestReport
        public async Task<IActionResult> Index()
        {
            var hMSContext = _context.TestReports.Include(t => t.Patient);
            return View(await hMSContext.ToListAsync());
        }

        // GET: TestReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testReport = await _context.TestReports
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testReport == null)
            {
                return NotFound();
            }

            return View(testReport);
        }

        // GET: TestReport/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Address");
            return View();
        }

        // POST: TestReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,TestType,Result")] TestReport testReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Address", testReport.PatientId);
            return View(testReport);
        }

        // GET: TestReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testReport = await _context.TestReports.FindAsync(id);
            if (testReport == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Address", testReport.PatientId);
            return View(testReport);
        }

        // POST: TestReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,TestType,Result")] TestReport testReport)
        {
            if (id != testReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestReportExists(testReport.Id))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Address", testReport.PatientId);
            return View(testReport);
        }

        // GET: TestReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testReport = await _context.TestReports
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testReport == null)
            {
                return NotFound();
            }

            return View(testReport);
        }

        // POST: TestReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testReport = await _context.TestReports.FindAsync(id);
            if (testReport != null)
            {
                _context.TestReports.Remove(testReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestReportExists(int id)
        {
            return _context.TestReports.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{   [Authorize(Roles ="SuperAdmin")]
    
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employeemanagement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(string WID)
        {
            if (WID == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.WID == WID);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Roommanagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roommanagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WID,Name,Birth,Phone,ID,Sex,Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Roommanagement/Edit/5
        public async Task<IActionResult> Edit(string WID)
        {
            if (WID == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(WID);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Roommanagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string WID, [Bind("WID,Name,Birth,Phone,ID,Sex,Age")] Employee employee)
        {
            if (WID != employee.WID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(employee.WID))
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
            return View(employee);
        }

        // GET: Roommanagement/Delete/5
        public async Task<IActionResult> Delete(string WID)
        {
            if (WID == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.WID == WID);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Roommanagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string WID)
        {
            var employee = await _context.Employee.FindAsync(WID);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(string WID)
        {
            return _context.Employee.Any(e => e.WID == WID);
        }
    }
}

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
{
    
    public class UserController : Controller
    {
        
        private readonly UserContext _context;
        
        public UserController(UserContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "SuperAdmin")]
        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLogin.ToListAsync());
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin
                .FirstOrDefaultAsync(m => m.WID == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }
        [Authorize(Roles = "SuperAdmin")]
        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WID,Account,Password,Authorize")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLogin);
        }
        [Authorize(Roles = "SuperAdmin")]
        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }
            return View(userLogin);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WID,Account,Password,Authorize")] UserLogin userLogin)
        {
            if (id != userLogin.WID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLoginExists(userLogin.WID))
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
            return View(userLogin);
        }
        [Authorize(Roles = "SuperAdmin")]
        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin
                .FirstOrDefaultAsync(m => m.WID == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }
        
        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userLogin = await _context.UserLogin.FindAsync(id);
            _context.UserLogin.Remove(userLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLoginExists(string id)
        {
            return _context.UserLogin.Any(e => e.WID == id);
        }
    }
}

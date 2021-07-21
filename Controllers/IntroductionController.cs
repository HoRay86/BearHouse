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
{   [Authorize(Roles ="SuperAdmin,Admin")]
    
    public class IntroductionController : Controller
    {
        private readonly IntroductionContext _context;

        public IntroductionController(IntroductionContext context)
        {
            _context = context;
        }

        // GET: Introduction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Introduction.ToListAsync());
        }

        // GET: Introduction/Details/
        public async Task<IActionResult> Details(string RoomType)
        {
            if (RoomType == null)
            {
                return NotFound();
            }

            var introduction = await _context.Introduction
                .FirstOrDefaultAsync(m => m.RoomType == RoomType);
            if (introduction == null)
            {
                return NotFound();
            }

            return View(introduction);
        }

        // GET: Introduction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Introduction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomType,Photo,Photo1,Photo2,RoomSize,Description,Singlebed," +
            "Doublebed,TV,Airconditioning,Bathtub,Tellphone,Refrigerator,ShowerRoom,RoomContent,RoomTxt")] Introduction introduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(introduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(introduction);
        }

        // GET: Introduction/Edit/5
        public async Task<IActionResult> Edit(string RoomType)
        {
            if (RoomType == null)
            {
                return NotFound();
            }

            var introduction = await _context.Introduction.FindAsync(RoomType);
            if (introduction == null)
            {
                return NotFound();
            }
            return View(introduction);
        }

        // POST: Introduction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string RoomType, [Bind("RoomType,Photo,Photo1,Photo2,RoomSize,Description,Singlebed," +
            "Doublebed,TV,Airconditioning,Bathtub,Tellphone,Refrigerator,ShowerRoom,RoomContent,RoomTxt")] Introduction introduction)
        {
            if (RoomType != introduction.RoomType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(introduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(introduction.RoomType))
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
            return View(introduction);
        }

        // GET: Introduction/Delete/5
        public async Task<IActionResult> Delete(string RoomType)
        {
            if (RoomType == null)
            {
                return NotFound();
            }

            var introduction = await _context.Introduction
                .FirstOrDefaultAsync(m => m.RoomType == RoomType);
            if (introduction == null)
            {
                return NotFound();
            }

            return View(introduction);
        }

        // POST: Introduction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string RoomType)
        {
            var introduction = await _context.Introduction.FindAsync(RoomType);
            _context.Introduction.Remove(introduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(string RoomType)
        {
            return _context.Introduction.Any(e => e.RoomType == RoomType);
        }
    }
}

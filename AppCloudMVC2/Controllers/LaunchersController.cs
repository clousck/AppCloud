using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCloud.Entidades;

namespace AppCloudMVC2.Controllers
{
    public class LaunchersController : Controller
    {
        private readonly DbContext _context;

        public LaunchersController(DbContext context)
        {
            _context = context;
        }

        // GET: Launchers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Launchers.ToListAsync());
        }

        // GET: Launchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launcher = await _context.Launchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (launcher == null)
            {
                return NotFound();
            }

            return View(launcher);
        }

        // GET: Launchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Launchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Launcher launcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(launcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(launcher);
        }

        // GET: Launchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launcher = await _context.Launchers.FindAsync(id);
            if (launcher == null)
            {
                return NotFound();
            }
            return View(launcher);
        }

        // POST: Launchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Launcher launcher)
        {
            if (id != launcher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(launcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LauncherExists(launcher.Id))
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
            return View(launcher);
        }

        // GET: Launchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launcher = await _context.Launchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (launcher == null)
            {
                return NotFound();
            }

            return View(launcher);
        }

        // POST: Launchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launcher = await _context.Launchers.FindAsync(id);
            if (launcher != null)
            {
                _context.Launchers.Remove(launcher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LauncherExists(int id)
        {
            return _context.Launchers.Any(e => e.Id == id);
        }
    }
}

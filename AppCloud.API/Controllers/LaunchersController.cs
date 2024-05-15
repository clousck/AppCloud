using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppCloud.Entidades;

namespace AppCloud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchersController : ControllerBase
    {
        private readonly DbContext _context;

        public LaunchersController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Launchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Launcher>>> GetLauncher()
        {
            return await _context.Launchers.ToListAsync();
        }

        // GET: api/Launchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Launcher>> GetLauncher(int id)
        {
            var launcher = await _context.Launchers.FindAsync(id);

            if (launcher == null)
            {
                return NotFound();
            }

            return launcher;
        }

        // PUT: api/Launchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLauncher(int id, Launcher launcher)
        {
            if (id != launcher.Id)
            {
                return BadRequest();
            }

            _context.Entry(launcher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LauncherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Launchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Launcher>> PostLauncher(Launcher launcher)
        {
            _context.Launchers.Add(launcher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLauncher", new { id = launcher.Id }, launcher);
        }

        // DELETE: api/Launchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLauncher(int id)
        {
            var launcher = await _context.Launchers.FindAsync(id);
            if (launcher == null)
            {
                return NotFound();
            }

            _context.Launchers.Remove(launcher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LauncherExists(int id)
        {
            return _context.Launchers.Any(e => e.Id == id);
        }
    }
}

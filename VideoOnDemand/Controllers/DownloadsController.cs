using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoOnDemand.Data;
using VideoOnDemand.Entities;
using Microsoft.AspNetCore.Authorization;

namespace VideoOnDemand.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/[controller]/[action]")]
    public class DownloadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DownloadsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Downloads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Downloads.ToListAsync());
        }

        // GET: Downloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Downloads
                .SingleOrDefaultAsync(m => m.Id == id);
            if (download == null)
            {
                return NotFound();
            }

            return View(download);
        }

        // GET: Downloads/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Title");
            return View();
        }

        // POST: Downloads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Url,ModuleId,CourseId")] Download download)
        {
            if (ModelState.IsValid)
            {
                _context.Add(download);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Title");
            return View(download);
        }

        // GET: Downloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Downloads.SingleOrDefaultAsync(m => m.Id == id);
            if (download == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Title");
            return View(download);
        }

        // POST: Downloads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Url,ModuleId,CourseId")] Download download)
        {
            if (id != download.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(download);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DownloadExists(download.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Title");
            return View(download);
        }

        // GET: Downloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var download = await _context.Downloads
                .SingleOrDefaultAsync(m => m.Id == id);
            if (download == null)
            {
                return NotFound();
            }

            return View(download);
        }

        // POST: Downloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var download = await _context.Downloads.SingleOrDefaultAsync(m => m.Id == id);
            _context.Downloads.Remove(download);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DownloadExists(int id)
        {
            return _context.Downloads.Any(e => e.Id == id);
        }
    }
}

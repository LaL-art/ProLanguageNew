using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProLanguage.Data;
using ProLanguage.Models.Entities;

namespace ProLanguage.Controllers
{
    public class UserFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserFiles.ToListAsync());
        }

        // GET: UserFiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFile = await _context.UserFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFile == null)
            {
                return NotFound();
            }

            return View(userFile);
        }

        // GET: UserFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FileName,FilePath,UploadDate,IsPrivate,Username")] UserFile userFile)
        {
            if (ModelState.IsValid)
            {
                userFile.Id = Guid.NewGuid();
                _context.Add(userFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userFile);
        }

        // GET: UserFiles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFile = await _context.UserFiles.FindAsync(id);
            if (userFile == null)
            {
                return NotFound();
            }
            return View(userFile);
        }

        // POST: UserFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FileName,FilePath,UploadDate,IsPrivate,Username")] UserFile userFile)
        {
            if (id != userFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFileExists(userFile.Id))
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
            return View(userFile);
        }

        // GET: UserFiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFile = await _context.UserFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFile == null)
            {
                return NotFound();
            }

            return View(userFile);
        }

        // POST: UserFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userFile = await _context.UserFiles.FindAsync(id);
            if (userFile != null)
            {
                _context.UserFiles.Remove(userFile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFileExists(Guid id)
        {
            return _context.UserFiles.Any(e => e.Id == id);
        }
    }
}

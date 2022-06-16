using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using noam2.Data;
using noam2.Model;

namespace noam2.Controllers
{
    public class MessageExtendedsController : Controller
    {
        private readonly noam2Context _context;

        public MessageExtendedsController(noam2Context context)
        {
            _context = context;
        }

        // GET: MessageExtendeds
        public async Task<IActionResult> Index()
        {
              return _context.MessageExtended != null ? 
                          View(await _context.MessageExtended.ToListAsync()) :
                          Problem("Entity set 'noam2Context.MessageExtended'  is null.");
        }

        // GET: MessageExtendeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MessageExtended == null)
            {
                return NotFound();
            }

            var messageExtended = await _context.MessageExtended
                .FirstOrDefaultAsync(m => m.Id == id);
            if (messageExtended == null)
            {
                return NotFound();
            }

            return View(messageExtended);
        }

        // GET: MessageExtendeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MessageExtendeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Created,Sent,User1,User2")] MessageExtended messageExtended)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messageExtended);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(messageExtended);
        }

        // GET: MessageExtendeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MessageExtended == null)
            {
                return NotFound();
            }

            var messageExtended = await _context.MessageExtended.FindAsync(id);
            if (messageExtended == null)
            {
                return NotFound();
            }
            return View(messageExtended);
        }

        // POST: MessageExtendeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Created,Sent,User1,User2")] MessageExtended messageExtended)
        {
            if (id != messageExtended.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messageExtended);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExtendedExists(messageExtended.Id))
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
            return View(messageExtended);
        }

        // GET: MessageExtendeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MessageExtended == null)
            {
                return NotFound();
            }

            var messageExtended = await _context.MessageExtended
                .FirstOrDefaultAsync(m => m.Id == id);
            if (messageExtended == null)
            {
                return NotFound();
            }

            return View(messageExtended);
        }

        // POST: MessageExtendeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MessageExtended == null)
            {
                return Problem("Entity set 'noam2Context.MessageExtended'  is null.");
            }
            var messageExtended = await _context.MessageExtended.FindAsync(id);
            if (messageExtended != null)
            {
                _context.MessageExtended.Remove(messageExtended);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExtendedExists(int id)
        {
          return (_context.MessageExtended?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

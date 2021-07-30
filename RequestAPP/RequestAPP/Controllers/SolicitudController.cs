using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RequestAPP.Models;

namespace RequestAPP.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly RequestContext _context;

        public SolicitudController(RequestContext context)
        {
            _context = context;
        }

        // GET: Solicitud
        public async Task<IActionResult> Index()
        {
            var requestContext = _context.Solicitud.Include(s => s.persona);
            return View(await requestContext.ToListAsync());
        }

        // GET: Solicitud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Persona, "Id", "Nombre");
            ViewData["estado"] = new SelectList(_context.Estado, "Id", "Estado_Solicitud");
            return View();
        }

        // POST: Solicitud/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonaId,FechaDeCreacion,EstadoId")] Solicitud solicitud)
        {
            Estado estado = new Estado();
            solicitud.FechaDeCreacion = DateTimeOffset.UtcNow;
           if(solicitud.EstadoId == 0)
            {
                estado.Estado_Solicitud = "Abierta";
            }
          
           
            
            if (ModelState.IsValid)
            {
                
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "Id", "Nombre", solicitud.PersonaId);
            ViewData["estado"] = new SelectList(_context.Estado, "Id", "Estado_Solicitud", solicitud.EstadoId);
            return View(solicitud);
        }

        // GET: Solicitud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "Id", "Nombre", solicitud.PersonaId);
            ViewData["estado"] = new SelectList(_context.Estado, "Id", "Estado_Solicitud", solicitud.estado);
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,FechaDeCreacion")] Solicitud solicitud)
        {
            if (id != solicitud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.Id))
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
            ViewData["PersonaId"] = new SelectList(_context.Persona, "Id", "Nombre", solicitud.PersonaId);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            _context.Solicitud.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.Id == id);
        }
    }
}

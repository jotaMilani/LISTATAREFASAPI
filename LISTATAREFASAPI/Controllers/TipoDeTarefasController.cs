using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LISTATAREFASAPI.Data;
using LISTATAREFASAPI.Models;

namespace LISTATAREFASAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeTarefasController : ControllerBase
    {
        private readonly ListaTarefasContext _context;

        public TipoDeTarefasController(ListaTarefasContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeTarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeTarefa>>> GetTiposDeTarefas()
        {
            return await _context.TiposDeTarefas.ToListAsync();
        }

        // GET: api/TipoDeTarefas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeTarefa>> GetTipoDeTarefa(int id)
        {
            var tipoDeTarefa = await _context.TiposDeTarefas.FindAsync(id);

            if (tipoDeTarefa == null)
            {
                return NotFound();
            }

            return tipoDeTarefa;
        }

        // PUT: api/TipoDeTarefas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeTarefa(int id, TipoDeTarefa tipoDeTarefa)
        {
            if (id != tipoDeTarefa.TipoDeTarefaId)
            {
                return BadRequest();
            }

            _context.Entry(tipoDeTarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeTarefaExists(id))
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

        // POST: api/TipoDeTarefas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDeTarefa>> PostTipoDeTarefa(TipoDeTarefa tipoDeTarefa)
        {
            _context.TiposDeTarefas.Add(tipoDeTarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDeTarefa", new { id = tipoDeTarefa.TipoDeTarefaId }, tipoDeTarefa);
        }

        // DELETE: api/TipoDeTarefas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeTarefa(int id)
        {
            var tipoDeTarefa = await _context.TiposDeTarefas.FindAsync(id);
            if (tipoDeTarefa == null)
            {
                return NotFound();
            }

            _context.TiposDeTarefas.Remove(tipoDeTarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDeTarefaExists(int id)
        {
            return _context.TiposDeTarefas.Any(e => e.TipoDeTarefaId == id);
        }
    }
}

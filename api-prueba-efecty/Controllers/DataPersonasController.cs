
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_prueba_efecty.Context;
using api_prueba_efecty.Models;
using Microsoft.AspNetCore.Cors;

namespace api_prueba_efecty.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DataPersonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DataPersonaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DataPersona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataPersona>>> GetDataPersona()
        {
            return await _context.DataPersona.ToListAsync();
        }

        // GET: api/DataPersona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataPersona>> GetDataPersona(int id)
        {
            var dataPersona = await _context.DataPersona.FindAsync(id);

            if (dataPersona == null)
            {
                return NotFound();
            }

            return dataPersona;
        }

        // PUT: api/DataPersona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataPersona(int id, DataPersona dataPersona)
        {
            if (id != dataPersona.id)
            {
                return BadRequest();
            }

            _context.Entry(dataPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataPersonaExists(id))
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

        // POST: api/DataPersona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataPersona>> PostDataPersona(DataPersona dataPersona)
        {
            _context.DataPersona.Add(dataPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataPersona", new { id = dataPersona.id }, dataPersona);
        }

        // DELETE: api/DataPersona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataPersona(int id)
        {
            var dataPersona = await _context.DataPersona.FindAsync(id);
            if (dataPersona == null)
            {
                return NotFound();
            }

            _context.DataPersona.Remove(dataPersona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataPersonaExists(int id)
        {
            return _context.DataPersona.Any(e => e.id == id);
        }
    }
}

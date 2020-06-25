using F23.StringSimilarity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary.Models;
using PortfolioEndpoint.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymbolsController : ControllerBase
    {
        private readonly PortfolioEndpointContext _context;

        public SymbolsController(PortfolioEndpointContext context)
        {
            _context = context;
        }

        // GET: api/Symbols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symbol>>> GetSymbols()
        {
            return await _context.Symbols.ToListAsync();
        }

        // GET: api/Symbols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Symbol>> GetSymbol(int id)
        {
            var symbol = await _context.Symbols.FindAsync(id);

            if (symbol == null)
            {
                return NotFound();
            }

            return symbol;
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symbol>>> GetSymbolByName(string name)
        {
            var symbol = await _context.Symbols
                .Where(symbol => symbol.Name.ToLower() == name.ToLower())
                .ToListAsync();

            if (symbol.Count == 0)
            {
                var symbols = await _context.Symbols.ToListAsync();
                var jw = new JaroWinkler();

                foreach (var sbl in symbols)
                {
                    var comp = jw.Similarity(name.ToLower(), sbl.Name.ToLower());
                    if (comp > 0.85)
                    {
                        symbol.Add(sbl);
                    }
                }

                if (symbol.Count == 0)
                {
                    return NotFound();
                }
            }

            return symbol;
        }

        // PUT: api/Symbols/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymbol(int id, Symbol symbol)
        {
            if (id != symbol.SymbolId)
            {
                return BadRequest();
            }

            _context.Entry(symbol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymbolExists(id))
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

        // POST: api/Symbols
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Symbol>> PostSymbol([FromBody]Symbol symbol)
        {
            _context.Symbols.Add(symbol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSymbol", new { id = symbol.SymbolId }, symbol);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<Stock>> PostSymbols([FromBody]List<Symbol> symbols)
        {
            _context.Symbols.AddRange(symbols);
            await _context.SaveChangesAsync();

            return StatusCode(201, symbols);
        }

        // DELETE: api/Symbols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Symbol>> DeleteSymbol(int id)
        {
            var symbol = await _context.Symbols.FindAsync(id);
            if (symbol == null)
            {
                return NotFound();
            }

            _context.Symbols.Remove(symbol);
            await _context.SaveChangesAsync();

            return symbol;
        }

        private bool SymbolExists(int id)
        {
            return _context.Symbols.Any(e => e.SymbolId == id);
        }
    }
}

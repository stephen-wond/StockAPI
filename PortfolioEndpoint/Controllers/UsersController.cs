using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary.Models;
using PortfolioEndpoint.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PortfolioEndpointContext _context;

        public UsersController(PortfolioEndpointContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users
                .Include(user => user.Stocks)
                    .ThenInclude(stock => stock.Symbol)
                .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserId(int id)
        {
            var user = await _context.Users
                .Include(user => user.Stocks)
                    .ThenInclude(stock => stock.Symbol)
                .FirstOrDefaultAsync(user => user.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/5
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUserTelegramId(int id)
        {
            var user = await _context.Users.
                Where(x => x.ExternalId == id)
                .Include(user => user.Stocks)
                    .ThenInclude(stock => stock.Symbol)
                .ToListAsync();

            if (user == null)
            {
                return NotFound();
            }
            if (user.Count > 1)
            {
                return UnprocessableEntity("Multiple users found.");
            }

            return user.FirstOrDefault();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("No JSON body.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return StatusCode(201, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}

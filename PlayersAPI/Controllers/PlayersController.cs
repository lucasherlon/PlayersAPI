using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayersAPI.Models;

namespace PlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly Context.AppDbContext? _context;

        public PlayersController(Context.AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Player>> Post(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult(new { id = player.PlayerId }, player);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

    }
}

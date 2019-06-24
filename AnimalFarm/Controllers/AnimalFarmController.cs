using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalFarm.Models;


namespace AnimalFarm.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    [ApiController]
    public class AnimalFarmController : Controller
    {
        private readonly AnimalFarmContext _context;
        private readonly int GlobalHappinessDecreaseRate = -1;
        private readonly int GlobalHungerIncreaseRate = 1;

        public AnimalFarmController(AnimalFarmContext context)
        {
            _context = context;

            if (_context.AFUsers.Count() == 0)
            {
                // Create a new AFUsers if collection is empty,
                // which means you can't delete all AFUsers.
                _context.AFUsers.Add(new AnimalFarmUser { NickName = "PlayerNameTest" });
                _context.SaveChanges();
            }
        }

        
        // GET: api/animals/search?namelike=th
        [HttpGet("api/animals/search")]
        public async Task<IActionResult> Index(string id)
        {
            var items = from m in _context.AFItems
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                items = items.Where(s => s.Name.Contains(id));
            }

            return View(await _context.AFItems.ToListAsync());
        }


        // GET: api/animals
        [HttpGet("api/animals")]
        public async Task<ActionResult<IEnumerable<AnimalFarmItem>>> GetAnimalFarmItems()
        {
            return await _context.AFItems.ToListAsync();
        }

        // GET: api/animals/5
        [HttpGet("api/animals/{id}")]
        public async Task<ActionResult<AnimalFarmItem>> GetAnimalFarmItemWithId(long id)
        {
            var afItem = await _context.AFItems.FindAsync(id);

            if (afItem == null)
            {
                return NotFound();
            }

            return afItem;
        }

        // POST: api/animalfarm create a new animal
        [HttpPost("api/animals")]
        public async Task<ActionResult<AnimalFarmItem>> PostAnimalItem(AnimalFarmItem item)
        {
            _context.AFItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnimalFarmItemWithId), new { id = item.Id }, item);
        }

        // PUT: api/animalfarm/5
        [HttpPut("api/animals/{id}")]
        public async Task<IActionResult> PutAnimalItem(long id, AnimalFarmItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/animalfarm/5
        [HttpDelete("api/animals/{id}")]
        public async Task<IActionResult> DeleteAnimalItem(long id)
        {
            var todoItem = await _context.AFItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.AFItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        // GET: api/users
        [HttpGet("api/users")]
        public async Task<ActionResult<IEnumerable<AnimalFarmUser>>> GetAnimalFarmUsers()
        {
            return await _context.AFUsers.ToListAsync();
        }
        
        // GET: api/users/5
        [HttpGet("api/users/{id}")]
        public async Task<ActionResult<AnimalFarmUser>> GetAnimalFarmUserWithId(long id)
        {
            var afUser = await _context.AFUsers.FindAsync(id);

            if (afUser == null)
            {
                return NotFound();
            }

            return afUser;
        }

        // POST: api/animalfarm create a new animal
        [HttpPost("api/animals")]
        public async Task<ActionResult<AnimalFarmItem>> PostTodoItem(AnimalFarmItem item)
        {
            _context.AFItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnimalFarmItemWithId), new { id = item.Id }, item);
        }

        // PUT: api/animalfarm/5
        [HttpPut("api/animals/{id}")]
        public async Task<IActionResult> PutTodoItem(long id, AnimalFarmItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/animalfarm/5
        [HttpDelete("api/animals/{id}")]
        public async Task<IActionResult> DeleteAnimalItem(long id)
        {
            var todoItem = await _context.AFItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.AFItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
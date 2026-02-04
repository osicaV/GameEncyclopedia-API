using GameEncyclopedia.Data;
using GameEncyclopedia.Dtos;
using GameEncyclopedia.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameEncyclopedia.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MonstersController : ControllerBase {
        private readonly GameEncyclopediaDbContext _db;

        public MonstersController(GameEncyclopediaDbContext db) {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonsterResponse>>> GetAllMonsters(CancellationToken ct) {
            var monsters = await _db.Monsters
                .AsNoTracking()
                .OrderBy(m => m.Id)
                .Select(m => new MonsterResponse {
                    Id = m.Id,
                    Name = m.Name,
                })
                .ToListAsync(ct);

            return Ok(monsters);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<List<MonsterResponse>>> GetMonsterById(int id, CancellationToken ct) {
            var monster = await _db.Monsters
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new MonsterResponse {
                    Id = m.Id,
                    Name = m.Name,
                })
                .FirstOrDefaultAsync(ct);

            if (monster is null) return NotFound();

            return Ok(monster);
        }

        [HttpPost]
        public async Task<ActionResult<MonsterResponse>> Create(CreateMonsterRequest request) {

            var name = request.Name.Trim();

            var exists = await _db.Monsters.AsNoTracking().AnyAsync(m => m.Name == name);

            if (exists) return Conflict(new { message = "Monster with this name already exists."});

            var monster = new Monster {
                Name = name
            };

            _db.Monsters.Add(monster);
            await _db.SaveChangesAsync();

            var response = new MonsterResponse {
                Id = monster.Id,
                Name = monster.Name
            };

            return CreatedAtAction(nameof(GetMonsterById), new { id = monster.Id }, response);
        }
    }
}

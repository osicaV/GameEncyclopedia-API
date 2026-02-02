using GameEncyclopedia.Data;
using GameEncyclopedia.Dtos;
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
    }
}

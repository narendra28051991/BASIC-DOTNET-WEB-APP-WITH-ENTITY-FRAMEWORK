using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Services.SuperHeroService;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>?>> GetSuperHeroes()
        {
            return await _superHeroService.GetSuperHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>?> GetSingleHero(int id)
        {
            var superHero = await _superHeroService.GetSingleHero(id);
            
            if (superHero is null)
                return NotFound("Sorry, this hero doesn't exist.");

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>?>> AddSuperHero(SuperHero hero)
        {
            var superHeroes = await _superHeroService.AddSuperHero(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>?>> EditHero(int id, SuperHero request)
        {
            var superHeroes = await _superHeroService.EditHero(id, request);

            if (superHeroes is null)
                return NotFound("Sorry, this hero doesn't exist.");

            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>?>> DeleteHero(int id)
        {
            var superHero = await _superHeroService.DeleteHero(id);
            
            if (superHero is null)
                return NotFound("Sorry, this hero doesn't exist.");

            return Ok(superHero);
        }
    }
}

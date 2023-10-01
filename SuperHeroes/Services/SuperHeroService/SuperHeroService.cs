namespace SuperHeroes.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>?> GetSuperHeroes()
        {
            var superHeroes = await _context.SuperHeroes.ToListAsync();
            return superHeroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null)
            {
                return null;
            }

            return superHero;
        }

        public async Task<List<SuperHero>?> AddSuperHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);

            await _context.SaveChangesAsync();
            
            return await GetSuperHeroes();
        }

        public async Task<List<SuperHero>?> EditHero(int id, SuperHero request)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null)
            {
                return null;
            }

            superHero.Name = request.Name;
            superHero.FirstName = request.FirstName;
            superHero.LastName = request.LastName;
            superHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await GetSuperHeroes();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            _context.SuperHeroes.Remove(superHero);

            await _context.SaveChangesAsync();

            return await GetSuperHeroes();
        }
    }
}

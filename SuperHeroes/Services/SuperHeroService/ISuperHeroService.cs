namespace SuperHeroes.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>?> GetSuperHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>?> AddSuperHero(SuperHero hero);
        Task<List<SuperHero>?> EditHero(int id, SuperHero request);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}

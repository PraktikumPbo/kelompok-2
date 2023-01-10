namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public interface IBooksService
    {
        List<Buku> Bukus { get; set; }
        List<Genre> Genres { get; set; }
        Task GetComics();
        Task GetSuperHeroes();
        Task<Buku> GetSingleHero(int id);
        Task CreateHero(Buku hero);
        Task UpdateHero(Buku hero);
        Task DeleteHero(int id);
    }
}

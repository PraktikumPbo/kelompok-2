using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public BooksService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Buku> Bukus { get; set; } = new List<Buku>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public async Task CreateHero(Buku hero)
        {
            var result = await _http.PostAsJsonAsync("api/books", hero);
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Buku>>();
            Bukus = response;
            _navigationManager.NavigateTo("books");
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/books/{id}");
            await SetHeroes(result);
        }

        public async Task GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<Genre>>("api/books/genres");
            if (result != null)
                Genres = result;
        }

        public async Task<Buku> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<Buku>($"api/books/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<Buku>>("api/books");
            if (result != null)
                Bukus = result;
        }

        public async Task UpdateHero(Buku hero)
        {
            var result = await _http.PutAsJsonAsync($"api/books/{hero.Id}", hero);
            await SetHeroes(result);
        }
    }
}

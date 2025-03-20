using ImenikApp.DTO;
using ImenikApp.Models;

namespace ImenikApp.Repository {
    public interface IOsobaRepository {
        Task<IEnumerable<Osoba>> GetAllOsobeAsync();
        Task<Osoba?> GetOsobaByIdAsync(int id);
        Task<Osoba> AddOsobaAsync(Osoba osoba);
        Task UpdateOsobaAsync(Osoba osoba);
        Task DeleteOsobaAsync(int id);
    }
}

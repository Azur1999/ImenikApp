using ImenikApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImenikApp.Repository
{
    public interface IOsobaRepository
    {
        Task<IEnumerable<Osoba>> GetAllOsobeAsync();
        Task<Osoba?> GetOsobaByIdAsync(int id);
        Task AddOsobaAsync(Osoba osoba);
        Task UpdateOsobaAsync(Osoba osoba);
        Task DeleteOsobaAsync(int id);
        //Task<Grad?> GetGradByNameAsync(string naziv);
    }
}

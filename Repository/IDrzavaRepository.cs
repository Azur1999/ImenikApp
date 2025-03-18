using ImenikApp.Models;

namespace ImenikApp.Repositories
{
    public interface IDrzavaRepository
    {
        Task<IEnumerable<Drzava>> GetAllDrzaveAsync();
        Task<Drzava?> GetDrzavaByIdAsync(int id);
        Task AddDrzavaAsync(Drzava drzava);
        Task UpdateDrzavaAsync(Drzava drzava);
        Task DeleteDrzavaAsync(int id);

        Task<IEnumerable<Grad>> GetGradoviByDrzava(int DrzavaId);

    }
}

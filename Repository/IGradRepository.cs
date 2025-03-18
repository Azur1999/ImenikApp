using ImenikApp.Models;

namespace ImenikApp.Repositories {
    public interface IGradRepository {
        Task<IEnumerable<Grad>> GetAllGradAsync();
        Task<Grad?> GetGradByIdAsync(int id);
        Task AddGradAsync(Grad grad);
        Task UpdateGradAsync(Grad grad);
        Task DeleteGradAsync(int id);
        Task<Grad?> GetGradByNameAsync(string naziv);
    }
}

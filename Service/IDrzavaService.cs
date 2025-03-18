using ImenikApp.DTO;
using ImenikApp.Models;

namespace ImenikApp.Services {
    public interface IDrzavaService {
        Task<IEnumerable<DrzavaDTO>> GetAllDrzave();
        Task<DrzavaDTO?> GetDrzavaById(int id);
        Task AddDrzava(DrzavaDTO drzava);
        Task UpdateDrzava(DrzavaDTO drzava);
        Task DeleteDrzava(int id);

        Task<IEnumerable<GradDTO>> getGradoviByDrzava(int id);
    }
}

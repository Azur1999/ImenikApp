using ImenikApp.DTO;
using ImenikApp.Models;

namespace ImenikApp.Services {
    public interface IDrzavaService {
        Task<IEnumerable<DrzavaResponseDTO>> GetAllDrzave();
        Task<DrzavaResponseDTO?> GetDrzavaById(int id);
        
        // treba uzimati DrzavaPostRequestDTO ali nam zasad add i update  metoda ne treba
        Task AddDrzava(DrzavaResponseDTO drzava);
        Task UpdateDrzava(DrzavaResponseDTO drzava);
        Task DeleteDrzava(int id);
        Task<IEnumerable<GradResponseDTO>> getGradoviByDrzava (int drzavaId);

    }
}

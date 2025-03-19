using ImenikApp.DTO;

namespace ImenikApp.Services {
    public interface IGradService {
        Task<IEnumerable<GradResponseDTO>> GetAllGrad();
        Task<GradResponseDTO?> GetGradById(int id);
        Task DeleteGrad(int id);
    }
}
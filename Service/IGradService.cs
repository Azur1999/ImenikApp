using ImenikApp.DTO;

namespace ImenikApp.Services {
    public interface IGradService {
        Task<IEnumerable<GradDTO>> GetAllGrad();
        Task<GradDTO?> GetGradById(int id);
        Task DeleteGrad(int id);
    }
}
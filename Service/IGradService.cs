using ImenikApp.Models;
namespace ImenikApp.Services
{
    public interface IGradService
    {
        Task<IEnumerable<GradDTO>> GetAllGrad();
        Task<GradDTO?> GetGradById(int id);
        Task AddGrad(GradDTO grad);
        Task UpdateGrad(GradDTO grad);
        Task DeleteGrad(int id);
    }
}
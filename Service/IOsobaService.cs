using ImenikApp.DTO;

namespace ImenikApp.Services {
    public interface IOsobaService {
        Task<IEnumerable<OsobaDTO>> GetAllOsobe();
        Task<OsobaDTO?> GetOsobaById(int id);
        Task<OsobaPostDTO> CreateOsoba(OsobaDTO osobaDto);
        Task UpdateOsoba(int id, OsobaDTO osobaDto);
        Task DeleteOsoba(int id);
    }
}

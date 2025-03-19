using ImenikApp.DTO;

namespace ImenikApp.Services {
    public interface IOsobaService {
        Task<IEnumerable<OsobaResponseDTO>> GetAllOsobe();
        Task<OsobaResponseDTO?> GetOsobaById(int id);
        Task<OsobaPostResponseDTO> CreateOsoba(OsobaPostRequestDTO osobaDto);
        Task UpdateOsoba(int id, OsobaPutRequestDTO osobaDto);
        Task DeleteOsoba(int id);
    }
}

using ImenikApp.DTO;
using ImenikApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImenikApp.Services
{
    public interface IOsobaService
    {
        Task<IEnumerable<OsobaDTO>> GetAllOsobe();
        Task<OsobaDTO?> GetOsobaById(int id);
        Task CreateOsoba(OsobaDTO osobaDto);
        Task UpdateOsoba(int id, OsobaDTO osobaDto);
        Task DeleteOsoba(int id);
    }
}

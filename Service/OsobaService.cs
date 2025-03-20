using AutoMapper;
using ImenikApp.DTO;
using ImenikApp.Models;
using ImenikApp.Repositories;
using ImenikApp.Repository;

namespace ImenikApp.Services {
    public class OsobaService : IOsobaService {
        private readonly IOsobaRepository _osobaRepository;
        private readonly IMapper _mapper;

        public OsobaService(IOsobaRepository osobaRepository, IMapper mapper, IDrzavaRepository drzavaRepository, IGradRepository gradRepository)
        {
            _osobaRepository = osobaRepository;
            _mapper = mapper;
            
        }
        public async Task<IEnumerable<OsobaResponseDTO>> GetAllOsobe () {
            return _mapper.Map<IEnumerable<OsobaResponseDTO>>
                (await _osobaRepository.GetAllOsobeAsync());
        }

        public async Task<OsobaResponseDTO?> GetOsobaById(int id) {
            var o = await _osobaRepository.GetOsobaByIdAsync(id);
            return _mapper.Map<OsobaResponseDTO>(o);
        }

        public async Task<OsobaPostResponseDTO> CreateOsoba(OsobaPostRequestDTO osobaDto) {     
            var o = await _osobaRepository.AddOsobaAsync(_mapper.Map<Osoba>(osobaDto));
            return  _mapper.Map<OsobaPostResponseDTO>(o);
        }
        public async Task UpdateOsoba(int id, OsobaPutRequestDTO osobaDto) {
            var osoba = _mapper.Map<Osoba>(osobaDto);
            osoba.OsobaId = id;
            await _osobaRepository.UpdateOsobaAsync(osoba);
        }
        public async Task DeleteOsoba(int id)
        {
            await _osobaRepository.DeleteOsobaAsync(id);
        }
    }
}

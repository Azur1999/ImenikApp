using AutoMapper;
using ImenikApp.DTO;
using ImenikApp.Models;
using ImenikApp.Repositories;

namespace ImenikApp.Services {
    public class DrzavaService : IDrzavaService {
        private readonly IDrzavaRepository _drzavaRepository;
        private readonly IMapper _mapper;
        public DrzavaService(IDrzavaRepository drzavaRepository, IMapper mapper) {
            _drzavaRepository = drzavaRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DrzavaResponseDTO>> GetAllDrzave() {
             return _mapper.Map<IEnumerable<DrzavaResponseDTO>>(await _drzavaRepository.GetAllDrzaveAsync());
        }

        // u put i post trebaju kao ulazi nove DTO jer  DrzavaResponse sluzi samo za
        //slanje podataka frontendu
        //sad nam ne trebaju put i post
        public async Task AddDrzava(DrzavaResponseDTO drzava) {
            await _drzavaRepository.AddDrzavaAsync(_mapper.Map<Drzava>(drzava)); 
        }

        public async Task UpdateDrzava(DrzavaResponseDTO drzava) {
            await _drzavaRepository.UpdateDrzavaAsync(_mapper.Map<Drzava>(drzava) );
        }
        public async Task DeleteDrzava(int id) {
            await _drzavaRepository.DeleteDrzavaAsync(id);
        }
        public async Task<DrzavaResponseDTO?> GetDrzavaById(int id) {
           return _mapper.Map<DrzavaResponseDTO> ( await _drzavaRepository.GetDrzavaByIdAsync(id));
        }

        public async Task<IEnumerable<GradResponseDTO>> getGradoviByDrzava(int drzavaId) {
             return _mapper.Map<IEnumerable<GradResponseDTO>>(await _drzavaRepository.GetGradoviByDrzava(drzavaId));
        }
    
    }
}

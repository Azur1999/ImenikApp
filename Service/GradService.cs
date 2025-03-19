using AutoMapper;
using ImenikApp.DTO;
using ImenikApp.Models;
using ImenikApp.Repositories;

namespace ImenikApp.Services {
    public class GradService : IGradService {
        private readonly IMapper _mapper;
        private readonly IGradRepository _gradRepository;
        // Injekcija zavisnodsti putem konstruktora
        public GradService(IGradRepository gradRepository, IMapper mapper)
        {
            _gradRepository = gradRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GradResponseDTO>> GetAllGrad() {
            return _mapper.Map<IEnumerable<GradResponseDTO>> ( await _gradRepository.GetAllGradAsync());
        }

        public async Task<GradResponseDTO?> GetGradById(int id) {
            return _mapper.Map<GradResponseDTO> (await _gradRepository.GetGradByIdAsync(id));
        }

        public async Task AddGrad(GradResponseDTO grad)
        {
            await _gradRepository.AddGradAsync(_mapper.Map<Grad>(grad));
        }

        
        public async Task UpdateGrad(GradResponseDTO grad) {
            await _gradRepository.UpdateGradAsync(_mapper.Map<Grad>(grad));
        }
        public async Task DeleteGrad(int id) {
            await _gradRepository.DeleteGradAsync(id);
        }

        public async Task<GradResponseDTO?> GetGradByName(string naziv) {
            return _mapper.Map<GradResponseDTO> (await _gradRepository.GetGradByNameAsync(naziv));
        }
    }
}



using AutoMapper;
using ImenikApp.Models;
using ImenikApp.Repositories;

namespace ImenikApp.Services
{
    public class GradService : IGradService
    {
        private readonly IMapper _mapper;
        private readonly IGradRepository _gradRepository;

        // Injekcija zavisnodsti putem konstruktora
        public GradService(IGradRepository gradRepository, IMapper mapper)
        {
            _gradRepository = gradRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GradDTO>> GetAllGrad()
        {
            return _mapper.Map<IEnumerable<GradDTO>> ( await _gradRepository.GetAllGradAsync());
        }

        public async Task<GradDTO?> GetGradById(int id)
        {
            return _mapper.Map<GradDTO> (await _gradRepository.GetGradByIdAsync(id));
        }

        public async Task AddGrad(GradDTO grad)
        {
            await _gradRepository.AddGradAsync(_mapper.Map<Grad>(grad));
        }

        
        public async Task UpdateGrad(GradDTO grad)
        {
            await _gradRepository.UpdateGradAsync(_mapper.Map<Grad>(grad));
        }
         public async Task DeleteGrad(int id)
        {
            await _gradRepository.DeleteGradAsync(id);
        }

        public async Task<GradDTO?> GetGradByName(string naziv)
        {
            return _mapper.Map<GradDTO> (await _gradRepository.GetGradByNameAsync(naziv));
        }
    }
}



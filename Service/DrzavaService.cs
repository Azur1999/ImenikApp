using AutoMapper;
using ImenikApp.DTO;
using ImenikApp.Models;
using ImenikApp.Repositories;

namespace ImenikApp.Services
{
    public class DrzavaService : IDrzavaService
    {
        private readonly IDrzavaRepository _drzavaRepository;
        private readonly IMapper _mapper;


        public DrzavaService(IDrzavaRepository drzavaRepository, IMapper mapper)
        {
            _drzavaRepository = drzavaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DrzavaDTO>> GetAllDrzave()
        {
             return _mapper.Map<IEnumerable<DrzavaDTO>>(await _drzavaRepository.GetAllDrzaveAsync());

        }


        public async Task AddDrzava(DrzavaDTO drzava)
        {

            await _drzavaRepository.AddDrzavaAsync(_mapper.Map<Drzava>(drzava)); 
        }

        public async Task UpdateDrzava(DrzavaDTO drzava)
        {
            await _drzavaRepository.UpdateDrzavaAsync(_mapper.Map<Drzava>(drzava) );
        }

        public async Task DeleteDrzava(int id)
        {
            await _drzavaRepository.DeleteDrzavaAsync(id);
        }

        public async Task<DrzavaDTO?> GetDrzavaById(int id)
        {
           return _mapper.Map<DrzavaDTO> ( await _drzavaRepository.GetDrzavaByIdAsync(id));
        }

        public async Task<IEnumerable<GradDTO>> getGradoviByDrzava(int id) {
            return _mapper.Map<IEnumerable<GradDTO>>(await _drzavaRepository.GetGradoviByDrzava(id));
        }
    }
}

using AutoMapper;
using ImenikApp.Models;
using ImenikApp.DTO;

namespace ImenikApp.Profiles {
public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        //dest je DTO
        CreateMap<Osoba, OsobaResponseDTO>()
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                DateTime.Now.Year - src.DatumRodjenja.Year - 
                (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)
            ));

        CreateMap<Osoba, OsobaPostResponseDTO>()
            .ForMember(dest => dest.OsobaId, opt => opt.MapFrom(src => src.OsobaId))
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                DateTime.Now.Year - src.DatumRodjenja.Year - 
                (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)
            ));

        CreateMap<OsobaResponseDTO, Osoba>();





        CreateMap<Drzava, DrzavaResponseDTO>();
        CreateMap<Grad, GradResponseDTO>();
        // CreateMap<GradDTO,Grad>();
        //CreateMap<DrzavaDTO,Drzava>();        
    }
}

}
using AutoMapper;
using ImenikApp.Models;
using ImenikApp.DTO;

namespace ImenikApp.Profiles {
public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        //dest je DTO
        CreateMap<Osoba, OsobaDTO>()
            .ForMember(dest => dest.NazivGrad, opt => opt.MapFrom(src => src.Grad.NazivGrad))  
            .ForMember(dest => dest.NazivDrzava, opt => opt.MapFrom(src => src.Drzava.NazivDrzava))
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                DateTime.Now.Year - src.DatumRodjenja.Year - 
                (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)
            ));
    
        CreateMap<OsobaDTO, Osoba>();
        CreateMap<Drzava, DrzavaDTO>();
        CreateMap<Grad, GradDTO>();

        CreateMap<Osoba, OsobaPostDTO>()
            .ForMember(dest => dest.OsobaId, opt => opt.MapFrom(src => src.OsobaId))
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                DateTime.Now.Year - src.DatumRodjenja.Year - 
                (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)
            ));
            


        // CreateMap<GradDTO,Grad>();
        //CreateMap<DrzavaDTO,Drzava>();        
    }
}

}
using AutoMapper;
using ImenikApp.Models;
using ImenikApp.DTO;

namespace ImenikApp.Profiles {
public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        //dest je DTO
        CreateMap<Osoba, OsobaResponseDTO>()
            .ForMember(dest => dest.OsobaId, opt => opt.MapFrom(src => src.OsobaId))
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                    DateTime.Now.Year - src.DatumRodjenja.Year -
                    (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)))
            .ForMember(dest => dest.NazivDrzava,
                    opt => opt.MapFrom(src => src.Drzava != null ? src.Drzava.NazivDrzava : "Undefined"))
              .ForMember(dest => dest.NazivGrad, opt => opt.MapFrom(src => src.Grad != null ? src.Grad.NazivGrad : "Undefined")
        );

        
        CreateMap<Osoba, OsobaPostResponseDTO>()
            .ForMember(dest => dest.OsobaId, opt => opt.MapFrom(src => src.OsobaId))
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                DateTime.Now.Year - src.DatumRodjenja.Year - 
                (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)
            ));
        CreateMap<Grad,GradResponseDTO>();
        CreateMap<OsobaPostRequestDTO,Osoba>();

        CreateMap<OsobaPutRequestDTO,Osoba>();
        CreateMap<OsobaResponseDTO, Osoba>();
        CreateMap<Osoba,OsobaResponseDTO>();
            

        CreateMap<Drzava, DrzavaResponseDTO>();
        CreateMap<Grad, GradResponseDTO>();
        // CreateMap<GradDTO,Grad>();
        //CreateMap<DrzavaDTO,Drzava>();        
    }
}

}
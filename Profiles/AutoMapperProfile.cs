using AutoMapper;
using ImenikApp.Models;
using ImenikApp.DTO;


namespace ImenikApp.Profiles {

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Osoba, OsobaDTO>()
            .ForMember(dest => dest.nazivGrad, opt => opt.MapFrom(src => src.Grad.NazivGrad))  
            .ForMember(dest => dest.nazivDrzava, opt => opt.MapFrom(src => src.Drzava.NazivDrzava))
            .ForMember(dest => dest.Starost, opt => opt.MapFrom(src =>
                DateTime.Now.Year - src.DatumRodjenja.Year -
                (DateTime.Now.DayOfYear < src.DatumRodjenja.DayOfYear ? 1 : 0)
            ));
    
        CreateMap<OsobaDTO, Osoba>();

        CreateMap<Drzava, DrzavaDTO>();
        CreateMap<Grad, GradDTO>();
        CreateMap<GradDTO,Grad>();
        CreateMap<DrzavaDTO,Drzava>();
        
    }
}

}
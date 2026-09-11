using AutoMapper;
using US.BLL.DTOs.AboutContents;
using US.BLL.DTOs.Identity;
using US.BLL.DTOs.ShortUrls;
using US.DAL.Entities;

namespace US.BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, AuthResponse>();
        
        CreateMap<ShortUrl, ShortUrlResponse>()
            .ForMember(dest => dest.CreatedByEmail, opt => opt.MapFrom(src => src.CreatedBy!.Email));

        CreateMap<AboutContent, AboutContentResponse>()
            .ForMember(dest => dest.LastModifiedByEmail, opt => opt.MapFrom(src => src.LastModifiedBy!.Email));
    }
}
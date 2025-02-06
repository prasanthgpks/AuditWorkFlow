using AutoMapper;
using AWF.Razor.Models.Domain;
using AWF.Razor.Models.Dtos;

namespace AWF.Razor.Mappings
{
    public class AutoMaperProfiles : Profile
    {
        public AutoMaperProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerRequestDto>().ReverseMap();
        }
    }
}

using AuditWorkFlow.Razor.Models.Domain;
using AuditWorkFlow.Razor.Models.Dtos;
using AutoMapper;

namespace AuditWorkFlow.Razor.Mappings
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

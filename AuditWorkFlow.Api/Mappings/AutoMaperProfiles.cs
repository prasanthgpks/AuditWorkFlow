using AuditWorkFlow.Api.Models.Domain;
using AuditWorkFlow.Api.Models.Dtos;
using AutoMapper;

namespace AuditWorkFlow.Api.Mappings
{
    public class AutoMaperProfiles : Profile
    {
        public AutoMaperProfiles() 
        {
            CreateMap<Customer , CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerRequestDto>().ReverseMap();
        }
    }
}

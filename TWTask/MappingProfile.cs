using AutoMapper;
using TWTask.Dtos;
using TWTask.Models;

namespace TWTask
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employees>().ReverseMap(); 
            CreateMap<AddressDto, Address>().ReverseMap();
            

        }
    }
}

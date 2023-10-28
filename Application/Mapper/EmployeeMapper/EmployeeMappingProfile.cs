
using Application.Command;
using Application.Command.EmployeeCommands;
using Application.DTO;
using Application.DTO.Employee;
using AutoMapper;
using Core.Entities.EmployeeManagement;
using System.Xml.Linq;

namespace Application.Mapper.EmployeeMapper
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();

            var config = new MapperConfiguration(cfg =>
            {
                // Add your specific mappings here
                cfg.CreateMap<EmployeeUpdateRequestDTO, UpdateEmployeeCommand>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
            });

            CreateMap<Employee, EmployeeCreateRequestDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequestDTO>()
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
    .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => src.Bonus))
    .ForMember(dest => dest.BaseSalary, opt => opt.MapFrom(src => src.BaseSalary))
    .ForMember(dest => dest.OvertimeHours, opt => opt.MapFrom(src => src.OvertimeHours))
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Employee, CreateEmployeeCommand>()
                 .IncludeAllDerived()
                 .ReverseMap();




            //CreateMap<Employee, EmployeeUpdateRequestDTO>()
            //.ForMember(dest => dest.Name, opt => opt.Ignore())
            //.ReverseMap();



            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, SoftDeleteEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequestDTO>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
        }
    }
}

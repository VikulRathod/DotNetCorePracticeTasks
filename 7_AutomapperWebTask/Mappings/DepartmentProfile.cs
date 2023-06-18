using _7_AutomapperDAL.Entities;
using _7_AutomapperWebTask.Models;
using AutoMapper;

namespace _7_AutomapperWebTask.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {             
            //src => dest
            CreateMap<Department, DepartmentViewModel>()
                           .ForMember(dest => dest.DepartmentId,
                           opt => opt.MapFrom(src => src.DepartmentId))
                           .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Name))
                           .ReverseMap(); //dest => src
        }
    }
}

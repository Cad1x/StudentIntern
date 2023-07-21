using Application.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               #region Student    

               cfg.CreateMap<Student, StudentDto>();
               cfg.CreateMap<Student, StudentDetailDto>();
               cfg.CreateMap<CreateStudentDto, Student>();
               cfg.CreateMap<UpdateStudentDto, Student>();

               cfg.CreateMap<IEnumerable<Student>, ListStudentDto>()
                .ForMember(dest => dest.Students, act => act.MapFrom(src => src))
                .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Count()));

               #endregion

           })
           .CreateMapper();
    }
}

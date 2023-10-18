using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3.Application.Commands;
using TesteB3.Application.Dtos;
using TesteB3.Domain.Entitites;

namespace TesteB3.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateScheduleCommand, Schedule>()
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => $"{src.Date}"))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}"));

            CreateMap<Schedule, ScheduleDto>().ReverseMap();

        }
    }
}

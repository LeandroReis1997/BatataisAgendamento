using AutoMapper;
using BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO;
using BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO;
using BatataisAgendamento.Web.Info;

namespace BatataisAgendamento.Web.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Agendamento Dia

            CreateMap<SchedulingDayInfo, SchedulingDayCreateDTO>()
                .ForMember(dest => dest.SchedulingHourCreateDTO,
                           opt => opt.MapFrom(src => src.SchedulingHourInfoList))
                .ReverseMap();

            CreateMap<SchedulingDayInfo, SchedulingDayListDTO>()
                .ForMember(x => x.SchedulingHourListDTO, e => e.MapFrom(src => src.SchedulingHourInfoList));

            CreateMap<SchedulingDayInfo, SchedulingDayUpdateDTO>()
                .ForMember(x => x.SchedulingHourUpdateDTO, e => e.MapFrom(src => src.SchedulingHourInfoList));

            CreateMap<SchedulingDayInfo, SchedulingDayDeleteDTO>()
                .ForMember(x => x.SchedulingHourDeleteDTO, e => e.MapFrom(src => src.SchedulingHourInfoList));


            #endregion

            #region Agendamento Horário

            CreateMap<SchedulingHourInfo, SchedulingHourCreateDTO>().ReverseMap();

            CreateMap<SchedulingHourInfo, SchedulingHourListDTO>();

            CreateMap<SchedulingHourInfo, SchedulingHourUpdateDTO>();

            CreateMap<SchedulingHourInfo, SchedulingHourDeleteDTO>();


            #endregion

        }
    }
}

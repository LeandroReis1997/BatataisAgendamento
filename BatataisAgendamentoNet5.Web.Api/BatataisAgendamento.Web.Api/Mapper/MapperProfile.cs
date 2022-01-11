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

            CreateMap<SchedulingDayInfo, SchedulingDayCreateDTO>().ReverseMap();

            CreateMap<SchedulingDayInfo, SchedulingDayListDTO>();

            CreateMap<SchedulingDayInfo, SchedulingDayUpdateDTO>();

            CreateMap<SchedulingDayInfo, SchedulingDayDeleteDTO>();


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

using AutoMapper;
using BatataisAgendamento.Web.Api.DTO;
using BatataisAgendamento.Web.Info;

namespace BatataisAgendamento.Web.Api.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            #region Agendamento

            CreateMap<SchedulingDayCreateDTO, SchedulingDayInfo>();

            CreateMap<SchedulingDayListDTO, SchedulingDayInfo>().ReverseMap();

            CreateMap<SchedulingDayUpdateDTO, SchedulingDayInfo>().ReverseMap();
            
            CreateMap<SchedulingDayDeleteDTO, SchedulingDayInfo>().ReverseMap();


            #endregion
        }
    }
}

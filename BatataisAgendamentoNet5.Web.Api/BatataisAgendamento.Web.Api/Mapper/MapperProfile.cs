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

            CreateMap<AgendamentoCreateDTO, AgendamentoInfo>();

            CreateMap<AgendamentoListDTO, AgendamentoInfo>().ReverseMap();

            CreateMap<AgendamentoUpdateDTO, AgendamentoInfo>().ReverseMap();
            
            CreateMap<AgendamentoDeleteDTO, AgendamentoInfo>().ReverseMap();


            #endregion
        }
    }
}

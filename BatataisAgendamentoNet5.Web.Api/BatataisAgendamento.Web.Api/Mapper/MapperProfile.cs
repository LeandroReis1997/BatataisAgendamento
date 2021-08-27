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

            CreateMap<AgendamentoDTO, AgendamentoInfo>();

            CreateMap<AgendamentoListDTO, AgendamentoInfo>().ReverseMap();

            #endregion
        }
    }
}

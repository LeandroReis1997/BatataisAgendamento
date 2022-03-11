using BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO
{
    public class SchedulingHourListDTO
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public int IdDay { get; set; }
    }
}

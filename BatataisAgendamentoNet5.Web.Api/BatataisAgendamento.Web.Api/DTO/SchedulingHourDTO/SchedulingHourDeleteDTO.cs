using BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO
{
    public class SchedulingHourDeleteDTO
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public int IdDay { get; set; }
        public SchedulingDayDeleteDTO SchedulingDay { get; set; }

    }
}

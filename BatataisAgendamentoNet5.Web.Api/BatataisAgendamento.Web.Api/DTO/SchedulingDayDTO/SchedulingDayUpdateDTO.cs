using Nest;
using System;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO
{
    public class SchedulingDayUpdateDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}

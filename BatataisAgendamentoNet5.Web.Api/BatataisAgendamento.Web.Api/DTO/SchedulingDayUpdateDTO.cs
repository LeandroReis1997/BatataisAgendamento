using Nest;
using System;

namespace BatataisAgendamento.Web.Api.DTO
{
    public class SchedulingDayUpdateDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}

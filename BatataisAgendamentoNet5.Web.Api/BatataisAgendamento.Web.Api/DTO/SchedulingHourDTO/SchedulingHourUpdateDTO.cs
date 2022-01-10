using Nest;
using System;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO
{
    public class SchedulingHourUpdateDTO
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public int IdDay { get; set; }
    }
}

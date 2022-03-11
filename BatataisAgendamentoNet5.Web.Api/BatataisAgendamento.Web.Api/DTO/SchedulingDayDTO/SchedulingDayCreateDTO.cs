using BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO;
using System;
using System.Collections.Generic;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO
{
    public class SchedulingDayCreateDTO
    {
        public DateTime Date { get; set; }
        public virtual List<SchedulingHourCreateDTO> SchedulingHourCreateDTO { get; set; }
    }
}

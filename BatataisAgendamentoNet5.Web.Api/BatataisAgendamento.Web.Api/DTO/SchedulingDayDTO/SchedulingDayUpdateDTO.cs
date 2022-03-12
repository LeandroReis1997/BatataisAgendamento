using BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO;
using System;
using System.Collections.Generic;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO
{
    public class SchedulingDayUpdateDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual List<SchedulingHourUpdateDTO> SchedulingHourUpdateDTO { get; set; }

    }
}

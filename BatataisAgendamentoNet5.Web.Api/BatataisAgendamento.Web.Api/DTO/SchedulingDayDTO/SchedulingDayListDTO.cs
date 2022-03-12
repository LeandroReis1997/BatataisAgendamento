using BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO;
using Nest;
using System;
using System.Collections.Generic;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO
{
    public class SchedulingDayListDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual List<SchedulingHourListDTO> SchedulingHourListDTO { get; set; }

    }
}

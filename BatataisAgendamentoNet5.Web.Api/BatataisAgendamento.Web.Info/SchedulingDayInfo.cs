using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatataisAgendamento.Web.Info
{
    public class SchedulingDayInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual List<SchedulingHourInfo> SchedulingHourInfoList { get; set; }
    }
}

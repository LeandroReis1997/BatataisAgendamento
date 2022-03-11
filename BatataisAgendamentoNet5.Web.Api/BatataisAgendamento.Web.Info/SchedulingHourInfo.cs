using Nest;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatataisAgendamento.Web.Info
{
    public class SchedulingHourInfo
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        [ForeignKey("SchedulingDay")]
        [Ignore]
        public int IdDay { get; set; }

        [Ignore]
        public SchedulingDayInfo DayInfo { get; set; }
    }
}

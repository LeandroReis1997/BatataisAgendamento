using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatataisAgendamento.Web.Info
{
    public class SchedulingHourInfo
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        [ForeignKey("SchedulingDay")]
        public int IdDay { get; set; }
        public virtual SchedulingDayInfo SchedulingDay { get; set; }
    }
}

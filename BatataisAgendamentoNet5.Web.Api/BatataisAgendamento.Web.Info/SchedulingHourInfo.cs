namespace BatataisAgendamento.Web.Info
{
    public class SchedulingHourInfo
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public int IdDay { get; set; }
        public SchedulingDayInfo SchedulingDay { get; set; }
    }
}

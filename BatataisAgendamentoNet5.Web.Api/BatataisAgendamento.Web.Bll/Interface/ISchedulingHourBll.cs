using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll.Interface
{
    public interface ISchedulingHourBll
    {
        Task<List<SchedulingHourInfo>> GetAllSchedulingHourAsync();
        Task<SchedulingHourInfo> GetBySchedulingHourIdAsync(int id);
        Task<List<SchedulingHourInfo>> GetBySchedulingHourIdDayAsync(int idDay);
        Task<SchedulingHourInfo> AddSchedulingHourAsync(SchedulingHourInfo schedulingHour);
        Task<SchedulingHourInfo> EditSchedulingHourAsync(int id, SchedulingHourInfo schedulingHour);
        Task DeleteSchedulingHourAsync(int id);
    }
}

using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal.Interface
{
    public interface ISchedulingHourDal
    {
        List<SchedulingHourInfo> GetAllSchedulingHourAsync();
        SchedulingHourInfo GetBySchedulingHourIdAsync(int id);
        Task<SchedulingHourInfo> AddSchedulingHourAsync(SchedulingHourInfo schedulingHour);
        Task<SchedulingHourInfo> EditSchedulingHourAsync(int id, SchedulingHourInfo schedulingHour);
        Task DeleteSchedulingHourAsync(int id);
    }
}

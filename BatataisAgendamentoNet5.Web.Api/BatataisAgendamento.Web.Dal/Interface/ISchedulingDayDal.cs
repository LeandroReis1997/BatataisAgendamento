using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal.Interface
{
    public interface ISchedulingDayDal
    {
        List<SchedulingDayInfo> GetAllSchedulingDayAsync();
        SchedulingDayInfo GetBySchedulingDayIdAsync(int id);
        Task<SchedulingDayInfo> AddSchedulingDayAsync(SchedulingDayInfo scheduling);
        Task<SchedulingDayInfo> EditSchedulingDayAsync(int id, SchedulingDayInfo scheduling);
        Task DeleteSchedulingDayAsync(int id);
    }
}

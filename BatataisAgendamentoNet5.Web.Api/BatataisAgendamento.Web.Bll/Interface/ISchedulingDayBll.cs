using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll.Interface
{
    public interface ISchedulingDayBll
    {
        List<SchedulingDayInfo> GetAllSchedulingDayAsync();
        SchedulingDayInfo GetBySchedulingDayIdAsync(int id);
        Task<SchedulingDayInfo> AddSchedulingDayAsync(SchedulingDayInfo scheduling);
        Task<SchedulingDayInfo> EditSchedulingDayAsync(int id, SchedulingDayInfo scheduling);
        Task DeleteSchedulingDayAsync(int id);
    }
}

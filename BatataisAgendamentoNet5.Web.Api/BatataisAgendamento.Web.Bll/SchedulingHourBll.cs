using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll
{
    public class SchedulingHourBll : ISchedulingHourBll
    {
        private ISchedulingHourDal _dal;
        private ISchedulingDayDal _schedulingDayDal;

        public SchedulingHourBll(ISchedulingHourDal schedulingHourDal, ISchedulingDayDal schedulingDayDal)
        {
            _dal = schedulingHourDal;
            _schedulingDayDal = schedulingDayDal;
        }

        public async Task<SchedulingHourInfo> AddSchedulingHourAsync(SchedulingHourInfo schedulingHour)
        {
            schedulingHour.SchedulingDay = _schedulingDayDal.GetBySchedulingDayIdAsync(schedulingHour.IdDay);
            return await _dal.AddSchedulingHourAsync(schedulingHour);
        }

        public async Task DeleteSchedulingHourAsync(int id)
        {
            await _dal.DeleteSchedulingHourAsync(id);
        }

        public async Task<SchedulingHourInfo> EditSchedulingHourAsync(int id, SchedulingHourInfo schedulingHour)
        {
            schedulingHour.SchedulingDay = _schedulingDayDal.GetBySchedulingDayIdAsync(schedulingHour.IdDay);
            return await _dal.EditSchedulingHourAsync(id, new SchedulingHourInfo
            {
                Id = id,
                Hour = schedulingHour.Hour,
                IdDay = schedulingHour.IdDay,
                SchedulingDay = schedulingHour.SchedulingDay
            });
        }

        public async Task<List<SchedulingHourInfo>> GetAllSchedulingHourAsync()
        {
            return await _dal.GetAllSchedulingHourAsync();
        }

        public async Task<SchedulingHourInfo> GetBySchedulingHourIdAsync(int id)
        {
            return await _dal.GetBySchedulingHourIdAsync(id);
        }
    }
}

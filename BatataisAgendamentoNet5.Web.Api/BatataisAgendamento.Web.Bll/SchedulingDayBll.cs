using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll
{
    public class SchedulingDayBll : ISchedulingDayBll
    {
        private ISchedulingDayDal _dal;

        public SchedulingDayBll(ISchedulingDayDal schedulingDayDal)
        {
            _dal = schedulingDayDal;
        }

        public async Task<SchedulingDayInfo> AddSchedulingDayAsync(SchedulingDayInfo scheduling)
        {
            return await _dal.AddSchedulingDayAsync(scheduling);
            //return await _dal.AddSchedulingAsync(new AgendamentoInfo
            //{
            //    Id = scheduling.Id,
            //    Dia = DateTime.Now.Date,
            //    Horario = DateTime.Now.ToString("HH:mm")
            //});
        }

        public async Task DeleteSchedulingDayAsync(int id)
        {
            await _dal.DeleteSchedulingDayAsync(id);
        }

        public async Task<SchedulingDayInfo> EditSchedulingDayAsync(int id, SchedulingDayInfo schedulingDay)
        {
            return await _dal.EditSchedulingDayAsync(id, new SchedulingDayInfo
            {
                Id = id,
                Date = schedulingDay.Date
            });
        }

        public List<SchedulingDayInfo> GetAllSchedulingDayAsync()
        {
            return _dal.GetAllSchedulingDayAsync();
        }

        public SchedulingDayInfo GetBySchedulingDayIdAsync(int id)
        {
            return _dal.GetBySchedulingDayIdAsync(id);
        }
    }
}

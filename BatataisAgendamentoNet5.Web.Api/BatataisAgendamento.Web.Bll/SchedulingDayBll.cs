using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll
{
    public class SchedulingDayBll : ISchedulingDayBll
    {
        private ISchedulingDayDal _dal;
        private ISchedulingHourDal _hourDal;

        public SchedulingDayBll(ISchedulingDayDal schedulingDayDal, ISchedulingHourDal hourDal)
        {
            _dal = schedulingDayDal;
            _hourDal = hourDal;
        }

        public async Task<SchedulingDayInfo> AddSchedulingDayAsync(SchedulingDayInfo scheduling)
        {
            var testeeeee = new SchedulingDayInfo
            {
                Date = scheduling.Date,
                SchedulingHourInfoList = new List<SchedulingHourInfo>()
            };

            foreach (var item in scheduling.SchedulingHourInfoList)
            {
                testeeeee.SchedulingHourInfoList.Add(new SchedulingHourInfo
                {
                    Hour = item.Hour,
                    IdDay = testeeeee.Id
                });
            }

            await _dal.AddSchedulingDayAsync(testeeeee);

            foreach (var item in testeeeee.SchedulingHourInfoList)
            {
                item.DayInfo = null;
            }


            return testeeeee;
        }

        public async Task DeleteSchedulingDayAsync(int id)
        {
            await _dal.DeleteSchedulingDayAsync(id);
        }

        public async Task<SchedulingDayInfo> EditSchedulingDayAsync(int id, SchedulingDayInfo scheduling)
        {
            var testeeeee = new SchedulingDayInfo
            {
                Id = id,
                Date = scheduling.Date,
                SchedulingHourInfoList = new List<SchedulingHourInfo>()
            };

            foreach (var item in scheduling.SchedulingHourInfoList)
            {
                testeeeee.SchedulingHourInfoList.Add(new SchedulingHourInfo
                {
                    Id = item.Id,
                    Hour = item.Hour,
                    IdDay = testeeeee.Id
                });
            }

            await _dal.EditSchedulingDayAsync(id, testeeeee);

            foreach (var item in testeeeee.SchedulingHourInfoList)
            {
                item.DayInfo = null;
            }

            return testeeeee;
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

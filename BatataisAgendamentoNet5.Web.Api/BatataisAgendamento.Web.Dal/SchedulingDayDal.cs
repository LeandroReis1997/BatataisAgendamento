using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using BatataisAgendamento.Web.Info.Data.Configuration.Interface;
using BatataisAgendamento.Web.Info.SqlDbContext;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal
{
    public class SchedulingDayDal : ISchedulingDayDal
    {
        private readonly SqlDbContext _agendamentoDay;
        public SchedulingDayDal(SqlDbContext sqlDbContext)
        {
            _agendamentoDay = sqlDbContext;
        }

        public async Task<SchedulingDayInfo> AddSchedulingDayAsync(SchedulingDayInfo scheduling)
        {
            await _agendamentoDay.AddAsync(scheduling);
            await _agendamentoDay.SaveChangesAsync();

            return scheduling;
        }

        public async Task DeleteSchedulingDayAsync(int id)
        {
            var entity = _agendamentoDay.SchedulingDay.FirstOrDefault(x => x.Id.Equals(id));
            _agendamentoDay.Remove(entity);
            await _agendamentoDay.SaveChangesAsync();
        }

        public async Task<SchedulingDayInfo> EditSchedulingDayAsync(int id, SchedulingDayInfo scheduling)
        {
            _agendamentoDay.Update(scheduling);
            await _agendamentoDay.SaveChangesAsync();
            return scheduling;
        }

        public List<SchedulingDayInfo> GetAllSchedulingDayAsync() =>
            _agendamentoDay.SchedulingDay.Include(x => x.SchedulingHourInfoList).ToList();


        public SchedulingDayInfo GetBySchedulingDayIdAsync(int id) =>
            _agendamentoDay.SchedulingDay.FirstOrDefault(x => x.Id.Equals(id));
    }
}
